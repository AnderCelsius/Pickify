#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /src
COPY *.sln .
# copy and restore all projects
COPY Pickify/*.csproj Pickify/
COPY Pickify.Model/*.csproj Pickify.Model/
COPY Pickify.Data/*.csproj Pickify.Data/
COPY Pickify.Core/*.csproj Pickify.Core/
RUN dotnet restore Pickify/*.csproj
#COPY Pickify.Test/*.csproj Pickify.Test/
#RUN dotnet restore Pickify.Test/*.csproj
# Copy everything else
COPY . .

#Testing
FROM base AS testing
WORKDIR /src/Pickify
RUN dotnet build
#WORKDIR /src/Pickify.Test
#RUN dotnet test

#Publishing
FROM base AS publish
WORKDIR /src/Pickify
#COPY /src/Pickify.wwwroot/Data /Data/
RUN dotnet publish -c Release -o /src/publish


#Get the runtime into a folder called app
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
COPY --from=publish /src/Pickify/wwwroot/Data/* /Data/
ENTRYPOINT ["dotnet", "Pickify.dll"]
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet Pickify.dll
    
    
 
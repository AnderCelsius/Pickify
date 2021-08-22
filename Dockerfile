#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Pickify/Pickify.csproj", "Pickify/"]
RUN dotnet restore "Pickify/Pickify.csproj"
COPY . .
WORKDIR "/src/Pickify"
RUN dotnet build "Pickify.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pickify.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pickify.dll"]
# Base
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

# SDK
FROM mcr.microsoft.com/dotnet/sdk:5.0.102-ca-patch-buster-slim AS build
WORKDIR /src/mycalculatorwebapp/
COPY *.csproj ./
#RUN dotnet restore --source http://192.168.12.32:8081/nexus/service/local/nuget/nuget-public/
RUN dotnet nuget add source http://192.168.1.194:8081/repository/Nuget-Group/index.json -n "Nuget local" -u "admin" -p "39e19b8a-748f-4d85-8a59-e011a1405f74" --store-password-in-clear-text
RUN dotnet restore --source http://192.168.1.194:8081/repository/Nuget-Group/index.json
COPY . .
WORKDIR /src/mycalculatorwebapp/
RUN dotnet build -c Release -o /app

# Publish
FROM build AS publish
RUN dotnet publish -r linux-x64 -c Release /p:PublishTrimmed=true -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet","ModelClassWebApp.Service.dll"]

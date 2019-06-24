FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src/mycalculatorwebapp/
COPY *.csproj ./
RUN dotnet restore --source http://192.168.12.32:8081/nexus/service/local/nuget/nuget-public/
COPY . .
WORKDIR /src/mycalculatorwebapp/
RUN dotnet build  -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet","ModelClassWebApp.Service.dll"]
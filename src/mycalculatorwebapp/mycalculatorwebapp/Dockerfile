FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src/mycalculatorwebapp
COPY mycalculatorwebapp/ModelClassWebApp.Service.csproj mycalculatorwebapp/
RUN dotnet restore mycalculatorwebapp/ModelClassWebApp.Service.csproj
COPY . .
WORKDIR /src/mycalculatorwebapp
RUN dotnet build ModelClassWebApp.Service.csproj -c Release -o /app 

FROM build AS publish
RUN dotnet publish ModelClassWebApp.Service.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ModelClassWebApp.Service.dll"]

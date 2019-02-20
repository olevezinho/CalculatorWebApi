FROM microsoft/dotnet:sdk
WORKDIR /app

#copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore -nowarn:msb3202,nu1503 -p:RestoreUseSkipNonexistentTargets=false
#RUN dotnet restore --source http://localhost:8082/nexus/service/local/nuget/nuget-public/

# copy and build everything else
COPY . ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet","ModelClassWebApp.Service.dll"]
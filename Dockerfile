FROM microsoft/dotnet:2.1-aspnetcore-runtime AS build-env
WORKDIR /app

EXPOSE 80
EXPOSE 443
EXPOSE 5003

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY tournament.sln  /
COPY Tournament/Tournament.csproj Tournament/
RUN dotnet restore Tournament/Tournament.csproj
COPY . .
WORKDIR /src/Tournament
RUN dotnet build Tournament.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Tournament.csproj -c Release -o /app

FROM build-env AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Tournament.dll"]
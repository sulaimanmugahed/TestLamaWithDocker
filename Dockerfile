FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5010

ENV ASPNETCORE_URLS=http://+:5010

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["TestLamaWithDocker.csproj", "./"]
# RUN dotnet restore "TestLamaWithDocker.csproj" -p:ExcludeMetalama=true

COPY . .
WORKDIR "/src/."
RUN dotnet build "TestLamaWithDocker.csproj" -p:ExcludeMetalama=true -c $configuration --packages ./packages  -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TestLamaWithDocker.csproj" -c $configuration --packages ./packages -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestLamaWithDocker.dll"]

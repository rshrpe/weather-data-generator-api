#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 5100
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WeatherDataGeneratorAPI/WeatherDataGenerator.API.csproj", "WeatherDataGeneratorAPI/"]
COPY ["WeatherDataGenerator.Domain/WeatherDataGenerator.Domain.csproj", "WeatherDataGenerator.Domain/"]
COPY ["WeatherDataGenerator.Presentation/WeatherDataGenerator.Presentation.csproj", "WeatherDataGenerator.Presentation/"]
RUN dotnet restore "WeatherDataGeneratorAPI/WeatherDataGenerator.API.csproj"
COPY . .

WORKDIR "/src/WeatherDataGeneratorAPI"
RUN dotnet build "WeatherDataGenerator.API.csproj" -c ${BUILD_CONFIGURATION} -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WeatherDataGenerator.API.csproj" -c ${BUILD_CONFIGURATION} -o /app/publish

FROM base as final 
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "WeatherDataGenerator.API.dll" ]

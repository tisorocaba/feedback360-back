#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update && apt-get install -y --no-install-recommends && rm -rf /var/lib/apt/lists/*
WORKDIR /app
EXPOSE 9088
EXPOSE 9443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ENV CONSUL_URL=http://172.16.9.64:8500/
ENV LUCKY_DRAW_CONSUL_CONFIG_ENABLED=0
ENV LUCKY_DRAW_CONSUL_CONFIG_KEY=PMS.MicroServices.LuckyDraw.WebApi/appsettings.Production.json
WORKDIR /src
COPY ["PMS.MicroServices.LuckyDraw.WebApi/PMS.MicroServices.LuckyDraw.WebApi.csproj", "PMS.MicroServices.LuckyDraw.WebApi/"]
RUN dotnet restore "PMS.MicroServices.LuckyDraw.WebApi/PMS.MicroServices.LuckyDraw.WebApi.csproj"
COPY . .
WORKDIR "/src/PMS.MicroServices.LuckyDraw.WebApi"
RUN dotnet build "PMS.MicroServices.LuckyDraw.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "PMS.MicroServices.LuckyDraw.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PMS.MicroServices.LuckyDraw.WebApi.dll"]

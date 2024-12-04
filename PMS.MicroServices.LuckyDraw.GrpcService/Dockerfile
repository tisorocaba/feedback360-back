#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PMS.MicroServices.LuckyDraw.GrpcService/PMS.MicroServices.LuckyDraw.GrpcService.csproj", "PMS.MicroServices.LuckyDraw.GrpcService/"]
RUN dotnet restore "./PMS.MicroServices.LuckyDraw.GrpcService/PMS.MicroServices.LuckyDraw.GrpcService.csproj"
COPY . .
WORKDIR "/src/PMS.MicroServices.LuckyDraw.GrpcService"
RUN dotnet build "./PMS.MicroServices.LuckyDraw.GrpcService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PMS.MicroServices.LuckyDraw.GrpcService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PMS.MicroServices.LuckyDraw.GrpcService.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RenshyuuNihongo/RenshyuuNihongo.csproj", "RenshyuuNihongo/"]
RUN dotnet restore "RenshyuuNihongo/RenshyuuNihongo.csproj"
COPY . .
WORKDIR "/src/RenshyuuNihongo"
RUN dotnet build "./RenshyuuNihongo.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RenshyuuNihongo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RenshyuuNihongo.dll"]

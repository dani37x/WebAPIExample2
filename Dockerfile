FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WebAPIExample2.csproj", "."]
RUN dotnet restore "./WebAPIExample2.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebAPIExample2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPIExample2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPIExample2.dll"]
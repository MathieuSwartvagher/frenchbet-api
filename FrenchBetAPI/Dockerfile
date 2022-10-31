#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FrenchBetAPI/FrenchBetAPI.csproj", "FrenchBetAPI/"]
COPY ["Models/Models.csproj", "Models/"]
RUN dotnet restore "FrenchBetAPI/FrenchBetAPI.csproj"
COPY . .
WORKDIR "/src/FrenchBetAPI"
RUN dotnet build "FrenchBetAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FrenchBetAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FrenchBetAPI.dll"]
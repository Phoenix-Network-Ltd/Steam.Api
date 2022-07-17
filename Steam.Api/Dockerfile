#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Steam.Api/Steam.Api.csproj", "Steam.Api/"]
COPY ["Api.Core/Api.Core.csproj", "Api.Core/"]
RUN dotnet restore "Steam.Api/Steam.Api.csproj"
COPY . .
WORKDIR "/src/Steam.Api"
RUN dotnet build "Steam.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Steam.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Steam.Api.dll"]
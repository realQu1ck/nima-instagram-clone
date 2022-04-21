#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Core/Nima.Instagram.Server.API/Nima.Instagram.Server.API.csproj", "Core/Nima.Instagram.Server.API/"]
COPY ["Lib/Nima.Instagram.Shared.Server/Nima.Instagram.Shared.Server.csproj", "Lib/Nima.Instagram.Shared.Server/"]
COPY ["Lib/Nima.Instagram.Shared.Client/Nima.Instagram.Shared.Client.csproj", "Lib/Nima.Instagram.Shared.Client/"]
RUN dotnet restore "Core/Nima.Instagram.Server.API/Nima.Instagram.Server.API.csproj"
COPY . .
WORKDIR "/src/Core/Nima.Instagram.Server.API"
RUN dotnet build "Nima.Instagram.Server.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nima.Instagram.Server.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nima.Instagram.Server.API.dll"]

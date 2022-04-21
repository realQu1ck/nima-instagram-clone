#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Middleware/IdentityServer/Nima.Instagram.Server.Middleware.IdentityServer/Nima.Instagram.Server.Middleware.IdentityServer.csproj", "Middleware/IdentityServer/Nima.Instagram.Server.Middleware.IdentityServer/"]
RUN dotnet restore "Middleware/IdentityServer/Nima.Instagram.Server.Middleware.IdentityServer/Nima.Instagram.Server.Middleware.IdentityServer.csproj"
COPY . .
WORKDIR "/src/Middleware/IdentityServer/Nima.Instagram.Server.Middleware.IdentityServer"
RUN dotnet build "Nima.Instagram.Server.Middleware.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nima.Instagram.Server.Middleware.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nima.Instagram.Server.Middleware.IdentityServer.dll"]

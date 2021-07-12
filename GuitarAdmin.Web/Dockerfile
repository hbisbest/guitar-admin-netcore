#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["GuitarAdmin.Web/GuitarAdmin.Web.csproj", "GuitarAdmin.Web/"]
RUN dotnet restore "GuitarAdmin.Web/GuitarAdmin.Web.csproj"
COPY . .
WORKDIR "/src/GuitarAdmin.Web"
RUN dotnet build "GuitarAdmin.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GuitarAdmin.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GuitarAdmin.Web.dll"]
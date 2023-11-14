#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ollix-backend/src/Ollix.API/Ollix.API.csproj", "ollix-backend/src/Ollix.API/"]
COPY ["ollix-backend/src/Ollix.SharedKernel/Ollix.SharedKernel.csproj", "ollix-backend/src/Ollix.SharedKernel/"]
COPY ["ollix-backend/src/Ollix.Application/Ollix.Application.csproj", "ollix-backend/src/Ollix.Application/"]
COPY ["ollix-backend/src/Ollix.Infrastructure.Data/Ollix.Infrastructure.Data.csproj", "ollix-backend/src/Ollix.Infrastructure.Data/"]
COPY ["ollix-backend/src/Ollix.Domain/Ollix.Domain.csproj", "ollix-backend/src/Ollix.Domain/"]
COPY ["ollix-backend/src/Ollix.Infrastructure.Integrations/Ollix.Infrastructure.Integrations.csproj", "ollix-backend/src/Ollix.Infrastructure.Integrations/"]
COPY ["ollix-backend/src/Ollix.Infrastructure.IoC/Ollix.Infrastructure.IoC.csproj", "ollix-backend/src/Ollix.Infrastructure.IoC/"]
RUN dotnet restore "ollix-backend/src/Ollix.API/Ollix.API.csproj"
COPY . .
WORKDIR "/src/ollix-backend/src/Ollix.API"
RUN dotnet build "Ollix.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ollix.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ollix.API.dll"]
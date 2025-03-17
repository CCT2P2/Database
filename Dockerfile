# Base image with SQLite pre-installed
FROM alpine/sqlite:3.48 as base

RUN apk add --no-cache \
    icu-libs \
    krb5-libs \
    libgcc \
    libintl \
    libssl3 \
    libstdc++ \
    zlib \
    && mkdir -p /app

WORKDIR /app

# Build stage using the .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build

WORKDIR /src
COPY ["database.csproj", "./"]
RUN dotnet restore "database.csproj"

COPY . .

RUN dotnet publish "database.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage: combine Alpine base with published app
FROM base AS final

COPY --from=build /app/publish /app

EXPOSE 9012

WORKDIR /app

ENTRYPOINT ["dotnet", "database.dll"]

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine3.19 AS base

USER daemon

WORKDIR /app
EXPOSE 80
# EXPOSE 443

#---------------------------------------------------

# FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine3.19 AS build

# WORKDIR /src
# COPY ["src/App.WebApi/App.WebApi.csproj", "src/App.WebApi/"]
# # Restore dependencies
# RUN dotnet restore "src/App.WebApi/App.WebApi.csproj"
# COPY . .
# WORKDIR "/src/src/App.WebApi"
# RUN dotnet build "App.WebApi.csproj" -c Release -o /app/build

# #---------------------------------------------------

# FROM build AS publish
# RUN dotnet publish "App.WebApi.csproj" -c Release -o /app/publish

# #---------------------------------------------------

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "App.WebApi.dll"]
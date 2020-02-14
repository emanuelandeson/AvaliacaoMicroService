FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["FCamara.API/FCamara.API.csproj", "FCamara.API/"]
RUN dotnet restore "FCamara.API/FCamara.API.csproj"
COPY . .
WORKDIR "/src/FCamara.API"
RUN dotnet build "FCamara.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FCamara.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FCamara.API.dll"]
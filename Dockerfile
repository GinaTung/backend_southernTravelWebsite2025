FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./backend_southernTravelWebsite2025 ./backend_southernTravelWebsite2025
WORKDIR /src/backend_southernTravelWebsite2025
RUN dotnet restore
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "backend_southernTravelWebsite2025.dll"]
EXPOSE 80

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Colibri/Colibri.csproj", "Colibri/"]
RUN dotnet restore "Colibri/Colibri.csproj"
COPY . .
WORKDIR "/src/Colibri"
RUN dotnet build "Colibri.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Colibri.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Colibri.dll"]

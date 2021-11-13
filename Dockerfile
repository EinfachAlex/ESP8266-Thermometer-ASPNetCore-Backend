FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Thermometer/Thermometer.csproj", "Thermometer/"]
RUN dotnet restore "Thermometer/Thermometer.csproj"
COPY . .
WORKDIR "/src/Thermometer"
RUN dotnet build "Thermometer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Thermometer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Thermometer.dll"]

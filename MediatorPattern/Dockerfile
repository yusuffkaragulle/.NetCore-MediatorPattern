FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["MediatorPattern/MediatorPattern.csproj", "MediatorPattern/"]
RUN dotnet restore "MediatorPattern/MediatorPattern.csproj"
COPY . .
WORKDIR "/src/MediatorPattern"
RUN dotnet build "MediatorPattern.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MediatorPattern.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MediatorPattern.dll"]
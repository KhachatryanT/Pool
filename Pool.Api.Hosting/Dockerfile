FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pool.Api/Pool.Api.csproj", "Pool.Api/"]
RUN dotnet restore "Pool.Api/Pool.Api.csproj"
COPY . .
WORKDIR "/src/Pool.Api"
RUN dotnet build "Pool.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pool.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pool.Api.dll"]

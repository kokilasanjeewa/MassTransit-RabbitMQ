FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore ./src/headers/Headers.Consumer.AnyPriority/Headers.Consumer.AnyPriority.csproj
RUN dotnet publish ./src/headers/Headers.Consumer.AnyPriority/Headers.Consumer.AnyPriority.csproj -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Headers.Consumer.AnyPriority.dll"]

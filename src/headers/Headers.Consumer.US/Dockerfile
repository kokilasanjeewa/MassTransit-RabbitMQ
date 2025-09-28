FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore ./src/headers/Headers.Consumer.US/Headers.Consumer.US.csproj
RUN dotnet publish ./src/headers/Headers.Consumer.US/Headers.Consumer.US.csproj -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Headers.Consumer.US.dll"]

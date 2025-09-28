FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore ./src/fanout/Fanout.Consumer.1/Fanout.Consumer.1.csproj
RUN dotnet publish ./src/fanout/Fanout.Consumer.1/Fanout.Consumer.1.csproj -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Fanout.Consumer.1.dll"]

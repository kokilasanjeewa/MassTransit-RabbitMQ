FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore ./src/fanout/Fanout.Consumer.2/Fanout.Consumer.2.csproj
RUN dotnet publish ./src/fanout/Fanout.Consumer.2/Fanout.Consumer.2.csproj -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Fanout.Consumer.2.dll"]

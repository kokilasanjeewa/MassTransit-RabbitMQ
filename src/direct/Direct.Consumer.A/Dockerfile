FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore ./src/direct/Direct.Consumer.A/Direct.Consumer.A.csproj
RUN dotnet publish ./src/direct/Direct.Consumer.A/Direct.Consumer.A.csproj -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Direct.Consumer.A.dll"]

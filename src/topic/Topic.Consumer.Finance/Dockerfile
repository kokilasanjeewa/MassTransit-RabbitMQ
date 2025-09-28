FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore ./src/topic/Topic.Consumer.Finance/Topic.Consumer.Finance.csproj
RUN dotnet publish ./src/topic/Topic.Consumer.Finance/Topic.Consumer.Finance.csproj -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Topic.Consumer.Finance.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TutorialRedis.csproj", "./"]
RUN dotnet restore "TutorialRedis.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "TutorialRedis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TutorialRedis.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TutorialRedis.dll"]

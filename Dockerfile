FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY src/service.csproj .
RUN dotnet restore
COPY ./src .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "service.dll"]
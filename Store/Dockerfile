FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /src
COPY ./Catalog/Catalog.csproj ./Catalog/
COPY ./Catalog.sln .
RUN dotnet restore

COPY . ./
RUN dotnet publish ./Catalog/Catalog.csproj -c Release  -o /bin

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
EXPOSE 80
WORKDIR /app
COPY --from=build-env /bin .
ENTRYPOINT ["dotnet", "Catalog.dll"]
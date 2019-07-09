FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /src
COPY ./EventSubscriber/EventSubscriber.csproj ./EventSubscriber/
COPY ./ProductRepository/ProductRepository.csproj ./ProductRepository/
COPY ./ProductQueryApi/ProductQueryApi.csproj ./ProductQueryApi/
COPY ./Query.sln .

RUN dotnet restore 

COPY . .
RUN dotnet publish ./ProductQueryApi/ProductQueryApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["dotnet", "ProductQueryApi.dll"]
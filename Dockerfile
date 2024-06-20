FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /project

COPY ./src/ServerInfo .

RUN dotnet publish -c Release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime

RUN apt-get update && apt-get install -y curl

WORKDIR /app
COPY --from=build /project/publish .

ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["/app/ServerInfo"]

EXPOSE 80

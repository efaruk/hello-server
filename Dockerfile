FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /project

COPY ./src/ServerInfo .

RUN dotnet publish -c Release -o publish -v

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime

WORKDIR /app
COPY --from=build /project/publish .

ENV ASPNETCORE_URLS=http://+:80

COPY \
    ./publish ./

ENTRYPOINT ["/app/ServerInfo"]

EXPOSE 80

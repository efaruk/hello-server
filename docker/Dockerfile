FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80

COPY \
    ./publish ./

ENTRYPOINT ["/app/ServerInfo"]

EXPOSE 80

# server-info

An aspnet core web page to show server information to test the deployments behind a any type of proxy, like phpinfo

## Light Theme Screen Shot
![Light Theme](https://github.com/efaruk/server-info/blob/main/screenshots/home-light-theme.png?raw=true)

## Dark Theme Screen Shot
![Dark Theme](https://github.com/efaruk/server-info/blob/main/screenshots/home-dark-theme.png?raw=true)


## How to use it

- Clone the repo 
```
git clone git@github.com:efaruk/server-info.git
```
- If you want to use stock docker image you can use following
```
docker run --name server-info -p 8888:80 -d efaruk/server-info
```
- Or with docker compose just use
```
docker compose up -d
```
- If you want to build from source code and use your own docker image (No runtime needed)
```
docker compose build
docker compose up -d
```

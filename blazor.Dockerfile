FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./Scales.BlazorApp/Scales.BlazorApp.csproj ./
RUN dotnet restore Scales.BlazorApp.csproj
COPY . . 

RUN dotnet build ./Scales.BlazorApp/Scales.BlazorApp.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ./Scales.BlazorApp/Scales.BlazorApp.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY scalessimmulator.ru.crt /etc/ssl/scalessimmulator.ru.crt
COPY scalessimmulator.ru.key /etc/ssl/scalessimmulator.ru.key
COPY nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
EXPOSE 443
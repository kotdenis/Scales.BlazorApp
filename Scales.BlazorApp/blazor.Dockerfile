FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Scales.BlazorApp.sln Scales.BlazorApp.sln
COPY ./Scales.BlazorApp/Scales.BlazorApp.csproj ./
RUN dotnet restore Scales.BlazorApp.csproj
COPY . .

RUN dotnet build ./Scales.BlazorApp/Scales.BlazorApp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ./Scales.BlazorApp/Scales.BlazorApp.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY nginx.conf /etc/nginx/nginx.conf
ENTRYPOINT ["dotnet", "Scales.BlazorApp.dll"]
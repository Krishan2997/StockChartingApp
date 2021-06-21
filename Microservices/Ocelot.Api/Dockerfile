#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Ocelot.Api/Ocelot.Api.csproj", "Ocelot.Api/"]
RUN dotnet restore "Ocelot.Api/Ocelot.Api.csproj"
COPY . .
WORKDIR "/src/Ocelot.Api"
RUN dotnet build "Ocelot.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ocelot.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ocelot.Api.dll"]
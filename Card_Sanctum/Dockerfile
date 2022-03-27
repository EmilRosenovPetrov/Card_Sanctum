#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Card_Sanctum/Card_Sanctum.csproj", "Card_Sanctum/"]
RUN dotnet restore "Card_Sanctum/Card_Sanctum.csproj"
COPY . .
WORKDIR "/src/Card_Sanctum"
RUN dotnet build "Card_Sanctum.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Card_Sanctum.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Card_Sanctum.dll"]
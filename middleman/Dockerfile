#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src
COPY ["middleman/middleman.csproj", "middleman/"]
RUN dotnet restore "middleman/middleman.csproj"
COPY . .
WORKDIR "/src/middleman"
RUN dotnet build "middleman.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "middleman.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "middleman.dll"]

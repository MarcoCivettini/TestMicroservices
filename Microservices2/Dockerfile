#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Microservices2/Microservices2.csproj", "Microservices2/"]
RUN dotnet restore "Microservices2/Microservices2.csproj"
COPY . .
WORKDIR "/src/Microservices2"
RUN dotnet build "Microservices2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservices2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices2.dll"]
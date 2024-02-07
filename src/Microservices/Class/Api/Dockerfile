FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Microservices/Class/Api/Api.csproj", "Microservices/Class/Api/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["Microservices/Class/Class/Class.csproj", "Microservices/Class/Class/"]
COPY ["Microservices/Class/ClassInfrutructure/ClassInfrutructure.csproj", "Microservices/Class/ClassInfrutructure/"]
COPY ["Microservices/Class/ClassDomain/ClassDomain.csproj", "Microservices/Class/ClassDomain/"]
RUN dotnet restore "Microservices/Class/Api/Api.csproj"
COPY . .
WORKDIR "/src/Microservices/Class/Api"
RUN dotnet build "Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]

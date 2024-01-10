FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Microservices/Admin/Api/Api.csproj", "Microservices/Admin/Api/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["Microservices/Admin/Admin/Admin.csproj", "Microservices/Admin/Admin/"]
COPY ["Microservices/Admin/Dto/Dto.csproj", "Microservices/Admin/Dto/"]
COPY ["Microservices/Admin/Model/Model.csproj", "Microservices/Admin/Model/"]
COPY ["Microservices/Admin/Domain/Domain.csproj", "Microservices/Admin/Domain/"]
COPY ["Microservices/Admin/Repository/Repository.csproj", "Microservices/Admin/Repository/"]
COPY ["Microservices/Admin/Infrutructure/Infrutructure.csproj", "Microservices/Admin/Infrutructure/"]
COPY ["Microservices/Admin/Service/Service.csproj", "Microservices/Admin/Service/"]
RUN dotnet restore "Microservices/Admin/Api/Api.csproj"
COPY . .
WORKDIR "/src/Microservices/Admin/Api"
RUN dotnet build "Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Microservices/Teacher/Command/Api/Api.csproj", "Microservices/Teacher/Command/Api/"]
COPY ["Microservices/Admin/Domain/Domain.csproj", "Microservices/Admin/Domain/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["Microservices/Teacher/Command/Teacher/Teacher.csproj", "Microservices/Teacher/Command/Teacher/"]
COPY ["Microservices/Teacher/Command/TeacherDomain/TeacherDomain.csproj", "Microservices/Teacher/Command/TeacherDomain/"]
COPY ["Microservices/Admin/Infrutructure/Infrutructure.csproj", "Microservices/Admin/Infrutructure/"]
COPY ["Microservices/Teacher/Command/TeacherInfrutructure/TeacherInfrutructure.csproj", "Microservices/Teacher/Command/TeacherInfrutructure/"]
RUN dotnet restore "Microservices/Teacher/Command/Api/Api.csproj"
COPY . .
WORKDIR "/src/Microservices/Teacher/Command/Api"
RUN dotnet build "Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]

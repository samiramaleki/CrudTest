#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Mc2.CrudTest.Presentation/Mc2.CrudTest.Presentation.csproj", "Mc2.CrudTest.Presentation/"]
COPY ["Mc2.CrudTest.Application/Mc2.CrudTest.Application.csproj", "Mc2.CrudTest.Application/"]
COPY ["Mc2.CrudTest.Domain/Mc2.CrudTest.Domain.csproj", "Mc2.CrudTest.Domain/"]
COPY ["Mc2.CrudTest.Persistence/Mc2.CrudTest.Persistence.csproj", "Mc2.CrudTest.Persistence/"]
COPY ["Mc2.CrudTest.Infrastructure/Mc2.CrudTest.Infrastructure.csproj", "Mc2.CrudTest.Infrastructure/"]
RUN dotnet restore "./Mc2.CrudTest.Presentation/./Mc2.CrudTest.Presentation.csproj"
COPY . .
WORKDIR "/src/Mc2.CrudTest.Presentation"
RUN dotnet build "./Mc2.CrudTest.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Mc2.CrudTest.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mc2.CrudTest.Presentation.dll"]
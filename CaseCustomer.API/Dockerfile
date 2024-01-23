#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CaseCustomer.API/CaseCustomer.API.csproj", "CaseCustomer.API/"]
COPY ["CaseCustomer.CrossCutting/CaseCustomer.CrossCutting.csproj", "CaseCustomer.CrossCutting/"]
COPY ["CaseCustomer.Application/CaseCustomer.Application.csproj", "CaseCustomer.Application/"]
COPY ["CaseCustomer.Domain/CaseCustomer.Domain.csproj", "CaseCustomer.Domain/"]
COPY ["CaseCustomer.Infrastructure/CaseCustomer.Infrastructure.csproj", "CaseCustomer.Infrastructure/"]
RUN dotnet restore "CaseCustomer.API/CaseCustomer.API.csproj"
COPY . .
WORKDIR "/src/CaseCustomer.API"
RUN dotnet build "CaseCustomer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CaseCustomer.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CaseCustomer.API.dll"]
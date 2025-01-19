FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/WC.Service.Employees.Domain/WC.Service.Employees.Domain.csproj src/WC.Service.Employees.Domain/
COPY src/WC.Service.Employees.Domain.Abstractions/WC.Service.Employees.Domain.Abstractions.csproj src/WC.Service.Employees.Domain.Abstractions/
COPY src/WC.Service.Employees.CreatePosition/WC.Service.Employees.CreatePosition.csproj src/WC.Service.Employees.CreatePosition/

RUN dotnet restore src/WC.Service.Employees.CreatePosition/WC.Service.Employees.CreatePosition.csproj

COPY src .
WORKDIR /src/WC.Service.Employees.CreatePosition
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

COPY src/WC.Service.Employees.CreatePosition/appsettings.json /app/../..

ENTRYPOINT ["dotnet", "WC.Service.Employees.CreatePosition.dll"]

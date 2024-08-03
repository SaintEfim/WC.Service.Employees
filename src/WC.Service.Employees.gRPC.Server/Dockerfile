FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/WC.Service.Employees.gRPC.Server/WC.Service.Employees.gRPC.Server.csproj src/WC.Service.Employees.gRPC.Server/
COPY src/WC.Service.Employees.Domain/WC.Service.Employees.Domain.csproj src/WC.Service.Employees.Domain/
COPY src/WC.Service.Employees.Data.Abstractions/WC.Service.Employees.Data.Abstractions.csproj src/WC.Service.Employees.Data.Abstractions/
COPY src/WC.Service.Employees.Data.PostgreSql/WC.Service.Employees.Data.PostgreSql.csproj src/WC.Service.Employees.Data.PostgreSql/
COPY src/WC.Service.Employees.Data/WC.Service.Employees.Data.csproj src/WC.Service.Employees.Data/
COPY src/WC.Service.Employees.Domain.Abstractions/WC.Service.Employees.Domain.Abstractions.csproj src/WC.Service.Employees.Domain.Abstractions/

RUN dotnet restore src/WC.Service.Employees.gRPC.Server/WC.Service.Employees.gRPC.Server.csproj

COPY src/ .

WORKDIR /src/WC.Service.Employees.gRPC.Server
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WC.Service.Employees.gRPC.Server.dll"]

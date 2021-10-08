FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

WORKDIR /src
COPY *.sln ./
COPY FaultAlert/FaultAlert.csproj ./FaultAlert/
COPY FaultAlert.Console/FaultAlert.Console.csproj ./FaultAlert.Console/
RUN dotnet restore
COPY . .
WORKDIR /src/
RUN dotnet build -c Release -o /app
RUN dotnet publish -c Release -o /app
WORKDIR /app
ENTRYPOINT ["dotnet", "FaultAlert.Console.dll"]

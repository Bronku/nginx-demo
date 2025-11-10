FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY *.csproj .
RUN dotnet restore

COPY . .
CMD ["dotnet", "run"]

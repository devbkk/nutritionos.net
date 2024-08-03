# .NET Core SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Sets the working directory
WORKDIR /app

# Copy Projects
COPY src/NutriCare.Api/NutriCare.Api.csproj ./NutriCare.Api/
COPY src/NutriCare.Core/NutriCare.Core.csproj ./NutriCare.Core/
COPY src/NutriCare.InfraStructure/NutriCare.InfraStructure.csproj ./NutriCare.InfraStructure/

# .NET Core Restore
RUN dotnet restore ./NutriCare.Api/NutriCare.Api.csproj

# Copy All Files
COPY src ./

# .NET Core Build and Publish
RUN dotnet publish ./NutriCare.Api/NutriCare.Api.csproj -c Release -o /publish

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /publish ./

EXPOSE 80 5195 7066
ENV ASPNETCORE_URLS=http://+:5195;https://+:7066

ENTRYPOINT ["dotnet", "NutriCare.Api.dll"]

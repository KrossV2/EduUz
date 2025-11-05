# Use the official .NET SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the solution file and restore dependencies
COPY ["EduUz.sln", "."]
COPY ["EduUz.Application/EduUz.Application.csproj", "EduUz.Application/"]
COPY ["EduUz.Core/EduUz.Core.csproj", "EduUz.Core/"]
COPY ["EduUz.Infrastructure/EduUz.Infrastructure.csproj", "EduUz.Infrastructure/"]
COPY ["EduUz.Web/EduUz.Web.csproj", "EduUz.Web/"]
RUN dotnet restore "EduUz.sln"

# Copy the rest of the source code
COPY . .

# Build and publish the application
WORKDIR "/src/EduUz.Web"
RUN dotnet build "EduUz.Web.csproj" -c Release -o /app/build
RUN dotnet publish "EduUz.Web.csproj" -c Release -o /app/publish

# Use the official ASP.NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EduUz.Web.dll"]

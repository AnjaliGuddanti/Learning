# Start with the base .NET SDK image for Windows
FROM mcr.microsoft.com/dotnet/sdk:7.0-windowsservercore-ltsc2022 AS build

 

# Set the working directory inside the container
WORKDIR /app

 

# Set the EnableWindowsTargeting environment variable
ENV EnableWindowsTargeting=true

 

# Copy the project file(s) and restore dependencies
COPY *.csproj ./
RUN dotnet restore

 

# Copy the remaining source code
COPY . ./

 

# Build the application
RUN dotnet publish -c Release -o out

 

# Create a new image for the runtime environment
FROM mcr.microsoft.com/dotnet/runtime:7.0-windowsservercore-ltsc2022 AS runtime

 

# Set the working directory inside the container
WORKDIR /app

 

# Copy the published output from the build stage
COPY --from=build /app/out ./

 

# Set the entry point for the container
ENTRYPOINT ["dotnet", "winForm.dll"]
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
SHELL ["/bin/bash"]
RUN ["apt", "update"]
RUN ["apt", "install", "-y", "dos2unix"]

WORKDIR /app
COPY --from=build-env /app/out .

# Add wait-for-it
COPY wait-for-it.sh /app/wait-for-it.sh
RUN ["chmod", "+x", "wait-for-it.sh"]
RUN ["dos2unix", "wait-for-it.sh"]
COPY entrypoint.sh /app/entrypoint.sh
RUN ["chmod", "+x", "entrypoint.sh"]
RUN ["dos2unix", "entrypoint.sh"]

ENTRYPOINT /app/entrypoint.sh
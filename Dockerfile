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
WORKDIR /app
COPY --from=build-env /app/out .

# Add wait-for-it
COPY wait-for-it.sh wait-for-it.sh
RUN chmod +x wait-for-it.sh

# ENTRYPOINT [ "/bin/bash", "-c" ]
# CMD ["./wait-for-it.sh" , "db:80" , "--strict" , "--timeout=300" , "--" , "dotnet DotnetWebAPI.dll"]

ENTRYPOINT /bin/bash -c "/app/wait-for-it.sh db:80 --strict --timeout=300 -- dotnet /app/DotnetWebApi.dll"

# ENTRYPOINT ["dotnet", "DotnetWebAPI.dll"]
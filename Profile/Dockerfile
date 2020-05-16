#always run the build command from the solution folder.
#eg :podman build -f Profile/Dockerfile -t gcr.io/fluted-agency-265710/profile:alpha-v0.0.1 .

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
EXPOSE 80

COPY . ./
RUN dotnet publish Profile -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.4-alpine3.11
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Profile.dll"]

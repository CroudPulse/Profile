FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
# COPY ./Profile/Profile.csproj ./Profile
# COPY ./Profile.Entityframework/Profile.Entityframework.csproj ./Profile.Entityframework
# WORKDIR /app/Profile/
COPY . ./
RUN dotnet publish Profile -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Profile.dll"]
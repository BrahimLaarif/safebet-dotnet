# Build release image
FROM microsoft/dotnet:sdk AS build

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Safebet.WebAPI/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ./Safebet.WebAPI ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime AS runtime

WORKDIR /app

# Copy output to the work directory
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "Safebet.WebAPI.dll"]
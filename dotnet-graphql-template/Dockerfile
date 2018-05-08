FROM microsoft/dotnet:2.0-sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore -r linux-x64

# Copy everything else and build to out dir
COPY . ./
RUN dotnet publish -c Release -o out -r linux-x64

# Build runtime image
FROM microsoft/dotnet:2.0-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "dotnet-graphql-template.dll"]

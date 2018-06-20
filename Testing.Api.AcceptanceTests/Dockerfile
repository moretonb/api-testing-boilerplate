FROM microsoft/dotnet:2.1.300-sdk AS build-env
WORKDIR /app

COPY . .
RUN dotnet publish -c Release

ENTRYPOINT ["tail", "-f", "/dev/null"]
FROM microsoft/dotnet:2.1.300-sdk AS build-env
WORKDIR /app

COPY ./Testing.Boilerplate.Api.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1.0-aspnetcore-runtime
WORKDIR /app

COPY --from=build-env /app/out ./
ENTRYPOINT [ "dotnet", "Testing.Boilerplate.Api.dll" ]
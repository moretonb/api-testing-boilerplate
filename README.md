# api-testing-boilerplate
[![Build Status](https://travis-ci.org/moretonb/api-testing-boilerplate.svg?branch=master)](https://travis-ci.org/moretonb/api-testing-boilerplate)

To build/run api + dependencies:
```bash
docker-compose up -d --build
```
To spin down api + dependencies:
```bash
docker-compose down
```
Sample api request:
```bash
curl -i -d '{"ResponseCode":"200"}' -H "Content-Type: application/json" -X POST http://localhost:5000/api/respondwithcode
```
To run tests:
```bash
dotnet test
```
Useful commands to install NUnit project templates + make a new project
-----------------------------------------------------------------------
Install:
```bash
dotnet new -i NUnit3.DotNetNew.Template
```
Create:
```bash
dotnet new nunit
```
# api-testing-boilerplate
[![Build Status](https://travis-ci.org/moretonb/api-testing-boilerplate.svg?branch=master)](https://travis-ci.org/moretonb/api-testing-boilerplate)

To build/run api + dependencies: ```docker-compose up -d --build```

To spin down api + dependencies: ```docker-compose down```

Sample api request:
```bash
curl -i -d '{"ResponseCode":"200"}' -H "Content-Type: application/json" -X POST http://localhost:5000/api/respondwithcode
```
To run tests outside docker use ```dotnet test``` or the inbuilt test running in visual studio. Running the tests in a container is required for test statistics to be published. See the last section for details.

Useful commands to install NUnit project templates + make a new project
-----------------------------------------------------------------------
Install: ```dotnet new -i NUnit3.DotNetNew.Template```

Create: ```dotnet new nunit```

Accessing and setting up the Grafana UI
---------------------------------------
Once up the ui lives [here](http://localhost:3000). The default user/password is admin/admin.

The first thing to do is to set up the default datasouce. The url required is ```http://graphite```.

Once you have run the tests at least once statictics will be avaiable in ```stats.timers```. After that have fun making dashboards!

Running the tests
-----------------
To run the tests we execute dotnet test remotely. Substitute in the name of the image as required:
```bash
winpty docker exec -it api-testing-boilerplate_acceptance_1 dotnet test
```
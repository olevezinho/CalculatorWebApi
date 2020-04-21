# Calculator API

This project was built by following the helper guide on design patterns and principles by Phil japikse on microsoft's official youtube channel

*  [Link](https://www.youtube.com/watch?v=agkWYPUcLpg&list=PLHe0ejrMrA0NmggiJNtzGgPt6ITtYz16g) - This is the playlist I've followed 

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

```
git clone [projectLink]
```

See deployment for notes on how to deploy the project on a live system.

### Prerequisites

You will be needing docker if you need to run this project and dotnet core cli if you need to build it.

### Building the project

A step by step series of examples that tell you how to get a development env running

To build the solution:

```
dotnet build [solutionName]
```

End with an example of getting some data out of the system or using it for a little demo

## Running the tests

If you need to run the automated tests, just go for it! It's not that hard, you can find all the necessary information on microsoft's official documentation.

### Test purposes

These tests were to test the two methods found on the Calculator controller. One test, built with the help of TestServer, tests the POSt action. The other one tests the default GET method.
These tests can also be made with Postman or from the CLI.

```
dotnet test [testProjectName]
```

## Deployment

* [Docker hub](https://hub.docker.com/r/olevezinho/calculator) - The deployment is carefully described on my public Docker repository

## Built With

* [.NET Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2) - The web framework used
* [NuGet](https://www.nuget.org/) - Dependency Management
* [Nexus OSS Repository Manager](https://hub.docker.com/r/sonatype/nexus/tags) - Artifact Storage
* [Swagger](https://swagger.io/) - Used to generate a documented Web API
* [Docker](https://www.docker.com/) - Used to containerize the application

## Contributing

Please read [CONTRIBUTING.md](https://gitlab.com/Filipe_Costa) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Luis Filipe Costa Brochado** - *Initial work* - [Filipe Costa](https://gitlab.com/Filipe_Costa)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the UTAD document publishing License

## Acknowledgments

* Hat tip to anyone whose code was used
* [PurpleBooth] (https://gist.github.com/PurpleBooth/109311bb0361f32d87a2) - For the readme template
* Inspiration
* etc

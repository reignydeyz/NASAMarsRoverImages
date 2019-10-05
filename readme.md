# NASAMarsRoverImages

A web app that calls the Mars Rover API and selects a picture on a given day.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- [Visual Studio](https://www.visualstudio.com/)
- [Node.js](https://nodejs.org)
- [.Net Core SDK](https://dotnet.microsoft.com/download)

## People to blame

The following personnel is/are responsible for managing this project.

- [actchua@periapsys.com](mailto:actchua@periapsys.com)

## Developer's Guide

The project uses the default SPA template of ASP.Net Core.

### Technology Used

- [MVC Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/?view=aspnetcore-2.1)
- C#
- [.Net Core 2.2](https://www.microsoft.com/net/download/windows)
- [.Net Standard 2.0](#)
- [Angular 6](https://angular.io)

### Solution Structure

- NASAMarsRoverImages.Business
	- The Business Layer of the system
- NASAMarsRoverImages
	- The main web project

### Application Setting

#### appsettings.json
1. Create ```appsettings.json``` that contains your connection. Follow the format below and edit the parameter/s accordingly:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "NasaSettings": {
    "ApiUrl": "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos",
    "ApiKey": "[YOUR_API_KEY]"
  }
}

```

2. Place the setting inside ```NASAMarsRoverImages``` (web project)

#### dates.txt
1. Create ```dates.txt``` that contains the date parameters. There's no prefered format as long as it is a valid date...

Sample:
```
02/27/17
June 2, 2018
Jul-13-2016
April 31, 2018
```
(Values are separated by line)

2. Place ```dates.txt``` inside ```NASAMarsRoverImages\wwwroot``` (web project)

### Unit Test

// To follow

### Program Workflow

1. Once started, the program will fetch the ```dates.txt``` and validates the values and convert each of them into valid date format.
2. The program will pass the dates one by one to the NASA API then selects a specific photo.
3. The photos will be saved in ```NASAMarsRoverImages\wwwroot\nasa_imgs``` folder.
4. The page will render the photos saved.

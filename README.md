# LuxdoneProjekt


## ASP.NET Core 2.2 project

This service  allows to get currecy data from NBP external service.

## Prerequirements

* Visual Studio 2017
* .NET Core SDK

## How To Run
* Download solution
* Open solution in Visual Studio 2017
* Set .Web project as Startup Project and build the project.
* Run the application - press ISS Express 

## Using swagger get currency data 

* Swagger has been configured to manage application endpoints
* After starting the application, click on get endpoint (see screen bellow).

* ![image](https://user-images.githubusercontent.com/18561534/113942826-cc9a8500-9801-11eb-8478-5318295f862c.png)

* Click on "try it out" and fill parameters to get Currency data from NBP.

![image](https://user-images.githubusercontent.com/18561534/113943474-10da5500-9803-11eb-81ca-d434b567517a.png)

* Click on execute and get currency data.

## Alternatively you can insert the request into any browser

*https://localhost:{port}/api/Currency/EUR/2021-02-02/2021-02-03

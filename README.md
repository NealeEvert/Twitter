Project Name: Twitter
Developer: Neale Evert
Date Created: 2016/06/05

Overview
--------
This project was written to demonstrate the architecture of a system that incorporates testability, scalability and extensibility designs with SOLID principals in-mind. The design uses a Web API to be scalable and seperate the data extraction and logic away from any front end. It allows for the system to be consumed by any front end. The design uses Inversion of Control and Dependency Injection to be extensible and maintainable. This allows parts of the system to be easily replaced, for example the data layer.

The use of IoC and DI allows for the system to be tested by mocking out dependencies for predictable results to test unpredictable logic. Behaviour Driven Development concerns were also taken into account in the design of the presentation layer allowing for this part of the system to be tested with real world test cases.

The data layer was designed with a Repository pattern in mind with extensibility concerns taken into account with the file data source which could be switched out for an entity framework implementation on a relational database.

Technologies
------------
WebApi with MVC templating was used for the data presentation layer
DryIoC was used for Inversion of Control containers
NUnit was used for unit testing
Log4Net for logging
SpecFlow for behavioural testing

How to Run
----------
1. Open in Visual Studio 2015 - needs .Net Framework v4.5.2 (Nuget Packages will beed to be restored - should do this automatically on build)
2. Set the Twitter.Console project as Startup Project
3. Update the web.config in the Twitter.Web project
	a. Change UserDataFile to the path of the user.txt file
	b. Change TweetDataFile to the path of the tweet.txt file
4. Run the project
	a. If an error is displayed, check that:
		1. the file path is correct
		2. the port number for the IIS Express on the Twitter.Web project is the same as in the app.config appsetting value for the URL.
		
Assumptions
-----------
1. Assumption was made that is a user is being followed (in the data file) that user needs to be added to the list of users without any followers

Notes
-----
1. Unit testing and SpecFlow testing does not cover 100% of the code. Test are only written for the Twitter.Data.FlatFile as a demostration of the unit testing framework and architecture of the solution.
2. Code commenting is not extensive. Only in the Twitter.Data.FlatFile project as a demonstration of code comments.
3. Logging is not extensive. Only in the Twitter.Data.FlatFile project as a demonstration of logging.
4. No branching strategy was used in the project as it was not needed.
5. No build scripts created.
	

 


# PowerPlants
Solution that is used to store and retreive power plants

## Completion
### Functional
- [x] A power plant should be defined by the following fields
- [x] Create a GET API endpoint that retrieves all stored power plants as a JSON response
- [x] Create a POST API endpoint that adds a new power plant to the stored list
- [x] Filtering support for GET endpoint

### Non-fuctional
- [x] Use the latest stable version of .NET
- [x] Code should be stored on a git repository reachable by a shared URL
- [x] Use a relational database for persistence (SQL server)

### Bonus Requirements (nice to have)
- [x] Use EFCore
- [x] Add a unit test for the validation logic of the POST endpoint
- [x] Add paging to GET endpoint
- [x] Improve filtering to work with accented characters
- [x] Responses for Bad Request responses (POST endpoint) should include error descriptions of what went wrong

## How to run

### Create database

- Setup SQL Server with PowerPlantsDb database
- Run Migration: dotnet ef database update InitialMigration
- imply open the solution and run it as an HTTP application. The documentation (Swagger) should open automatically. If it doesn't, navigate to: http://localhost:5203/swagger/index.html
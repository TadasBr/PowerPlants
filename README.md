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
- [ ] Add paging to GET endpoint
- [x] Improve filtering to work with accented characters
- [x] Responses for Bad Request responses (POST endpoint) should include error descriptions of what went wrong

## How to run

### Docker
Go to solution directory PowerplantsAPI and run command: "docker-compose up --build"

### Manually
Create local sql server manually with credentials stored in PowerPlants.API/appsetings.json file.
start PowerPlants.API project with http and it should automatically run:
- ef migration to create database and table
- swagger in browser, otherwise go to http://localhost:5203/index.html


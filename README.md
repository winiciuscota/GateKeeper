# Gate Keeper

## Description

An Api to register and manage residents of a condominium

## Technologies used on this project

.Net Core 2.0  
Autofac  
Entity Framework  
Moq  
NUnit  
Sqlite

## Instructions

The following instructions are supposed to be used in a bash compatible shell

### Running the project

On the root directory, run:

- ./build.sh database update
- ./build.sh run

### Running unit tests

On the root directory, run:

- ./build.sh test

### Using the Api

#### Authentication

This api uses Basic Authentication. All the requests must contain an Authorization header with the content "Basic {username}:{password}". The username and password can be changed in the file appsettings.json.

#### Registering a new resident
In order to register a new resident send an post request to /api/residents with the json data for the resident as: <br />
```json
{
	"name":"John Cena",
	"email":"john.cena@gmail.com",
	"phone":"232323",
	"cpf":"22323",
	"block": "B",
	"apartment": "301"
}
```

#### Editing a resident
To edit a resident send an put request to /api/residents/{resident-id} where {resident-id} is the id of the resident you want ot edit. The new data for the resident must be passed in the request body.

#### Retrieving residents

To retrieve a single resident make a get request to /api/residents/{resident-id}, where resident-id is the id of the resident.

To retrieve a list of residents make a request to /api/residents.  You can also filter the residents by name, email, block and apartment.  
eg: if you want to get all the residents which have the string john in their name make an get request with the url /api/residents/?name=john.

#### Deleting residents
To delete a single resident make a delete request to /api/residents/{resident-id} where {resdient-id} is the id of the resident you want to remove.










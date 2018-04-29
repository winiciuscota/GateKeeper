# Gate Keeper

## Description

An Api to register and manage residents of a condominium

## Technologies used on this project

.Net Core 2.0  
Autofac  
Entity Framework  
Mock  
NUnit  
Sqlite

## Instructions

The following instructions are supposed to be used in a bash compatible shell

### Running the project

On the root directory, run:

- ./build.sh database update
- ./build.sh watch

### Running unit tests

On the root directory, run:

- ./build.sh test

### Using the Api

#### Registering a new resident
In order to register a new resident send an post request to <ip-address>:<port-number>/api/residents with the json data for the resident as: <br />
```json
{
	"name":"John Cena",
	"email":"john.cena@gmail.com",
	"phone":"232323",
	"cpf":"22323"
}
```


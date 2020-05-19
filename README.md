# settingsApi

## About
A REST API where we can request all configurations available. Configurations are
stored in JSON and keyed by an alphanumeric identifier such as “FullStackDeveloperSettings”.

### The API has the following endpoints:
* An endpoint to list all configurations available.
* An endpoint to retrieve the contents of a single configuration
* An endpoint to retrieve the contents of 2 configurations merged i.e. “FullStackDeveloperSettings” contents is merged with the contents of
“WebDeveloperSettings”.

### JSON
* The structure of the JSON files is dynamic.
* The JSON files are stored in the Resources folder.

## Test using Swagger UI
```https://localhost:5001/swagger/index.html```

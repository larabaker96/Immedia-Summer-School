# Immedia-Summer-School

## Description

This repository consists of a movie API made in my week at Summer School at Immedia. 
It has features for adding a movie and its actors', editing a movie and adding more actors, 
pulling a list of movies, searching the movies by actor or movie name, and deleting a movie.

## Usage

This API currently runs on a localhost server. The API url currently is: https://localhost:5001/api/Movies

### Getting a movie by ID url / Editing a movie url

"https://localhost:5001/api/Movies/" + [yourIDVariableInt]

### Searching for a movie url

"https://localhost:5001/api/Movies/Search?query=" + [yourQueryString]

## JSON Format

```json

  {
    "movieName":"string",
    "description":"string",
    "movieGenre":"string",
    "releaseDate":"dd/mm/yyyy",
    "ageRestriction":"string",
    "topActors": [{"actorName": "string"},{"actorName": "string"}]
  }
```

## Contributions

A big thank you to Oliver Dipple who helped me during my week at Summer School who gave me great suggestions and who helped me when I was stuck.

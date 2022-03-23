# rischy.chemical-handler

Spin up a local Mongo:

Application runs against local mongo container.

```bash
docker run -d -p 27017:27017 mongo
```

Connection string:
```bash
mongodb://localhost:27017
```

Useful endpoints:

```
https://localhost:3002/hazards?ids=NjIzMzU0ZmEzZGU4MTM5ZjYzY2FjNTQ1LDYyMzRhMGFjM2RlODEzOWY2M2NhYzU1Yw==
https://localhost:3002/all-hazards
```

TODO: Method to insert data.
Future service that has 2 methods : 
  - (GET) /api/futureclient - calculate & returns the difference between quarterly futures and writes the result to the db (postgres)
  - (GET) /api/futureclient/get-all-fd - returns all calculated values (serves simply to check that the record has been added to the db)

# api-testing-boilerplate
docker-compose up
docker-compose down

curl -i -d '{"ResponseCode":"200"}' -H "Content-Type: application/json" -X POST http://localhost:5000/api/respondwithcode
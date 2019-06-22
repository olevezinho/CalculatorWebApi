#!/bin/sh
# requests.sh

curl -X GET "http://localhost:8123/api/Calc" -H "accept: application/json"
curl -i -d -XPOST "http://localhost:8123/api/Calc/add/1/1" -H "accept: application/json"
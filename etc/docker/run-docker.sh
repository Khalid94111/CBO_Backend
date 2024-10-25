#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p 9b945508-8aae-4122-b6f1-51cfa414649a -t
    fi
    cd ../
fi

docker-compose up -d

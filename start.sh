#!/bin/bash

# if zip is not yet installed then install it
if ! command -v zip
then
    sudo apt-get install zip -y
fi

# extract data.zip 
cd ./database.sql
sudo unzip data.zip
sudo rm data.zip
cd ..

# Set database permissions
sudo chmod 775 ./database.sql/data -R
sudo chown 999:tim ./database.sql/data
sudo chown 999:999 ./database.sql/data/* -R

# startup docker containers
docker-compose up
docker-compose down -v --rmi all

# create docker container
cd ./database.sql
sudo zip -r ./data.zip ./data/
sudo rm -r ./data
cd ..

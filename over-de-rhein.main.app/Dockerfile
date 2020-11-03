FROM node:12.19.0-stretch

# set environment variables
ENV DBPassword=empty
ENV DBUsername=empty
ENV DBHost=empty
ENV DBName=empty
ENV port=3001
ENV LOGIN_DEV=production

# copy all contents into the imag
COPY ./app /app

# change dir to the website location
WORKDIR /app

# Install node_modules
#RUN [ "npm", "install", "--save" ]

# Run the website
ENTRYPOINT [ "npm", "start" ]
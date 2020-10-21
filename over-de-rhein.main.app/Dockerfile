FROM node:12.19.0-stretch

# copy all contents into the imag
COPY ./app /app

# change dir to the website location
WORKDIR /app

# Install node_modules
#RUN [ "npm", "install", "--save" ]

# Run the website
ENTRYPOINT [ "npm", "start" ]
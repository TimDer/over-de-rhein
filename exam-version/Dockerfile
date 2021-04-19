# Use ubuntu as a base image
FROM ubuntu:20.04

# Update base image
RUN apt-get update -y
RUN apt-get upgrade -y

# set time sone
ENV timezone=UTC
RUN echo $timezone > input.txt
RUN apt-get install -y tzdata < input.txt
RUN rm input.txt

# Install PHP
RUN apt-get install php7.4 \
                    libapache2-mod-php7.4 \
                    php7.4-mysql -y

# Install apache2
RUN apt-get install -y apache2 && \
    a2enmod rewrite && \
    rm /var/www/html/index.html

# delete cache
RUN rm -fr /var/cache/*

# run apache in the foreground
CMD apachectl -D FOREGROUND
CREATE DATABASE curso_backend;

use curso_backend;

CREATE TABLE WeatherForecasts(
	id int not null primary key,
    date_weather date,
    temperatureC int,
    temperatureF int,
    summary varchar(15)
);

 INSERT INTO WeatherForecasts(id, date_weather, temperatureC, temperatureF, summary) values 
 (1, "2023-12-19", "15", "59", "Cool"),
 (2, "2023-12-25", "9", "48", "Chilly"),
 (3, "2023-12-30", "5", "41", "Bracing");
 
 select * from WeatherForecasts;

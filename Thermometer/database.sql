DROP TABLE IF EXISTS log;

CREATE TABLE log(
    temp NUMERIC,
    humi NUMERIC,
    co2 NUMERIC,
    timestamp NUMERIC PRIMARY KEY 
);
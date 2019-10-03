
/* 
-----------------------------------------------------------------------
Heroku cloud database info
-----------------------------------------------------------------------
Host
    ec2-54-235-181-55.compute-1.amazonaws.com
Database
    d8ig910bf2pdj5
User
    vlkjlyefplkbne
Port
    5432
Password
    18d054f18a5e00f4185ffd5f0c97d11850b699d8edc7aa0d4a7b2424f23f67cd
URI
    postgres://vlkjlyefplkbne:18d054f18a5e00f4185ffd5f0c97d11850b699d8edc7aa0d4a7b2424f23f67cd@ec2-54-235-181-55.compute-1.amazonaws.com:5432/d8ig910bf2pdj5
Heroku CLI
    heroku pg:psql postgresql-rigid-75809 --app sharespace-capstone
-----------------------------------------------------------------------
Heroku cloud database setup
-----------------------------------------------------------------------
Set up PATH:
    C:\Program Files\PostgreSQL\11\bin

Connect to heroku postgres app:
    heroku pg:psql --app sharedspace-capstone 

Some PSQL commands:
    \d
    \d room
    \dt
-----------------------------------------------------------------------
*/

CREATE TABLE room (roomID SERIAL, roomName text, roomDescription text, roomType text);

INSERT INTO room (roomName, roomDescription, roomType) VALUES ('ADMIN', 'Admin', 'public');
INSERT INTO room (roomName, roomDescription, roomType) VALUES ('room_a', 'Admin', 'public');
INSERT INTO room (roomName, roomDescription, roomType) VALUES ('room_b', 'Admin', 'public');
INSERT INTO room (roomName, roomDescription, roomType) VALUES ('room_c', 'Admin', 'private');
INSERT INTO room (roomName, roomDescription, roomType) VALUES ('room_d', 'Admin', 'private');
INSERT INTO room (roomName, roomDescription, roomType) VALUES ('room_e', 'Admin', 'public');
INSERT INTO room (roomName, roomDescription, roomType) VALUES ('room_f', 'Admin', 'public');
INSERT INTO room (roomName, roomDescription, roomType) VALUES ('room_g', 'Admin', 'private');

SELECT * FROM room;


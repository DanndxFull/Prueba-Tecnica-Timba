CREATE DATABASE unitydb;
use unitydb;

CREATE TABLE players(
    namePlayer VARCHAR(255) NOT NULL,
    scorePlayer integer NOT NULL
);

INSERT INTO players (namePlayer, scorePlayer)
VALUES
('Juan', 5),
('Jose', 8);
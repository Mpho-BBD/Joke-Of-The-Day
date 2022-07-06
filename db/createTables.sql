CREATE TABLE Joke (
	jokeId INT UNSIGNED auto_increment NOT NULL,
	content varchar(280) NOT NULL,
	inappropriate BIT NOT NULL,
	CONSTRAINT Joke_PK PRIMARY KEY (jokeId)
);

CREATE TABLE JokeOfTheDay (
  jokeOfTheDayId INT UNSIGNED auto_increment NOT NULL,
  dayDate dateTime NOT NULL,
  jokeId INT UNSIGNED NOT NULL,
  CONSTRAINT JokeOfTheDay_PK PRIMARY KEY (jokeOfTheDayId)
);

ALTER TABLE JokeOfTheDay ADD FOREIGN KEY (JokeId) REFERENCES Joke (JokeId);


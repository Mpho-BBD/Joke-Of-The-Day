CREATE TABLE [Joke] (
  [jokeId] int PRIMARY KEY IDENTITY(1, 1),
  [content] varchar(280),
  [inappropriate] bit
)
GO

CREATE TABLE [JokeOfTheDay] (
  [jokeOfTheDayId] int PRIMARY KEY IDENTITY(1, 1),
  [day] dateTime,
  [jokeId] int
)
GO

ALTER TABLE [JokeOfTheDay] ADD FOREIGN KEY ([JokeId]) REFERENCES [Joke] ([JokeId])
GO

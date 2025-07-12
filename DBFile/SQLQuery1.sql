--use master 
--go
--alter database [MovieRR_Database] set single_user with rollback immediate
--drop database MovieRR_Database
--go
--create database MovieRR_Database
--use MovieRR_Database
--go


-- this table holds all the directors
create table DirectorsTable(
	DirectorID int identity (1,1) not null primary key,	--DirectorID starts at 1 and goes up by 1 for each director
	DirectorName varchar(255) not null
	)
-- heres where the genres for movies are being put
create table GenreTable(
	GenreID int identity (1,1) not null primary key,
	Genre varchar(255) not null -- holds the name of the genre
	)

	-- diifferent age ratings for movies
create table AgeRatingsTable(
	AgeRatingID int identity (1,1) not null primary key, 
	AgeRating varchar(50) not null unique
	)

	-- holds all the movies, each movie has a title, director, genre, age rating
create table MoviesTable(
	MovieID int identity (1,1) not null primary key,
	MovieTitle varchar(255) not null, -- title
	DirectorID int not null foreign key references DirectorsTable(DirectorID), -- linking to DirectorsTable
	GenreID int not null foreign key references GenreTable(GenreID), -- linking to GenreTable
	ReleaseYear int not null,  -- the yr the movie was released
	AgeRatingID int not null foreign key references AgeRatingsTable(AgeRatingID), -- linking to AgeRatings table
	UNIQUE(MovieTitle, DirectorID, ReleaseYear)
	)

	-- store the ratings for each movie from IMDb and Rotten Tomatoes
create table RatingsTable(
	RatingID int identity (1,1) not null primary key,
	MovieID int not null foreign key references MoviesTable(MovieID), -- linking to MoviesTable
	IMDbRating float not null, -- IMDb rating of the movie
	RottenTomatoesRating float not null -- rottentomatoes rating of the movie

	-- I used 'float' for IMDbRating and RottenTomatoesRating because they need to store decimal numbers, like 8.3 or 7.5, instead of just whole numbers.
	)


-- adding data
INSERT INTO DirectorsTable (DirectorName) 
VALUES
('Christopher Nolan'), 
('Quentin Tarantino'), 
('Steven Spielberg'), 
('Martin Scorsese'), 
('James Cameron'), ('Ridley Scott'), ('Peter Jackson'), ('Francis Ford Coppola'), 
('Stanley Kubrick'), ('David Fincher'), ('Alfred Hitchcock'), ('Tim Burton'), 
('Guillermo del Toro'), ('Greta Gerwig'), ('Denis Villeneuve'), ('Paul Thomas Anderson'), 
('Wes Anderson'), ('Bong Joon-ho'), ('Jordan Peele'), ('Taika Waititi'), ('Robert Zemeckis'), 
('Coen Brothers'), ('George Lucas'), ('Spike Lee'), ('Clint Eastwood'), ('John Carpenter'), 
('Sam Raimi'), ('M. Night Shyamalan'), ('Lana Wachowski'), ('Lilly Wachowski'), 
('Patty Jenkins'), ('Bryan Singer'), ('Zack Snyder'), ('Jon Favreau'), ('J.J. Abrams'), 
('James Gunn'), ('Luc Besson'), ('Matthew Vaughn'), ('Edgar Wright'), ('David Lynch'), 
('Woody Allen'), ('Yorgos Lanthimos'), ('Alejandro González Iñárritu'), ('Rian Johnson'), 
('Guy Ritchie'), ('Akira Kurosawa'), ('Hayao Miyazaki'), ('Makoto Shinkai'), 
('Hirokazu Koreeda'), ('Satoshi Kon'), ('Richard Linklater'), ('Gore Verbinski'), 
('Jean-Pierre Jeunet'), ('Kathryn Bigelow'), ('David O. Russell'), ('Lars von Trier'), 
('Gaspar Noé'), ('Terrence Malick'), ('Spike Jonze'), ('Darren Aronofsky'), 
('Robert Eggers'), ('Ari Aster'), ('Mike Flanagan'), ('James Wan'), ('Adam McKay'), 
('Kevin Smith'), ('Nancy Meyers'), ('Catherine Hardwicke'), ('Sofia Coppola'), 
('Luca Guadagnino'), ('Pedro Almodóvar'), ('Takashi Miike'), ('Ken Loach'), 
('Harmony Korine'), ('David Cronenberg'), ('Peter Weir'), ('Frank Darabont'), 
('Doug Liman'), ('Justin Lin'), ('Sam Mendes'), ('Paul Greengrass'), ('Ang Lee'), 
('Oliver Stone'), ('Michael Mann'), ('Ron Howard'), ('Rob Reiner'), ('John Woo'), 
('Barbra Streisand'), ('Mel Gibson'), ('Robert Rodriguez'), ('Baz Luhrmann'), 
('Kenneth Branagh'), ('Brett Ratner'), ('Shawn Levy'), ('Gareth Edwards'), 
('Chris Columbus'), ('Stephen Daldry'), ('Gus Van Sant'), ('Jonathan Demme'), 
('Michel Gondry'), ('Danny Boyle'), ('Ruben Fleischer'), ('George Miller'), 
('Brad Bird'), ('Lee Unkrich');


INSERT INTO GenreTable (Genre) VALUES
('Action'), ('Adventure'), ('Animation'), ('Biography'), ('Comedy'), ('Crime'), ('Drama'), ('Documentary'), ('Fantasy'), ('Horror'),
('Mystery'), ('Romance'), ('Sci-Fi'), ('Thriller'), ('Western'), ('Musical'), ('Sports'), ('War'), ('Superhero'), ('Historical'),
('Family'), ('Psychological Thriller'), ('Political Drama'), ('Dark Comedy'), ('Silent Film'), ('Noir'), ('Experimental'),
('Cyberpunk'), ('Steampunk'), ('Martial Arts'), ('Zombie'), ('Paranormal'), ('Dystopian'), ('Apocalyptic'), ('Slasher'),
('Satire'), ('Mockumentary'), ('Survival'), ('Spy'), ('Legal Drama'), ('Epic'), ('Coming-of-Age'), ('Teen Drama'),
('LGBTQ+'), ('Road Movie'), ('Heist'), ('Period Drama'), ('Folklore'), ('Mythology'), ('Religious'), ('Science Fiction Horror'),
('Arthouse'), ('Neo-Noir'), ('Political Thriller'), ('Anthology'), ('Chick Flick'), ('Psychodrama'), ('Action Thriller'),
('Supernatural'), ('Space Opera'), ('Revenge'), ('Magical Realism'), ('Alien Invasion'), ('Vampire'), ('Werewolf'),
('Post-Apocalyptic'), ('Time Travel'), ('Disaster'), ('Found Footage'), ('Clown Horror'), ('Lovecraftian'), ('Social Commentary'),
('Parody'), ('Historical Fantasy'), ('Urban Fantasy'), ('Folk Horror'), ('Experimental Horror'), ('Gothic Horror'),
('Space Western'), ('Alternate History'), ('Gangster'), ('Courtroom Drama'), ('Hard Sci-Fi'), ('Science Fantasy'),
('Psychological Horror'), ('Slapstick Comedy'), ('Giallo'), ('Tokusatsu'), ('Body Horror'), ('Satirical Horror'),
('Jidaigeki'), ('Yakuza'), ('Sports Drama'), ('Anime'), ('Mecha'), ('Kaiju'), ('Samurai'), ('Prison Drama'),
('Fairy Tale'), ('Cryptid Horror'), ('Medical Drama'), ('Nature Horror'), ('Feminist Film'), ('Existentialist Film');


-- Inserting 100 rows into AgeRatings
INSERT INTO AgeRatingsTable (AgeRating) VALUES
('G'), ('PG'), ('PG-13'), ('R'), ('NC-17')

INSERT INTO MoviesTable (MovieTitle, DirectorID, GenreID, ReleaseYear, AgeRatingID ) VALUES
('Inception', 1, 13, 2010, 3), 
('Pulp Fiction', 2, 6, 1994, 3), 
('Jaws', 3, 10, 1975, 3),
('The Irishman', 4, 7, 2019, 3),
('Avatar', 5, 14, 2009, 3), 
('Alien', 6, 11, 1979, 3),
('The Lord of the Rings', 7, 9, 2001, 3), 
('The Godfather', 8, 6, 1972, 3), 
('The Shining', 9, 10, 1980, 3),
('Fight Club', 10, 7, 1999, 3), 
('Psycho', 11, 10, 1960, 3), 
('Edward Scissorhands', 12, 3, 1990, 3);




-- Inserting 100 rows into RatingsTable

INSERT INTO RatingsTable (MovieID, IMDbRating, RottenTomatoesRating)
VALUES
(1, 8, 86), 
(2, 9, 92), 
(3, 8, 91), 
(4, 9, 96), 
(5, 7, 89), 
(6, 7, 88), 
(7, 8, 84), 
(8, 8, 98), 
(9, 7, 96), 
(10, 8, 87),
(11, 9, 97),
(12, 8, 90)



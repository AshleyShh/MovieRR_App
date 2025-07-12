Use [MovieRR_Database]
Go
if exists (select * from sys.procedures where type = 'P' and name = 'get_movie_list_for_a_given_year_proc') 
	begin
		drop procedure dbo.get_movie_list_for_a_given_year_proc
	end
Go

create procedure dbo.get_movie_list_for_a_given_year_proc (@ReleaseYear int)
as
begin

--Validate if the ReleaseYear passed by the user is valid)
if (@ReleaseYear <= 0 OR @ReleaseYear is null)
begin 
	raiserror('Invalid value for a Release Year of a Movie', 18, 1);
end

select MoviesTable.MovieTitle,
		DirectorsTable.DirectorName,
		GenreTable.Genre,
		AgeRatingsTable.AgeRating,
		MoviesTable.ReleaseYear
from dbo.MoviesTable
join dbo.DirectorsTable on MoviesTable.DirectorID = DirectorsTable.DirectorID
join dbo.GenreTable on MoviesTable.GenreID = GenreTable.GenreID
join dbo.AgeRatingsTable on MoviesTable.AgeRatingID = AgeRatingsTable.AgeRatingID
where ReleaseYear = @ReleaseYear


end

go
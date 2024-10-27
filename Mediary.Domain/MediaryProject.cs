using System.Text.Json;
using Ardalis.Result;
using Mediary.Domain.Dtos;
using Mediary.Domain.Games;

namespace Mediary.Domain;

public class MediaryProject : Entity<MediaryProjectDto>
{
	public IReadOnlyList<Game> Games => _games;

	private MediaryProject(string filePath)
	{
		_filePath = filePath;
	}

	public static Result<MediaryProject> TryCreate(string filePath)
	{
		return new MediaryProject(filePath);
	}

	private readonly string _filePath;
	private readonly List<Game> _games = [];

	public override MediaryProjectDto ToDto()
	{
		return new MediaryProjectDto
		{
			Id = Id,
			Games = _games.Select(x => x.ToDto()).ToList()
		};
	}

	public override void FromDto(MediaryProjectDto dto)
	{
		Id = dto.Id;
		foreach (var gameDto in dto.Games)
		{
			var game = new Game();
			game.FromDto(gameDto);
			_games.Add(game);
		}
	}

	public async Task<Result> SaveAsync()
	{
		await using var stream = new FileStream(_filePath, FileMode.Create);
		await JsonSerializer.SerializeAsync(stream, ToDto());
		return Result.Success();
	}
}
using System.Text.Json;
using Ardalis.Result;
using Mediary.Domain.Dtos;

namespace Mediary.Domain;

public class MediaryProject : Entity<MediaryProjectDto>
{
	private MediaryProject(string filePath)
	{
		_filePath = filePath;
	}

	public static Result<MediaryProject> TryCreate(string filePath)
	{
		return new MediaryProject(filePath);
	}

	private readonly string _filePath;
	
	public override MediaryProjectDto ToDto()
	{
		return new MediaryProjectDto
		{
			Id = Id
		};
	}

	public override void FromDto(MediaryProjectDto dto)
	{
		Id = dto.Id;
	}

	public async Task<Result> SaveAsync()
	{
		await using var stream = new FileStream(_filePath, FileMode.Create);
		await JsonSerializer.SerializeAsync(stream, ToDto());
		return Result.Success();
	}
}
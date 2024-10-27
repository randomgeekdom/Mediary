namespace Mediary.Domain.Dtos;

public class MediaryProjectDto:EntityDto
{
	public IEnumerable<GameDto> Games { get; set; } = [];
}
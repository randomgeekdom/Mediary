using Mediary.Domain.Games;

namespace Mediary.Domain.Dtos;

public class GameDto : EntityDto
{
	public GameMedium Medium { get; set; }
	public string Name { get; set; }
}
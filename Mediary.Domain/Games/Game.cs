using Mediary.Domain.Dtos;

namespace Mediary.Domain.Games;

public class Game : Entity<GameDto>
{
	public string Name { get; set; }
	public GameMedium Medium { get; private set; }
	public override GameDto ToDto()
	{
		return new GameDto
		{
			Id = Id,
			Medium = Medium,
			Name = Name
		};
	}

	public override void FromDto(GameDto dto)
	{
		this.Id = dto.Id;
		this.Medium = dto.Medium;
		this.Name = dto.Name;
	}
}
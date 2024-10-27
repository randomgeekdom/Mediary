using Mediary.Domain;

namespace Mediary.ViewModels;

public class PlayedViewModel : ViewModelBase
{
	private readonly MediaryProject _project;

	public PlayedViewModel(MediaryProject project)
	{
		_project = project;
	}

	public override string Name => "Played";
}
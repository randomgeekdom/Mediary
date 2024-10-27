using CommunityToolkit.Mvvm.ComponentModel;
using Mediary.Domain;

namespace Mediary.ViewModels;

public partial class PlayedViewModel : ViewModelBase
{
	[ObservableProperty] private MediaryProject _project;

	public PlayedViewModel(MediaryProject project)
	{
		_project = project;
	}

	public override string Name => "Played";
}
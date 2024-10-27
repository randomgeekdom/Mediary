using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mediary.Domain;

namespace Mediary.ViewModels;

public partial class PlayedViewModel : ViewModelBase
{
	[ObservableProperty] private MediaryProject _project;
	[ObservableProperty] private bool _showAddGame;
	[ObservableProperty] private bool _showAddButton = true;
	[ObservableProperty] private AddGameViewModel _addGameViewModel;
	[ObservableProperty] private RelayCommand _showAddCommand;

	/// <inheritdoc/>
	public PlayedViewModel(MediaryProject project)
	{
		_project = project;
		_addGameViewModel = new AddGameViewModel(project);
		ShowAddCommand = new RelayCommand(ShowAdd);
	}


	private void ShowAdd()
	{
		ShowAddGame = true;
		ShowAddButton = false;
	}
	
	public override string Name => "Played";
}
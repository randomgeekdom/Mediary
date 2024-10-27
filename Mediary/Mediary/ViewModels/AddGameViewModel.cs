using CommunityToolkit.Mvvm.ComponentModel;
using Mediary.Domain;

namespace Mediary.ViewModels;

public partial class AddGameViewModel(MediaryProject project) : ViewModelBase
{
	[ObservableProperty] private MediaryProject _project = project;

	public override string Name { get; } = "Add Game";
}
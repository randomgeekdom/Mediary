using CommunityToolkit.Mvvm.ComponentModel;

namespace Mediary.ViewModels;

public abstract class ViewModelBase : ObservableObject
{
	public abstract string Name { get; }

	public override string ToString()
	{
		return Name;
	}
}
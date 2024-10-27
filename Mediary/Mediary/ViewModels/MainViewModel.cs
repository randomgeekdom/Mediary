using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Mediary.Domain;

namespace Mediary.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _greeting = "Welcome to Avalonia!";
    [ObservableProperty] private MediaryProject? _mediaryProject;
    [ObservableProperty] private ViewModelBase? _currentViewModel;
    [ObservableProperty] private ObservableCollection<ViewModelBase> _viewModels = [];
    
    public bool IsProjectLoaded => MediaryProject is not null;
    public bool IsProjectNotLoaded => MediaryProject is null;


    public void SetProject(MediaryProject project)
    {
        MediaryProject = project;
        
        ViewModels.Clear();
        ViewModels.Add(new PlayedViewModel(MediaryProject));
        ViewModels.Add(new SettingsViewModel());
        
        OnPropertyChanged(nameof(IsProjectLoaded));
        OnPropertyChanged(nameof(IsProjectNotLoaded));
    }

    public override string Name => "Main";
}
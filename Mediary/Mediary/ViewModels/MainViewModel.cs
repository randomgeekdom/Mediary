using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Mediary.Domain;

namespace Mediary.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _greeting = "Welcome to Avalonia!";
    [ObservableProperty] private MediaryProject? _mediaryProject;
    
    public bool IsProjectLoaded => MediaryProject is not null;
    public bool IsProjectNotLoaded => MediaryProject is null; 
    
    public TestViewModel TestViewModel { get; } = new TestViewModel();

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(MediaryProject))
        {
            OnPropertyChanged(nameof(IsProjectLoaded));
            OnPropertyChanged(nameof(IsProjectNotLoaded));
        }
        base.OnPropertyChanged(e);
    }
}

public class TestViewModel : ViewModelBase{}
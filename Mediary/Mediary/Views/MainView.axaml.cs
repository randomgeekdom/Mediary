using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using Mediary.Domain;
using Mediary.Domain.Dtos;
using Mediary.ViewModels;

namespace Mediary.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private async  void Load_OnClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is MainViewModel vm)
        {
            // Get top level from the current control. Alternatively, you can use Window reference instead.
            var topLevel = TopLevel.GetTopLevel(this);

            if(topLevel is null) return;
            
            // Start async operation to open the dialog.
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Load Project",
                AllowMultiple = false,
                FileTypeFilter = [new FilePickerFileType("Mediary Project"){Patterns = ["*.mdry"] }]
            });

            if (files.Count < 1) return;
            // Open reading stream from the first file.
            await using var stream = await files[0].OpenReadAsync();
            var project = await JsonSerializer.DeserializeAsync<MediaryProjectDto>(stream);

            var entity = MediaryProject.TryCreate(files[0].Path.AbsolutePath).Value;
            if (project != null) entity.FromDto(project);

            vm.SetProject(entity);
        }
    }
    

    private async  void Create_OnClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is not MainViewModel vm) return;
        // Get top level from the current control. Alternatively, you can use Window reference instead.
        var topLevel = TopLevel.GetTopLevel(this);

        if(topLevel is null) return;

        var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Save Project",
            FileTypeChoices = [new FilePickerFileType("Mediary Project"){  Patterns = ["*.mdry"] }],
        });

        if (file == null) return;
        var project = MediaryProject.TryCreate(file.Path.AbsolutePath).Value;

        await using var stream = await file.OpenWriteAsync();
        await JsonSerializer.SerializeAsync(stream, project);

        vm.SetProject(project);
    }
}
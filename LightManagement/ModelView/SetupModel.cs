using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace LightManagement.ModelView;

public class SetupModel : INotifyPropertyChanged
{
    public string SelectedSystem { get; set; }
    public ICommand NextCommand { get; private set; }

    public SetupModel()
    {
        NextCommand = new Command(async () => await Next());
    }


    private async Task Next()
    {
        MainThread.BeginInvokeOnMainThread(async () => { await Shell.Current.GoToAsync("//MainPage"); });
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
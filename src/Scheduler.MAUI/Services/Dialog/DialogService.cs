using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Scheduler.MAUI.Services.Dialog;

public class DialogService : IDialogService
{
    public Task ShowAlertAsync(string message, string title, string buttonLabel)
    {
        return Shell.Current.DisplayAlert(title, message, buttonLabel);
    }
}
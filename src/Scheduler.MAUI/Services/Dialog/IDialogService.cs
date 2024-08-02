using System.Threading.Tasks;

namespace Scheduler.MAUI.Services.Dialog;

public interface IDialogService
{
    Task ShowAlertAsync(string message, string title, string buttonLabel);
}

using Microsoft.Maui.Controls;
using Scheduler.MAUI.ViewModels.Login;

namespace Scheduler.MAUI.Pages.Login;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}
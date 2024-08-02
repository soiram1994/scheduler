using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentResults;
using Scheduler.MAUI.Services.AppEnvironment;
using Scheduler.MAUI.Services.Navigation;
using Scheduler.MAUI.Validations;
using Scheduler.MAUI.ViewModels.Base;

namespace Scheduler.MAUI.ViewModels.Login
{
    public partial class LoginPageViewModel : ViewModelBase
    {
        [ObservableProperty] private ValidatableObject<string> _username;
        [ObservableProperty] private ValidatableObject<string> _password;

        public LoginPageViewModel(
            INavigationService navigationService,
            IAppEnvironmentService environmentService) : base(
            navigationService, environmentService)
        {
            var username = environmentService.SettingsService.Get<string>("Username") ?? string.Empty;
            _username = new ValidatableObject<string>()
            {
                Value = username
            };
            _username.Validations.Add(new IsNotNullOrEmptyRule<string>()
            {
                ValidationMessage = $"{nameof(Username)} cannot be empty."
            });
            _password = new ValidatableObject<string>();
            _password.Validations.Add(new IsNotNullOrEmptyRule<string>()
            {
                ValidationMessage = $"{nameof(Password)} cannot be empty."
            });
        }

        [RelayCommand]
        private async Task LoginAsync()
        {
            // Validate username and password
            Username.Validate();
            Password.Validate();
            if (Username.IsInvalid && Password.IsInvalid)
            {
                var message = $"Username Errors{Username.Errors}" +
                              $"{Environment.NewLine}Password Errors:{Password.Errors}";
                await EnvironmentService.DialogService.ShowAlertAsync(message, "Login Error", "Ok");
                return;
            }

            // Login
            var loggedIn = await EnvironmentService.IdentityService.SignInAsync();
            if (!loggedIn)
            {
                await EnvironmentService.DialogService.ShowAlertAsync("Invalid username or password", "Login Error",
                    "Ok");
            }

            // After login save username
            var userSavedResult = SaveUserInfo();
            if (userSavedResult.IsFailed)
            {
                await EnvironmentService.DialogService.ShowAlertAsync("Failed to save user info", "Login Error", "Ok");
                return;
            }

            // Navigate to main page
            await NavigationService.NavigateToAsync("//MainPage");
        }

        private Result SaveUserInfo()
        {
            var username = Username.Value;
            EnvironmentService.SettingsService.Set("Username", username);
            return Result.Ok();
        }
    }
}
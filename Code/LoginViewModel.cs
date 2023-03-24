using AFPS_App.Views;
using Xamarin.Forms;
using AFPS_App.Services;

namespace AFPS_App.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Email;
        string _Contraseña;
        #endregion

        #region CONSTRUCTOR
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }
        #endregion

        #region OBJETOS
        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
        }

        public string Contraseña
        {
            get { return _Contraseña; }
            set { SetProperty(ref _Contraseña, value); }
        }
        #endregion

        #region PROCESOS
        // Método para iniciar sesión
        public async void OnLoginClicked(object obj)
        {
            // Variables para el inicio de sesión
            var userService = new UserService(); // Instancia de UserService
            var isLoggedIn = await userService.LoginAsync(Email, Contraseña); // Llama al método LoginAsync de UserService

            // Comprueba si el inicio de sesión fue exitoso
            if (isLoggedIn)
            {
                // Si el inicio de sesión fue exitoso, muestra un mensaje de alerta y navega a la página principal
                await Shell.Current.GoToAsync($"///{nameof(PrincipalPage)}");

                var currentUser = await userService.GetCurrentUserAsync(); // Obtiene el usuario actual
                await Application.Current.MainPage.DisplayAlert("Bienvenido", $"¡Hola {currentUser.Info.DisplayName}!", "OK");
            }
        }
        #endregion

        #region COMANDOS
        public Command LoginCommand { get; }
        #endregion
    }
}

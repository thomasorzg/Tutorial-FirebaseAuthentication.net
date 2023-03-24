using Firebase.Auth;
using System.Threading.Tasks;
using AFPS_App.Config;
using System;
using Xamarin.Forms;
using AFPS_App.Views;

namespace AFPS_App.Services
{
    public class UserService
    {
        // Declaración de variables
        private static FirebaseAuthClient _firebaseAuth; // Instancia de FirebaseAuth
        private UserCredential userCredential; // Credenciales de usuario
        private string token; // Token de autenticación

        // Método para obtener la instancia de FirebaseAuth
        public static FirebaseAuthClient FirebaseAuthInstance
        {
            // Getter
            get
            {
                // Comprueba si la instancia de FirebaseAuth es nula y la crea si es así
                if (_firebaseAuth == null)
                {
                    _firebaseAuth = new FirebaseAuthClient(FirebaseConfig.AuthConfig); // Crea la instancia de FirebaseAuth
                }
                return _firebaseAuth; // Regresa la instancia de FirebaseAuth
            }
        }

        // Método para iniciar sesión con correo y contraseña utilizando Firebase Auth
        public async Task<bool> LoginAsync(string email, string password)
        {
            // Bloque try-catch para evitar errores
            try
            {
                // Inicia sesión con el correo y contraseña
                userCredential = await FirebaseAuthInstance.SignInWithEmailAndPasswordAsync(email, password);
                var user = userCredential.User; // Obtiene el usuario logueado
                token = await user.GetIdTokenAsync(); // Obtiene el token de autenticación

                return true; // Regresa true si el inicio de sesión fue exitoso
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de alerta con el error
                await Application.Current.MainPage.DisplayAlert("Alerta", ex.Message, "OK");
                return false; // Regresa false si el inicio de sesión no fue exitoso
            }
        }

        // Método para obtener el usuario actual logueado
        public async Task<User> GetCurrentUserAsync()
        {
            // Bloque try-catch para evitar errores
            try
            {
                // Variables del usuario logueado
                var user = userCredential.User;
                var uid = user.Uid;
                var name = user.Info.DisplayName;

                return user; // Regresa el usuario logueado
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", ex.Message, "OK");
                return null; // Si no hay usuario logueado, regresa null
            }
        }
    }
}

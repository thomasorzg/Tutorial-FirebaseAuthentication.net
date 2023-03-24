using Firebase.Auth;
using Firebase.Auth.Providers;

namespace AFPS_App.Config
{
    public static class FirebaseConfig
    {
        // Declaración de variables
        public static string ApiKey = "TU-API-KEY"; // API Key de Firebase
        public static string AuthDomain = "TU-AUTH-DOMAIN"; // Auth Domain de Firebase
        public static FirebaseAuthProvider[] Providers = new FirebaseAuthProvider[] // Proveedores de Firebase Auth
        {
            new EmailProvider() // Proveedor de correo electrónico
        };

        // Método para obtener la configuración de Firebase Auth
        public static FirebaseAuthConfig AuthConfig => new FirebaseAuthConfig
        {
            ApiKey = ApiKey,
            AuthDomain = AuthDomain,
            Providers = Providers
        };
    }
}

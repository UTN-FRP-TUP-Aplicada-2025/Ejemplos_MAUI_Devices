namespace Ejemplo_Red;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        // detectar al cargar
        VerificarConexion();

        // detectar cuando cambia el estado de red
        Connectivity.ConnectivityChanged += (s, e) =>
        {
            VerificarConexion();
        };
    }

    private void VerificarConexion()
    {
        var acceso = Connectivity.Current.NetworkAccess;
        var perfiles = Connectivity.Current.ConnectionProfiles;

        if (acceso != NetworkAccess.Internet)
        {
            DisplayAlert("Sin conexión", "No hay acceso a Internet", "OK");
        }
        else if (perfiles.Contains(ConnectionProfile.WiFi))
        {
            DisplayAlert("Conectado", "Estás en Wi-Fi", "OK");
        }
        else if (perfiles.Contains(ConnectionProfile.Cellular))
        {
            DisplayAlert("Conectado", "Estás en datos móviles", "OK");
        }
        else
        {
            DisplayAlert("Conectado", "Tipo de conexión desconocido", "OK");
        }
    }
}

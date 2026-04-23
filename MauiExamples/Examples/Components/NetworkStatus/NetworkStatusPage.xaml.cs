using System.Collections.ObjectModel;
using System.Runtime.InteropServices.Marshalling;

namespace MauiExamples.Examples.Components.NetworkStatus;

public partial class NetworkStatusPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;

    public ObservableCollection<ConnectionProfile> ConnectionProfiles { get; } = new() ;

	public NetworkStatusPage(IServiceProvider serviceProvider)
	{
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
		InitializeComponent();
         BindingContext = this;
	}

    private void RefreshUI()
    {
        var access = Connectivity.Current.NetworkAccess;
        var profiles = Connectivity.Current.ConnectionProfiles;
        bool isConnected = access == NetworkAccess.Internet;

        StatusBanner.BackgroundColor = isConnected ? Colors.Green : Colors.Red;
        StatusLabel.Text = isConnected ? "Connected" : "No Internet";
        
        ConnectionProfiles.Clear();
        foreach (var profile in profiles)
        {
            ConnectionProfiles.Add(profile);
        }

        ConnectionType.Text = GetConnectionType(profiles).ToString();
    }

    private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            RefreshUI();
            LogEvent(e.NetworkAccess);
        });
    }

    private void LogEvent(NetworkAccess access)
    {
        var entry = $"[{DateTime.Now:HH:mm:ss}] → {access}";
        EventLog.Text = entry + EventLog.Text; // ObservableCollection or just prepend to a Label
    }

    private async void OnRefreshClicked(object sender, EventArgs e)
    {
        RefreshUI();
    }


    private async void OnGotoBasicsClicked(object sender, EventArgs e)
    {
        var page = _serviceProvider.GetRequiredService<Examples.Basics.BasicPage>();
        await Shell.Current.Navigation.PushAsync(page);
    }
    private ConnectionProfile GetConnectionType(IEnumerable<ConnectionProfile> connectionProfiles)
    {
        if (connectionProfiles.Contains(ConnectionProfile.WiFi)) return ConnectionProfile.WiFi;
        if (connectionProfiles.Contains(ConnectionProfile.Ethernet)) return ConnectionProfile.Ethernet;
        if (connectionProfiles.Contains(ConnectionProfile.Cellular)) return ConnectionProfile.Cellular;
        if (connectionProfiles.Contains(ConnectionProfile.Bluetooth)) return ConnectionProfile.Bluetooth;

        return ConnectionProfile.Unknown;
    }

    protected override void OnAppearing()
	{
        Connectivity.Current.ConnectivityChanged += OnConnectivityChanged;
        RefreshUI();
    }

    protected override void OnDisappearing()
    {
        Connectivity.Current.ConnectivityChanged -= OnConnectivityChanged;
    }
}
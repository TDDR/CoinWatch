using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CoinpaprikaApp.Models;

namespace CoinpaprikaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoinView : ContentPage
    {
        private Coin _coin = new Coin();
        public NetworkManager _netManager = new NetworkManager();
        public DBManager _dbManager = new DBManager();

        public CoinView()
        {
            InitializeComponent();
        }
        public CoinView(Coin coin, NetworkManager manager, DBManager dBManager)
        {
            InitializeComponent();
            _netManager = manager;
            _coin = coin;
            _dbManager = dBManager;

            rank.Text = coin.Rank.ToString();
            name.Text = coin.Name;
            symbol.Text = coin.Symbol;
            open.Text = "Open: " + coin.CurrentNumbers.Open.ToString("C3"); ;
            close.Text = "Close: " + coin.CurrentNumbers.Close.ToString("C3");
            high.Text = "High: " + coin.CurrentNumbers.High.ToString("C3");
            low.Text = "Low: " + coin.CurrentNumbers.Low.ToString("C3");
            volume.Text = "Volume: " + coin.CurrentNumbers.Volume.ToString("C0");
            marketCap.Text = "Market Cap: " + coin.CurrentNumbers.Market_Cap.ToString("C0");
        }

        protected async override void OnAppearing()
        {
            _coin = await _netManager.GetCoinById(_coin.Id);
           
            description.Text = _coin.Description;
            proof.Text = "Type of Proof: " + _coin.Proof_Type;
            org.Text = "Organizational Structure: " + _coin.Org_Structure;
            active.Text = "Active: " + _coin.Is_Active.ToString();
            first.Text = "Started: " + _coin.Started_At.ToString();
            last.Text = "Ended: " + _coin.Last_Data_At.ToString();

            base.OnAppearing();
        }

        async private void accountClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new UserView());
        }

        private void addToFavoritesClicked(object sender, EventArgs e)
        {
            DBTable newFav = new DBTable();
            newFav.CoinID = _coin.Id;
            newFav.FavoredOn = DateTime.Now.ToLocalTime();

            _dbManager.addToFavorites(newFav);
            DisplayAlert("Favorites Updated", "Your favorites have been updated", "Continue");
        }
    }
}
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CoinpaprikaApp.Models;
using System.Collections.ObjectModel;

namespace CoinpaprikaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserView : ContentPage
    {
        public NetworkManager netManager = new NetworkManager();
        public DBManager _dbManager = new DBManager();
        ObservableCollection<DBTable> _favorites;
        ObservableCollection<Coin> _coins = new ObservableCollection<Coin>();

        public UserView()
        {
            InitializeComponent();
        }

        public UserView(DBManager manager)
        {
            InitializeComponent();
            _dbManager = manager;
        }

        protected async override void OnAppearing()
        {
            _favorites = await _dbManager.CreateTable();
            foreach(var coin in _favorites)
            {
                _coins.Add(await netManager.GetCoinById(coin.CoinID));
            }
            foreach (var coin in _coins)
            {
                coin.CurrentNumbers = await netManager.GetCurrentNumbers(coin.Id);
            }
            Coins.ItemsSource = _coins;

            base.OnAppearing();
        }
        async private void detailClicked(object sender, EventArgs e)
        {
            var coinToView = (sender as MenuItem).CommandParameter as Coin;
            await Navigation.PushModalAsync(new NavigationPage(new CoinView(coinToView, netManager, _dbManager)));
        }
        private void removeFavoriteClicked(object sender, EventArgs e)
        {
            var coinToRemove = (sender as MenuItem).CommandParameter as Coin;
            for (int i = 0; i < _favorites.Count; i++)
            {
                if(_favorites[i].CoinID == coinToRemove.Id)
                {
                    _coins.Remove(coinToRemove);
                    _dbManager.removeFromFavorites(_favorites[i]);
                    _favorites.Remove(_favorites[i]);
                    break;
                }
            }

        }
    }
}
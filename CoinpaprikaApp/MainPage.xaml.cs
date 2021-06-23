using System;
using Xamarin.Forms;
using CoinpaprikaApp.Models;
using System.Collections.ObjectModel;

namespace CoinpaprikaApp
{
    public partial class MainPage : ContentPage
    {
        public DBManager dbManager = new DBManager();
        public NetworkManager manager = new NetworkManager();
        public ObservableCollection<DBTable> _favorites;

        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            var coinList = await manager.GetAllCoins();
            for(var i = 0; i < 30; i++)
            {
                coinList[i].CurrentNumbers = await manager.GetCurrentNumbers(coinList[i].Id);
            }
            Coins.ItemsSource = coinList;
            
            _favorites = await dbManager.CreateTable();

            base.OnAppearing();
        }

        async private void detailsClicked(object sender, EventArgs e)
        {
            var coinToView = (sender as MenuItem).CommandParameter as Coin;
            await Navigation.PushModalAsync(new NavigationPage(new CoinView(coinToView, manager, dbManager)));
        }
        private void addFavoriteClicked(object sender, EventArgs e)
        {
            var coinToAdd = (sender as MenuItem).CommandParameter as Coin;

            DBTable newFav = new DBTable();
            newFav.CoinID = coinToAdd.Id;
            newFav.FavoredOn = DateTime.Now.ToLocalTime();

            dbManager.addToFavorites(newFav);
            DisplayAlert("Favorites Updated", "Your favorites have been updated", "Continue");
        }
        async private void accountClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new UserView(dbManager)));
        }
    }
}

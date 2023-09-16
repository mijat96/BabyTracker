using BabyTracker.SQLlite;
using System.Text.Json;

namespace BabyTracker
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var babyEventDataBase = new BabyEventDataBase();
            await babyEventDataBase.SaveItemAsync(new Models.BabyEvent()
            {
                EventName = "test event",
                EventTime = DateTime.Now,
                EventType = Models.BabyEventType.BabyBreastFeeding
            });
            var inDb = await babyEventDataBase.GetItemsAsync();

            count = inDb.Count;
            CounterBtn.Text = $"List count {count}";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
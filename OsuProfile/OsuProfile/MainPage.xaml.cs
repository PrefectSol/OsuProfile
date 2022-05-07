namespace OsuProfile
{
    using System;
    using OsuProfile.Services;
    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        public static string UserID = null;

        public MainPage()
        {
            this.InitializeComponent();
            UserID = null;
        }

        public async void GetPlayer(object sender, EventArgs e)
        {
            string nickname = this.Username.Text;

            await OsuGetUserJson.GetJson(nickname);
            UserID = OsuGetUserJson.UserID;

            if (UserID == "error")
            {
                await this.DisplayAlert("Ошибка", "Неверное имя пользователя или недостаточно сыгранных игр", "Повторить попытку");
                return;
            }

            await OsuGetTopPlaysJson.GetJson(UserID);

            await this.Navigation.PushModalAsync(new InfoPage());
        }
    }
}

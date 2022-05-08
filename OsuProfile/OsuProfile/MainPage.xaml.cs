namespace OsuProfile
{
    using System;
    using OsuProfile.Services;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        public static string UserID = null;
        public static string Playcount = null;

        public MainPage()
        {
            CheckConnection();

        }

        private async void CheckConnection()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                this.InitializeComponent();
            }
            else
            {
                var result = await this.DisplayAlert("Нет подключения к интернету", "Нет подключения к интернету", "Повторить попытку", "Выйти");

                if (result == true)
                {
                    CheckConnection();
                }
                else
                {
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
            }
        }

        public async void GetPlayer(object sender, EventArgs e)
        {
            string nickname = this.Username.Text;

            await OsuGetUserJson.GetJson(nickname);
            UserID = OsuGetUserJson.UserID;
            Playcount = OsuGetUserJson.Playcount;


            if (UserID == "error" || int.Parse(Playcount) < 50)
            {
                await this.DisplayAlert("Ошибка", "Неверное имя пользователя или недостаточно сыгранных игр", "Повторить попытку");
                return;
            }

            await OsuGetTopPlaysJson.GetJson(UserID);

            await this.Navigation.PushModalAsync(new InfoPage());
        }
    }
}

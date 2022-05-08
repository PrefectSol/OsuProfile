namespace OsuProfile
{
    using System;
    using Newtonsoft.Json.Linq;
    using OsuProfile.Services;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            this.InitializeComponent();

            JArray topPlaysJson = OsuGetTopPlaysJson.Json;
            JObject userJson = OsuGetUserJson.Json;

            string avatarUrl = userJson["avatar_url"].ToString();
            this.Avatar.Source = avatarUrl;

            string username = userJson["username"].ToString();
            this.Username.Text = username;

            string usernameID = userJson["id"].ToString();
            this.UsernameID.Text += usernameID;

            double time = double.Parse(userJson["statistics"]["play_time"].ToString());
            time /= 3600;
            time = Math.Round(time);
            this.Time.Text += $"{time} hours";

            string pp = userJson["statistics"]["pp"].ToString();
            this.PP.Text += pp;

            string lvl = userJson["statistics"]["level"]["current"].ToString();
            this.Level.Text += lvl;

            string country = userJson["country_code"].ToString();
            this.Country.Text += country;

            string topW = userJson["statistics"]["global_rank"].ToString();
            this.WorldTop.Text += topW;

            string topC = userJson["statistics"]["country_rank"].ToString();
            this.CountyTop.Text += topC;

            string hitAcc = userJson["statistics"]["hit_accuracy"].ToString();
            double nAcc = double.Parse(hitAcc);
            var acc = string.Format("{0:0.##}", nAcc);
            this.HitAccuracy.Text += $"{acc}%";

            string maxCom = userJson["statistics"]["maximum_combo"].ToString();
            this.maximum_combo.Text += maxCom;

            string playCount = userJson["statistics"]["play_count"].ToString();
            this.play_count.Text += playCount;

            string totalScore = userJson["statistics"]["total_score"].ToString();
            this.total_score.Text += totalScore;

            string ss = userJson["statistics"]["grade_counts"]["ss"].ToString();
            this.SS.Text += ss;

            string ssh = userJson["statistics"]["grade_counts"]["ssh"].ToString();
            this.SSH.Text += ssh;

            string s = userJson["statistics"]["grade_counts"]["s"].ToString();
            this.S.Text += s;

            string sh = userJson["statistics"]["grade_counts"]["sh"].ToString();
            this.SH.Text += sh;

            string a = userJson["statistics"]["grade_counts"]["a"].ToString();
            this.A.Text += a;

            this.AimV.Text = GetAim(topPlaysJson);
            this.SpeedV.Text = GetSpeed(topPlaysJson);
            this.AccuracyV.Text = GetAcc(topPlaysJson);
            this.Stars.Text = GetStarRank(topPlaysJson);
            this.Rank.Text = GetRank(int.Parse(this.AimV.Text), int.Parse(this.SpeedV.Text), int.Parse(this.AccuracyV.Text));
            this.Card.Source = GetCard(this.Rank.Text);

            string title1 = topPlaysJson[0]["beatmapset"]["title_unicode"].ToString();
            string title2 = topPlaysJson[1]["beatmapset"]["title_unicode"].ToString();
            string title3 = topPlaysJson[2]["beatmapset"]["title_unicode"].ToString();
            string title4 = topPlaysJson[3]["beatmapset"]["title_unicode"].ToString();
            string title5 = topPlaysJson[4]["beatmapset"]["title_unicode"].ToString();

            string dif1 = topPlaysJson[0]["beatmap"]["version"].ToString();
            string dif2 = topPlaysJson[1]["beatmap"]["version"].ToString();
            string dif3 = topPlaysJson[2]["beatmap"]["version"].ToString();
            string dif4 = topPlaysJson[3]["beatmap"]["version"].ToString();
            string dif5 = topPlaysJson[4]["beatmap"]["version"].ToString();

            string star1 = topPlaysJson[0]["beatmap"]["difficulty_rating"].ToString();
            string star2 = topPlaysJson[1]["beatmap"]["difficulty_rating"].ToString();
            string star3 = topPlaysJson[2]["beatmap"]["difficulty_rating"].ToString();
            string star4 = topPlaysJson[3]["beatmap"]["difficulty_rating"].ToString();
            string star5 = topPlaysJson[4]["beatmap"]["difficulty_rating"].ToString();

            string rank1 = topPlaysJson[0]["rank"].ToString();
            string rank2 = topPlaysJson[1]["rank"].ToString();
            string rank3 = topPlaysJson[2]["rank"].ToString();
            string rank4 = topPlaysJson[3]["rank"].ToString();
            string rank5 = topPlaysJson[4]["rank"].ToString();

            string pp1 = topPlaysJson[0]["pp"].ToString();
            string pp2 = topPlaysJson[2]["pp"].ToString();
            string pp3 = topPlaysJson[4]["pp"].ToString();
            string pp4 = topPlaysJson[6]["pp"].ToString();
            string pp5 = topPlaysJson[8]["pp"].ToString();

            string acc1 = topPlaysJson[0]["accuracy"].ToString();
            double nAcc1 = double.Parse(acc1) * 100;
            var accuracy1 = string.Format("{0:0.##}", nAcc1);

            string acc2 = topPlaysJson[1]["accuracy"].ToString();
            double nAcc2 = double.Parse(acc2) * 100;
            var accuracy2 = string.Format("{0:0.##}", nAcc2);

            string acc3 = topPlaysJson[2]["accuracy"].ToString();
            double nAcc3 = double.Parse(acc3) * 100;
            var accuracy3 = string.Format("{0:0.##}", nAcc3);

            string acc4 = topPlaysJson[3]["accuracy"].ToString();
            double nAcc4 = double.Parse(acc4) * 100;
            var accuracy4 = string.Format("{0:0.##}", nAcc4);

            string acc5 = topPlaysJson[4]["accuracy"].ToString();
            double nAcc5 = double.Parse(acc5) * 100;
            var accuracy5 = string.Format("{0:0.##}", nAcc5);

            string score1 = topPlaysJson[0]["score"].ToString();
            string score2 = topPlaysJson[2]["score"].ToString();
            string score3 = topPlaysJson[4]["score"].ToString();
            string score4 = topPlaysJson[6]["score"].ToString();
            string score5 = topPlaysJson[8]["score"].ToString();

            this.Title1.Text = $"1. {title1} [{dif1}] - {star1}★";
            this.Descriprion1.Text = $"•{rank1}•{pp1} PP•{accuracy1}%•{score1}•";
            this.Title2.Text = $"2. {title2} [{dif2}] - {star2}★";
            this.Descriprion2.Text = $"•{rank2}•{pp2} PP•{accuracy2}%•{score2}•";
            this.Title3.Text = $"3. {title3} [{dif3}] - {star3}★";
            this.Descriprion3.Text = $"•{rank3}•{pp3} PP•{accuracy3}%•{score3}•";
            this.Title4.Text = $"4. {title4} [{dif4}] - {star4}★";
            this.Descriprion4.Text = $"•{rank4}•{pp4} PP•{accuracy4}%•{score4}•";
            this.Title5.Text = $"5. {title5} [{dif5}] - {star5}★";
            this.Descriprion5.Text = $"•{rank5}•{pp5} PP•{accuracy5}%•{score5}•";
        }

        private static string GetCard(string rank)
        {
            string link = rank.Replace(" ", null) + ".png";
            return link;
        }

        private static string GetRank(int aim, int speed, int accuracy)
        {
            string[] cardRanks = new string[] { "Common", "Rare", "Super Rare", "Ultra Rare", "Elite", "Master", "Legendary" };
            string rankOfCard;

            if ((aim > 1000) && (speed > 1000) && (accuracy > 1000))
            {
                rankOfCard = cardRanks[6];
            }
            else if ((aim > 1000) || (speed > 1000) || (accuracy > 1000))
            {
                rankOfCard = cardRanks[5];
            }
            else if ((aim > 700) || (speed > 700) || (accuracy > 700))
            {
                rankOfCard = cardRanks[4];
            }
            else if ((aim > 500) && (speed > 500) && (accuracy > 500))
            {
                rankOfCard = cardRanks[3];
            }
            else if ((aim > 500) || (speed > 500) || (accuracy > 500))
            {
                rankOfCard = cardRanks[2];
            }
            else if ((aim > 300) || (speed > 300) || (accuracy > 300))
            {
                rankOfCard = cardRanks[1];
            }
            else
            {
                rankOfCard = cardRanks[0];
            }

            return rankOfCard;
        }

        private static string GetStarRank(JArray topPlaysJson)
        {
            double sum = 0;
            string lenStars = string.Empty;

            double[] stars = new double[topPlaysJson.Count];

            for (int k = 0; k < topPlaysJson.Count; k++)
            {
                string dif = topPlaysJson[k]["beatmap"]["difficulty_rating"].ToString();
                stars[k] = double.Parse(dif);
            }

            for (int i = 0; i < topPlaysJson.Count; i++)
            {
                sum += stars[i];
            }

            double starRank = sum / topPlaysJson.Count;
            starRank = Math.Round(starRank);

            for (int l = 0; l < starRank; l++)
            {
                lenStars += "★";
            }

            return lenStars;
        }

        private static string GetAim(JArray topPlaysJson)
        {
            double sumPP = 0;
            double sumAr = 0;
            double sumCs = 0;

            double[] pps = new double[topPlaysJson.Count];
            double[] ars = new double[topPlaysJson.Count];
            double[] css = new double[topPlaysJson.Count];

            for (int i = 0; i < topPlaysJson.Count; i += 2)
            {
                string pp = topPlaysJson[i]["pp"].ToString();
                pps[i] = double.Parse(pp);
                sumPP += pps[i];
            }

            for (int i = 0; i < topPlaysJson.Count; i++)
            {
                string ar = topPlaysJson[i]["beatmap"]["ar"].ToString();
                ars[i] = double.Parse(ar);
                sumAr += ars[i];
            }

            for (int i = 0; i < topPlaysJson.Count; i++)
            {
                string bpm = topPlaysJson[i]["beatmap"]["cs"].ToString();
                css[i] = double.Parse(bpm);
                sumCs += css[i];
            }

            double arRank = sumAr / topPlaysJson.Count;
            double csRank = sumCs / topPlaysJson.Count;
            double ppRank = sumPP / topPlaysJson.Count;
            double sum_avr = (arRank + csRank + ppRank) / 3;

            double aimRank = (arRank * (Math.Pow(csRank, 0.09) / Math.Pow(180, 0.09)) * (Math.Pow(arRank, 0.1) /
                Math.Pow(6, 0.1)) / Math.Pow(arRank + csRank, 0.1) * ppRank / (arRank + csRank + ppRank) * 100) + (1.25 * Math.Pow(sum_avr, 1.3));
            aimRank = Math.Round(aimRank);

            return aimRank.ToString();
        }

        private static string GetSpeed(JArray topPlaysJson)
        {
            double sumPP = 0;
            double sumAr = 0;
            double sumBpm = 0;

            double[] pps = new double[topPlaysJson.Count];
            double[] ars = new double[topPlaysJson.Count];
            double[] bpms = new double[topPlaysJson.Count];

            for (int i = 0; i < topPlaysJson.Count; i += 2)
            {
                string pp = topPlaysJson[i]["pp"].ToString();
                pps[i] = double.Parse(pp);
                sumPP += pps[i];
            }

            for (int i = 0; i < topPlaysJson.Count; i++)
            {
                string ar = topPlaysJson[i]["beatmap"]["ar"].ToString();
                ars[i] = double.Parse(ar);
                sumAr += ars[i];
            }

            for (int i = 0; i < topPlaysJson.Count; i++)
            {
                string bpm = topPlaysJson[i]["beatmap"]["bpm"].ToString();
                bpms[i] = double.Parse(bpm);
                sumBpm += bpms[i];
            }

            double arRank = sumAr / topPlaysJson.Count;
            double bpmRank = sumBpm / topPlaysJson.Count;
            double ppRank = sumPP / topPlaysJson.Count;
            double sum_avr = (arRank + bpmRank + ppRank) / 3;

            double speedRank = (arRank * (Math.Pow(bpmRank, 0.09) / Math.Pow(180, 0.09)) * (Math.Pow(arRank, 0.1) /
                Math.Pow(6, 0.1)) / Math.Pow(arRank + bpmRank, 0.1) * ppRank / (arRank + bpmRank + ppRank) * 100) + (1.25 * Math.Pow(sum_avr, 1.3));
            speedRank = Math.Round(speedRank);

            return speedRank.ToString();
        }

        private static string GetAcc(JArray topPlaysJson)
        {
            double sumPP = 0;
            double sumAr = 0;
            double sumAcc = 0;

            double[] pps = new double[topPlaysJson.Count];
            double[] ars = new double[topPlaysJson.Count];
            double[] accs = new double[topPlaysJson.Count];

            for (int i = 0; i < topPlaysJson.Count; i += 2)
            {
                string pp = topPlaysJson[i]["pp"].ToString();
                pps[i] = double.Parse(pp);
                sumPP += pps[i];
            }

            for (int i = 0; i < topPlaysJson.Count; i++)
            {
                string ar = topPlaysJson[i]["beatmap"]["ar"].ToString();
                ars[i] = double.Parse(ar);
                sumAr += ars[i];
            }

            for (int i = 0; i < topPlaysJson.Count; i += 2)
            {
                string bpm = topPlaysJson[i]["beatmap"]["accuracy"].ToString();
                accs[i] = double.Parse(bpm);
                sumAcc += accs[i];
            }

            double arRank = sumAr / topPlaysJson.Count;
            double accRank = sumAcc / topPlaysJson.Count;
            double ppRank = sumPP / topPlaysJson.Count;
            double sum_avr = (arRank + accRank + ppRank) / 3;

            double accuracyRank = (arRank * (Math.Pow(accRank, 0.09) / Math.Pow(180, 0.09)) * (Math.Pow(arRank, 0.1) /
                Math.Pow(6, 0.1)) / Math.Pow(arRank + accRank, 0.1) * ppRank / (arRank + accRank + ppRank) * 100) + (1.25 * Math.Pow(sum_avr, 1.3));
            accuracyRank = Math.Round(accuracyRank);

            return accuracyRank.ToString();
        }

        private async void MoveBack(object sender, EventArgs e)
        {
            await this.Navigation.PopModalAsync();
        }
    }
}
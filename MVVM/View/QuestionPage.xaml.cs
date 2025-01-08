using System.Diagnostics;
using System.Text.Json;

namespace TruthOrDrinkAppMac;

public partial class QuestionPage : ContentPage
{
    private int _riskLevel;
    private string _gamemode;
    private List<string> _questions;


    public QuestionPage(int riskLevel, string gamemode)
    {
        InitializeComponent();
        _riskLevel = riskLevel;
        _gamemode = gamemode;
        _questions = new List<string>();

        LoadQuestions();
    }

    public class TruthResponse
    {
        public string question { get; set; } // Dit moet overeenkomen met de API-response uit Postman
    }


    private async void LoadQuestions()
    {
        string question = null;

        try
        {
            switch (_gamemode)
            {
                case "Truth":
                    question = await FetchFromApi("https://api.truthordarebot.xyz/v1/truth");
                    break;

                case "Never Have I Ever":
                    question = await FetchFromApi("https://api.truthordarebot.xyz/api/nhie");
                    break;

                case "Would You Rather":
                    question = await FetchFromApi("https://api.truthordarebot.xyz/api/wyr");
                    break;

                default:
                    throw new InvalidOperationException("Onbekende gamemode");
            }

            if (!string.IsNullOrEmpty(question))
            {
                _questions.Add(question);
                ShowNextQuestion();
            }
            else
            {
                await DisplayAlert("Error", "Geen vragen gevonden. Probeer opnieuw.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Fout bij het laden van vragen: {ex.Message}", "OK");
        }
    }

    private async Task<string> FetchFromApi(string apiUrl)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<TruthResponse>(json);

            return responseObject?.question;
        }

        Debug.WriteLine($"API call failed: {response.StatusCode}");
        return null;
    }

    private void ShowNextQuestion()
    {
        if (_questions.Count > 0)
        {
            var question = _questions[0];
            _questions.RemoveAt(0);
            QuestionLabel.Text = question;
        }
        else
        {
            QuestionLabel.Text = "Geen vragen meer!";
        }
    }

    private void VibratePhone()
    {
        int secondsToVibrate = Random.Shared.Next(1, 7);
        TimeSpan vibrationLength = TimeSpan.FromSeconds(secondsToVibrate);

        Vibration.Default.Vibrate(vibrationLength);
    }

    private void VibrateStartButton_Clicked(object sender, EventArgs e)
    {
        VibratePhone();
    }

    private async void OnDrinkButtonClicked(object sender, EventArgs e)
    {
        VibratePhone();
        await DisplayAlert("Drink", $"Neem {_riskLevel} slok(ken)!", "OK");
        ShowNextQuestion();
    }

    private async void OnAnswerButtonClicked(object sender, EventArgs e)
    {
        ShowNextQuestion();
    }
}

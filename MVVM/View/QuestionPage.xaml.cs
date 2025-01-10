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
        public string question { get; set; }
    }

    private async void LoadQuestions()
    {
        try
        {
            if (_gamemode == "Combined")
            {
                // Lijst om alle vragen van verschillende API's op te slaan
                List<string> combinedQuestions = new List<string>();

                // Voeg de vragen van alle API's toe
                for (int i = 0; i < 10; i++)
                {
                    string truthQuestion = await FetchFromApi("https://api.truthordarebot.xyz/v1/truth");
                    string nhieQuestion = await FetchFromApi("https://api.truthordarebot.xyz/api/nhie");
                    string wyrQuestion = await FetchFromApi("https://api.truthordarebot.xyz/api/wyr");

                    if (!string.IsNullOrEmpty(truthQuestion))
                    {
                        combinedQuestions.Add(truthQuestion);
                    }

                    if (!string.IsNullOrEmpty(nhieQuestion))
                    {
                        combinedQuestions.Add(nhieQuestion);
                    }

                    if (!string.IsNullOrEmpty(wyrQuestion))
                    {
                        combinedQuestions.Add(wyrQuestion);
                    }
                }

                // Randomize de volgorde van de vragen
                Random random = new Random();
                _questions = combinedQuestions.OrderBy(q => random.Next()).ToList();
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    string question = null;

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

                        case "Combined":
                            // Haal vragen op van alle drie de API's en combineer ze
                            List<string> combinedQuestions = new List<string>();
                            string truthQuestion = await FetchFromApi("https://api.truthordarebot.xyz/v1/truth");
                            if (!string.IsNullOrEmpty(truthQuestion))
                            {
                                combinedQuestions.Add(truthQuestion);
                            }

                            string nhieQuestion = await FetchFromApi("https://api.truthordarebot.xyz/api/nhie");
                            if (!string.IsNullOrEmpty(nhieQuestion))
                            {
                                combinedQuestions.Add(nhieQuestion);
                            }

                            string wyrQuestion = await FetchFromApi("https://api.truthordarebot.xyz/api/wyr");
                            if (!string.IsNullOrEmpty(wyrQuestion))
                            {
                                combinedQuestions.Add(wyrQuestion);
                            }

                            // Randomize de vragenlijst
                            Random random = new Random();
                            _questions = combinedQuestions.OrderBy(q => random.Next()).ToList();
                            return; // Stop verder met de code, want we hebben al de gecombineerde vragenlijst ingesteld

                        default:
                            throw new InvalidOperationException("Onbekende gamemode");
                    }

                    if (!string.IsNullOrEmpty(question))
                    {
                        _questions.Add(question);
                    }

                }
            }

            // Controleer of er vragen zijn
            if (_questions.Count > 0)
            {
                ShowNextQuestion();
            }
            else
            {
                await DisplayAlert("Error", "Geen vragen gevonden. Probeer opnieuw.", "OK");
                await Navigation.PushAsync(new SessionPage());
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

    private async void ShowNextQuestion()
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
            await Navigation.PushAsync(new SessionPage());
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

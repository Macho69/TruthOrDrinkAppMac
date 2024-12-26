namespace TruthOrDrinkAppMac;

public partial class SessionPage : ContentPage
{
    private int _riskLevel = 1; // Standaard op 1

    public SessionPage()
    {
        InitializeComponent();
        InitializeStars();
    }

    private void InitializeStars()
    {
        // Voeg tap gestures toe aan alle sterren
        AddTapGesture(Star1, 1);
        AddTapGesture(Star2, 2);
        AddTapGesture(Star3, 3);
        AddTapGesture(Star4, 4);
        AddTapGesture(Star5, 5);

        // Stel standaardniveau in
        UpdateStars();
    }

    private void AddTapGesture(Image star, int starNumber)
    {
        var tapGesture = new TapGestureRecognizer();
        tapGesture.Tapped += (s, e) => SetRiskLevel(starNumber);
        star.GestureRecognizers.Add(tapGesture);
    }

    private void SetRiskLevel(int level)
    {
        _riskLevel = level;
        UpdateStars();
    }

    private void UpdateStars()
    {
        // Update de visuele weergave van de sterren
        Star1.Source = _riskLevel >= 1 ? "star_filled.png" : "star_empty.png";
        Star2.Source = _riskLevel >= 2 ? "star_filled.png" : "star_empty.png";
        Star3.Source = _riskLevel >= 3 ? "star_filled.png" : "star_empty.png";
        Star4.Source = _riskLevel >= 4 ? "star_filled.png" : "star_empty.png";
        Star5.Source = _riskLevel >= 5 ? "star_filled.png" : "star_empty.png";
    }

    private async void OnInviteButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InvitePage());
    }

}

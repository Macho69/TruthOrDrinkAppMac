namespace TruthOrDrinkAppMac;

public partial class QuestionPage : ContentPage
{
    private List<string> questions = new List<string>
    {
        "What’s your biggest secret?",
        "Have you ever cheated on a test?",
        "What’s your most embarrassing moment?"
    };
    private int currentIndex = 0;

    public QuestionPage()
    {
        InitializeComponent();
        DisplayNextQuestion();
    }

    private void DisplayNextQuestion()
    {
        if (currentIndex >= questions.Count)
        {
            currentIndex = 0;
        }

        QuestionLabel.Text = questions[currentIndex];
        currentIndex++;
    }

    private void OnNextQuestionClicked(object sender, EventArgs e)
    {
        DisplayNextQuestion();
    }
}
namespace TruthOrDrinkAppMac;

public partial class CustomQuestionsPage : ContentPage
{
    private List<string> customQuestions = new List<string>();

    public CustomQuestionsPage()
    {
        InitializeComponent();
    }

    private void OnAddQuestionClicked(object sender, EventArgs e)
    {
        var question = QuestionEntry.Text;
        if (!string.IsNullOrEmpty(question))
        {
            customQuestions.Add(question);
            QuestionEntry.Text = string.Empty;
            DisplayAlert("Success", "Question added!", "OK");
        }
    }
}
using FlashcardApp.Models;
using FlashcardApp.Services;

namespace FlashcardApp;

public partial class AddCardPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    public AddCardPage(DatabaseService databaseService)
    {
        InitializeComponent();
        _databaseService = databaseService;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var question = QuestionEditor.Text;
        var answer = AnswerEditor.Text;

        if (string.IsNullOrWhiteSpace(question) || string.IsNullOrWhiteSpace(answer))
        {
            await DisplayAlert("Oops", "Please fill in both the question and answer", "OK");
            return;
        }

        var card = new Flashcard
        {
            Question = question,
            Answer = answer
        };

        await _databaseService.AddFlashcardAsync(card);
        await Navigation.PopAsync();
    }
}
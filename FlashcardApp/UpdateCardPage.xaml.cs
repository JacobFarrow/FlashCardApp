using FlashcardApp.Models;
using FlashcardApp.Services;

namespace FlashcardApp;

public partial class UpdateCardPage : ContentPage
{
    private readonly DatabaseService _databaseService;
    private readonly Flashcard _card;

    public UpdateCardPage(DatabaseService databaseService, Flashcard card)
    {
        InitializeComponent();
        _databaseService = databaseService;
        _card = card;
        QuestionEditor.Text = _card.Question;
        AnswerEditor.Text = _card.Answer;
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

        _card.Question = question;
        _card.Answer = answer;

        await _databaseService.UpdateFlashcardAsync(_card);
        await Navigation.PopAsync();
    }
}
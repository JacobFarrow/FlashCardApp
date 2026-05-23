using FlashcardApp.Models;
using FlashcardApp.Services;

namespace FlashcardApp;

public partial class QuizPage : ContentPage
{
    private readonly DatabaseService _databaseService;
    private List<Flashcard> _cards;
    private int _currentIndex = 0;
    private int _score = 0;

    public QuizPage(DatabaseService databaseService)
    {
        InitializeComponent();
        _databaseService = databaseService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _cards = await _databaseService.GetFlashcardsAsync();
        _currentIndex = 0;
        _score = 0;

        if (_cards.Count == 0)
        {
            await DisplayAlert("No Cards", "Please add some flashcards before starting the quiz", "OK");
            await Navigation.PopAsync();
            return;
        }

        ShowCard();
    }

    private void ShowCard()
    {
        var card = _cards[_currentIndex];

        ProgressLabel.Text = $"Card {_currentIndex + 1} of {_cards.Count}";
        QuestionLabel.Text = card.Question;
        AnswerLabel.Text = "Tap reveal to see the answer";
        AnswerLabel.TextColor = Colors.Gray;

        RevealButton.IsVisible = true;
        ScoreButtons.IsVisible = false;
    }

    private void OnRevealClicked(object sender, EventArgs e)
    {
        var card = _cards[_currentIndex];
        AnswerLabel.Text = card.Answer;
        AnswerLabel.TextColor = Colors.Black;

        RevealButton.IsVisible = false;
        ScoreButtons.IsVisible = true;
    }

    private async void OnGotItClicked(object sender, EventArgs e)
    {
        _score++;
        await MoveToNextCard();
    }

    private async void OnMissedItClicked(object sender, EventArgs e)
    {
        await MoveToNextCard();
    }

    private async Task MoveToNextCard()
    {
        _currentIndex++;

        if (_currentIndex >= _cards.Count)
        {
            await DisplayAlert(
                "Quiz Complete!",
                $"You got {_score} out of {_cards.Count} correct!",
                "OK"
            );
            await Navigation.PopAsync();
            return;
        }

        ShowCard();
    }
}
using FlashcardApp.Models;
using FlashcardApp.Services;

namespace FlashcardApp;

public partial class MainPage : ContentPage
{
    private readonly DatabaseService _databaseService;
    public List<Flashcard> Flashcards { get; set; } = new List<Flashcard>();

    public MainPage(DatabaseService databaseService)
    {
        InitializeComponent();
        _databaseService = databaseService;
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        Flashcards = await _databaseService.GetFlashcardsAsync();
        FlashcardsListView.ItemsSource = Flashcards;
    }

    private async void OnAddFlashcardClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCardPage(_databaseService));
    }

	private async void OnStartQuizClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new QuizPage(_databaseService));
	}
	private async void OnEditClicked(object sender, EventArgs e)
	{
		var button = (Button)sender;
		var card = (Flashcard)button.CommandParameter;
		await Navigation.PushAsync(new UpdateCardPage(_databaseService, card));
	}
    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var card = (Flashcard)button.CommandParameter;
        await _databaseService.DeleteFlashcardAsync(card);
        Flashcards.Remove(card);
        FlashcardsListView.ItemsSource = null;
        FlashcardsListView.ItemsSource = Flashcards;
    }
}
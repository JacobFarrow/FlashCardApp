using SQLite;

namespace FlashcardApp.Models;

public class Flashcard
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    private string _question = string.Empty;
    public string Question
    {
        get { return _question; }
        set { _question = value.Trim(); }
    }

    private string _answer = string.Empty;
    public string Answer
    {
        get { return _answer; }
        set { _answer = value.Trim(); }
    }
}
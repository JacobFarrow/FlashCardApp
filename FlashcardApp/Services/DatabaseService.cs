using SQLite;
using FlashcardApp.Models;

namespace FlashcardApp.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection _database;

    public async Task InitAsync()
    {
        if (_database != null)
            return;

        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "flashcards.db");
        _database = new SQLiteAsyncConnection(dbPath);
        await _database.CreateTableAsync<Flashcard>();
    }

    public async Task<List<Flashcard>> GetFlashcardsAsync()
    {
        await InitAsync();
        return await _database.Table<Flashcard>().ToListAsync();
    }

    public async Task AddFlashcardAsync(Flashcard card)
    {
        await InitAsync();
        await _database.InsertAsync(card);
    }

    public async Task UpdateFlashcardAsync(Flashcard card)
    {
        await InitAsync();
        await _database.UpdateAsync(card);
    }

    public async Task DeleteFlashcardAsync(Flashcard card)
    {
        await InitAsync();
        await _database.DeleteAsync(card);
    }
}
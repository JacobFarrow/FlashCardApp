# Flashcard Quiz App

A mobile flashcard app built with C# and .NET MAUI for Android. The app allows users to create, edit, and delete flashcards, view all saved cards in a list, and test their knowledge through a quiz mode that reveals answers on tap and tracks a Got it / Missed it score. All flashcards are saved locally using SQLite so they persist between sessions.

## Instructions for Build and Use

Steps to build and/or run the software:

1. Install .NET 10 SDK and the MAUI Android workload by running `dotnet workload install maui-android`
2. Install Android Studio and set up an Android emulator (Pixel 6, API 37)
3. Clone the repository, navigate to the FlashcardApp folder, and run `dotnet build -t:Run -f net10.0-android`

Instructions for using the software:

1. Tap "Add Flashcard" to create a new card by entering a question and answer then tapping Save
2. Tap "Edit" or "Delete" on any card in the list to modify or remove it
3. Tap "Start Quiz" to enter quiz mode, tap "Reveal Answer" to see the answer, then tap "Got it" or "Missed it" to track your score

## Development Environment

To recreate the development environment, you need the following software and/or libraries with the specified versions:

* .NET 10 SDK (net10.0-android)
* .NET MAUI workload (maui-android)
* Android Studio (for emulator and Java JDK)
* sqlite-net-pcl version 1.9.172
* SQLitePCLRaw.bundle_green version 2.1.11

## Useful Websites to Learn More

I found these websites useful in developing this software:

* [Microsoft MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
* [sqlite-net-pcl GitHub](https://github.com/praeclarum/sqlite-net)
* [.NET MAUI Community on Stack Overflow](https://stackoverflow.com/questions/tagged/maui)

## Future Work

The following items I plan to fix, improve, and/or add to this project in the future:

* [ ] Organize flashcards into named decks so users can study specific topics
* [ ] Replace the deprecated ListView with CollectionView for better performance
* [ ] Add a shuffle mode to the quiz so cards appear in a random order
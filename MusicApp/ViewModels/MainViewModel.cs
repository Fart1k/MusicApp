using MusicApp.Models;
using MusicApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusicApp.ViewModels
{
    public class MainViewModel
    {
        private readonly DatabaseService _db;
        private readonly AudioServices _audioService;

        public ObservableCollection<Song> Songs { get; set; } = new();

        public string NewTitle {  get; set; }
        public string NewArtist { get; set; }

        public ICommand PlayCommand { get; }
        public ICommand PauseCommand { get; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public MainViewModel(DatabaseService db, AudioServices audioService)
        {
            _db = db;
            _audioService = audioService;

            AddCommand = new Command(async () => await AddSong());
            DeleteCommand = new Command<Song>(async (song) => await DeleteSong(song));
            PlayCommand = new Command(async () =>
            {
                await _audioService.PlayAsync("music.mp3");
            });
            PauseCommand = new Command(() =>
            {
                _audioService.Pause();
            });
            

            Task.Run(async () => await Load());
        }

        //Load All SOngs
        private async Task Load()
        {
            await _db.Init();

            var songs = await _db.GetSongs();

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Songs.Clear();
                foreach (var s in songs)
                    Songs.Add(s);
            });
        }

        //Add Song
        private async Task AddSong()
        {
            var song = new Song
            {
                Title = NewTitle,
                Artist = NewArtist
            };

            await _db.AddSong(song);
            await Load();
        }

        //Delete Song
        private async Task DeleteSong(Song song)
        {
            await _db.DeleteSong(song);
            await Load();
        }
    }
}
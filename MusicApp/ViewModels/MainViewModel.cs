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
        private string _selectedFilePath;

        public ObservableCollection<Song> Songs { get; set; } = new();

        public string NewTitle {  get; set; }
        public string NewArtist { get; set; }

        public ICommand PlayCommand { get; }
        public ICommand PauseCommand { get; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand PickFileCommand { get; }

        public MainViewModel(DatabaseService db, AudioServices audioService)
        {
            _db = db;
            _audioService = audioService;

            AddCommand = new Command(async () => await AddSong());
            DeleteCommand = new Command<Song>(async (song) => await DeleteSong(song));
            PlayCommand = new Command<Song>(async (song) =>
            {
                if (string.IsNullOrEmpty(song?.FilePath)) return;

                await _audioService.PlayAsync(song.FilePath);
            });
            PauseCommand = new Command(() =>
            {
                _audioService.Pause();
            });
            PickFileCommand = new Command(async () => await PickFile());
            

            Task.Run(async () => await Load());
        }

        //Pick MP3 File From Phone
        private async Task PickFile()
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select MP3 file",
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.Android, new[] { "audio/mpeg", "audio/mp3" } },
                    { DevicePlatform.iOS, new[] { "public.mp3", "public.audio" } },
                    { DevicePlatform.WinUI, new[] { ".mp3", ".wav" } }
                })
            });

            if (result == null) return;

            _selectedFilePath = result.FullPath;
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
                Artist = NewArtist,
                FilePath = _selectedFilePath
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
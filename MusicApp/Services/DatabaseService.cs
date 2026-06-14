using MusicApp.Models;
using SQLite;

namespace MusicApp.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _db;

        //Init Database
        public async Task Init()
        {
            if (_db != null) return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "music.db");

            _db = new SQLiteAsyncConnection(dbPath);

            await _db.CreateTableAsync<Song>();
        }

        //Get All Songs
        public async Task<List<Song>> GetSongs()
        {
            return await _db.Table<Song>().ToListAsync();
        }

        //Add Song
        public async Task AddSong(Song song)
        {
            await _db.InsertAsync(song);
        }

        //Delete Song
        public async Task DeleteSong(Song song)
        {
            await _db.DeleteAsync(song);
        }
    }
}

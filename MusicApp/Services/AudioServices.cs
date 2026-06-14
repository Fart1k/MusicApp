using Plugin.Maui.Audio;

namespace MusicApp.Services
{
    public class AudioServices
    {
        private readonly IAudioManager _audioManager;
        private IAudioPlayer? _player;

        public AudioServices(IAudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        //Play
        public async Task PlayAsync(string filename)
        {
            if (_player != null)
            {
                _player.Stop();
                _player.Dispose();
            }

            var stream = await FileSystem.OpenAppPackageFileAsync(filename);

            _player = _audioManager.CreatePlayer(stream);

            _player.Play();
        }

        //Pause
        public void Pause()
        {
            _player?.Pause();
        }

        //Stop
        public void Stop()
        {
            _player?.Stop();
        }
    }
}

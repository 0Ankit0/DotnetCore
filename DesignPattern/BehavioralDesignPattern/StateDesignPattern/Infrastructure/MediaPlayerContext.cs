using StateDesignPattern.Models;
using StateDesignPattern.Services;
using System.Net.NetworkInformation;

namespace StateDesignPattern.Infrastructure
{
    public interface IMediaPlayerState
    {
        void Play(MediaPlayerContext context);
        void Pause(MediaPlayerContext context);
        void Stop(MediaPlayerContext context);
        void Next(MediaPlayerContext context);
        void Previous(MediaPlayerContext context);
    }

    public class MediaPlayerContext
    {
        private IMediaPlayerState _currentState;
        private List<TrackModel> _mediaFiles;
        private int _currentMediaIndex;

        public MediaPlayerContext()
        {
            _currentState = new StopState();
            _mediaFiles = new List<TrackModel>();
            _currentMediaIndex = 0;
        }

        public async Task InitializeAsync(SongService songService)
        {
            _mediaFiles = await songService.GetTracksAsync();
            _currentMediaIndex = 0;
            _currentState = new StopState();
        }

        public TrackModel CurrentMedia => _mediaFiles.Count > 0 ? _mediaFiles[_currentMediaIndex] : null;

        public string CurrentState => _currentState.GetType().Name;

        // Public property to expose media files
        public List<TrackModel> MediaFiles => _mediaFiles;

        public void SetState(IMediaPlayerState state)
        {
            _currentState = state;
        }

        public void Play()
        {
            _currentState.Play(this);
        }

        public void Pause()
        {
            _currentState.Pause(this);
        }

        public void Stop()
        {
            _currentState.Stop(this);
        }

        public void NextTrack()
        {
            if (_currentMediaIndex < _mediaFiles.Count - 1)
            {
                _currentMediaIndex++;
            }
        }

        public void PreviousTrack()
        {
            if (_currentMediaIndex > 0)
            {
                _currentMediaIndex--;
            }
        }
    }

}

using System.Net.NetworkInformation;

namespace StateDesignPattern.Infrastructure
{
    public class PlayState : IMediaPlayerState
    {
        public void Play(MediaPlayerContext context)
        {
            Console.WriteLine("Already playing.");
        }

        public void Pause(MediaPlayerContext context)
        {
            Console.WriteLine("Pausing...");
            context.SetState(new PauseState());
        }

        public void Stop(MediaPlayerContext context)
        {
            Console.WriteLine("Stopping...");
            context.SetState(new StopState());
        }

        public void Next(MediaPlayerContext context)
        {
            Console.WriteLine("Moving to next track...");
            context.NextTrack();
            context.SetState(new StopState());
        }

        public void Previous(MediaPlayerContext context)
        {
            Console.WriteLine("Moving to previous track...");
            context.PreviousTrack();
            context.SetState(new StopState());
        }
    }

}

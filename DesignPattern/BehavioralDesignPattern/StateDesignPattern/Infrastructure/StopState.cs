namespace StateDesignPattern.Infrastructure
{
    public class StopState : IMediaPlayerState
    {
        public void Play(MediaPlayerContext context)
        {
            Console.WriteLine("Playing...");
            context.SetState(new PlayState());
        }

        public void Pause(MediaPlayerContext context)
        {
            Console.WriteLine("Cannot pause. Media is stopped.");
        }

        public void Stop(MediaPlayerContext context)
        {
            Console.WriteLine("Already stopped.");
        }

        public void Next(MediaPlayerContext context)
        {
            Console.WriteLine("Moving to next track...");
            context.NextTrack();
        }

        public void Previous(MediaPlayerContext context)
        {
            Console.WriteLine("Moving to previous track...");
            context.PreviousTrack();
        }
    }

}

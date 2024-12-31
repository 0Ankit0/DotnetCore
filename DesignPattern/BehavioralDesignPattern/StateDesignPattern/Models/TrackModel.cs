namespace StateDesignPattern.Models
{
	public class TrackModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Link { get; set; }
		public int Duration { get; set; }
		public bool ExplicitLyrics { get; set; }
		public string Preview { get; set; }
		public string Md5Image { get; set; }
		public ArtistModel Artist { get; set; }
		public AlbumModel Album { get; set; }
	}

}

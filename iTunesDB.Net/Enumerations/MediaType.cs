namespace iTunesDB.Net.Enumerations
{
    // https://github.com/artm/ipod_db/blob/master/doc/ITunesDB%20-%20wikiPodLinux.html
    // type1 and type2 used to be one 2 byte field, but by it doesn't get reversed 
    // in the reversed endian iTunesDB for mobile phones, so it must be two fields.
    public enum MediaType
    {
        AudioVideo = 0x00000000,
        Audio = 0x00000001,
        Video = 0x00000002,
        Podcast = 0x00000004,
        VideoPodcast = 0x00000006,
        Audiobook = 0x00000008,
        MusicVideo = 0x00000020,
        TvShow = 0x00000040,
        TvShowForMusic = 0x00000060,
    }
}

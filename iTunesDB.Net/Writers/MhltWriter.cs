using System.IO;
using iTunesDB.Net.Database;
using iTunesDB.Net.Extensions;

namespace iTunesDB.Net
{
    public static class MhltWriter
    {
        public static void Write(iTunesDb db, BinaryWriter writer, TrackList trackList)
        {
            writer.WriteHeader("mhlt");

            // Size of the mhla header.
            writer.Write(92);

            // Album items
            writer.Write(trackList.Count);

            // Dummy Space
            writer.WriteZeroByteFields(20);
        }
    }
}

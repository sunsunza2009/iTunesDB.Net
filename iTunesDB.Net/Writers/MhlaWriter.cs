using System.IO;
using iTunesDB.Net.Database;
using iTunesDB.Net.Extensions;

namespace iTunesDB.Net
{
    public static class MhlaWriter
    {
        public static void Write(iTunesDb db, BinaryWriter writer, AlbumList albumList)
        {
            writer.WriteHeader("mhla");

            // Size of the mhla header.
            writer.Write(92);

            // Album items
            writer.Write(albumList.NumberOfAlbumItems);

            // Dummy Space
            writer.WriteZeroByteFields(20);
        }
    }
}

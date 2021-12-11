using System.IO;
using System.Linq;
using iTunesDB.Net.Database;
using iTunesDB.Net.Extensions;

namespace iTunesDB.Net
{
    public static class MhlpWriter
    {
        public static void Write(iTunesDb db, BinaryWriter writer, ListContainer listcontainer, PlayLists playLists)
        {
            writer.WriteHeader("mhlp");

            // Size of the mhlp header.
            writer.Write(92);

            // number of playlists
            writer.Write(playLists.Count());

            // Dummy Space
            writer.WriteZeroByteFields(20);

            foreach (var playList in playLists)
            {
                MhypWriter.Write(db, writer, listcontainer, (PlayList) playList);
            }
        }
    }
}

using System.IO;
using iTunesDB.Net.Database;
using iTunesDB.Net.Enumerations;
using iTunesDB.Net.Extensions;

namespace iTunesDB.Net
{
    public static class MhypWriter
    {
        public static void Write(iTunesDb db, BinaryWriter writer, ListContainer listcontainer, PlayList playList)
        {
            writer.WriteHeader("mhyp");

            // Size of the mhlp header.
            writer.Write(184);

            // TODO: Size -> Later
            writer.Write(2230);

            // MHOD Count
            // -1 -> Later
            writer.Write(playList.DataObjectChildCount);

            // MHIP Count (PlayList Items)
            writer.Write(playList.PlaylistItemCount);

            // MasterPlaylist
            writer.Write(playList.IsMasterPlaylist);

            // Write unknown bytes
            writer.Write(playList.UnkByte1);
            writer.Write(playList.UnkByte2);
            writer.Write(playList.UnkByte3);

            // Timestamp
            writer.WriteDateTimeAsMacTime(playList.Timestamp);

            // Playlist id
            writer.Write(playList.PersistentPlaylistId);

            // Write unknown bytes
            writer.Write(playList.Unk3);

            // String MHOD Count
            // TODO: Always 1?
            writer.Write(playList.StringMhodCount);

            // PodcastFlag
            writer.Write(playList.PodcastFlag);

            // ListSortOrder
            writer.Write(playList.ListSortOrder);

            // SmartPlaylist
            if (listcontainer.ListType == ListTypes.SmartPlayList)
            {
                // TODO: ...
            }
            else
            {
                // Dummy Space
                writer.WriteZeroByteFields(15);
            }

            // Dummy Space
            writer.WriteZeroByteFields(20);

            // MHOD Title
            MhodWriter.Write(writer, MhodTypes.Title, playList.Name, MhodType52SortTypes.Album);

//            if (playList.IsMasterPlaylist)
//            {
//                var playListIndexSortType =
//                    (MhodType52SortTypes) Enum.Parse(typeof(MhodType52SortTypes), playList.PlaylistIndex.ToString());
//                var playListJumpTable =
//                    (MhodType52SortTypes) Enum.Parse(typeof(MhodType52SortTypes),
//                        playList.PlaylistIndexLetterJumpTable.ToString());
//
//                // 52
//                MhodWriter.Write(writer, MhodTypes.LibraryPlayListIndex, string.Empty, playListIndexSortType);
//                // 53
//                MhodWriter.Write(writer, MhodTypes.LibraryPlayListJumpTable, string.Empty, playListJumpTable);
//            }
        }
    }
}

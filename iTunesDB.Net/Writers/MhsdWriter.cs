using System.IO;
using iTunesDB.Net.Database;
using iTunesDB.Net.Extensions;

namespace iTunesDB.Net
{
    public static class MhsdWriter
    {
        public static void Write(iTunesDb db, BinaryWriter writer)
        {
            foreach (var listcontainer in db.ListContainers)
            {
                writer.WriteHeader("mhsd");

                // Size of the mhsd header.
                writer.Write(96);

                // Size of the header and all child records
                // TODO: aktuell wie die EmptyDB, danach -1 und später wird die Größe gesetzt
                writer.Write(listcontainer.TotalSize);

                // ListType
                writer.Write((int) listcontainer.ListType);

                // Dummy Space
                writer.WriteZeroByteFields(20);

                foreach (var list in listcontainer)
                {
                    switch (list)
                    {
                        case AlbumList albumList:
                            MhlaWriter.Write(db, writer, albumList);
                            break;
                        case PlayLists playLists:
                            MhlpWriter.Write(db, writer, listcontainer, playLists);
                            break;
                        case TrackList trackList:
                            MhltWriter.Write(db, writer, trackList);
                            break;
                    }
                }
            }
        }
    }
}

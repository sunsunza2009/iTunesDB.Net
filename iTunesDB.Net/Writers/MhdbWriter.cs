using System.IO;
using iTunesDB.Net.Database;
using iTunesDB.Net.Extensions;

namespace iTunesDB.Net
{
    public static class MhdbWriter
    {
        public static void Write(iTunesDb db, BinaryWriter writer)
        {
            writer.WriteHeader("mhdb");

            // Size of the mhbd header.
            // For dbversion <= 0x15 (iTunes 7.2 and earlier), the length is 0x68.
            // For dbversion >= 0x17 (iTunes 7.3 and later), the size is 0xBC.
            writer.Write(244);

            // Size of the header and all child records (since everything is a child of MHBD,
            // this will always be the size of the entire file)
            // TODO: currently like the EmptyDB, then -1 and later the size is set 
            writer.Write(db.FileSize);

            // TODO: up-to-date like the read-in DB, later, if necessary, determine it yourself ??
            writer.Write(db.DeviceSupportsCompressedDb);

            // Version number, always 0x30, because this is the db version we support
            writer.Write(db.Version);

            // The number of MHSD children. This has been observed to be 2 (iTunes 4.8 and earlier)
            // or 3 (iTunes 4.9 and older), the third being the separate podcast library in iTunes 4.9.
            // Also it has been observed to be 4 (iTunes 7.1, 7.2) or 5 (iTunes 7.3).
            writer.Write(5);

            // Database id
            writer.Write(db.Id);

            // Platform
            writer.Write((short) db.Platform);

            // Write unknown bytes
            writer.Write(db.UnknownAt0X22);
            writer.Write(db.UnknownAt0X24);
            writer.Write(db.UnknownAt0X2C);
            writer.Write(db.UnknownAt0X30);
            writer.Write(db.UnknownAt0X32);

            // Language
            writer.WriteString(db.Language);

            // Library persistant id
            writer.Write(db.LibraryPersistantId);

            // Write unknown bytes
            writer.Write(db.UnknownAt0X50);
            writer.Write(db.UnknownAt0X54);
            writer.Write(db.UnknownAt0X58);

            // Timezone
            writer.Write(db.TimezoneOffsetInSeconds);

            // Write the rest of the unknown bytes
            writer.Write(db.UnknownBytes);
        }
    }
}

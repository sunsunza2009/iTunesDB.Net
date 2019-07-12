using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using iTunesDB.Net.Database;
using iTunesDB.Net.Enumerations;
using iTunesDB.Net.Events;

namespace iTunesDB.Net.Readers
{
    public class MhbdReader : iTunesReader
    {
        public override string ObjectID { get { return "mhbd"; } }
        public override string[] ChildIDs { get { return new string[] { "mhsd" }; } }
        public override Type DatabaseType { get { return typeof(iTunesDb); } }
        private string fileName;
        public iTunesDb Db { get { return (iTunesDb)DbObject; } }
        public event TrackReadEventHandler TrackRead;
        public delegate void TrackReadEventHandler(object sender, TrackReadEventArgs e);

        public iTunesDb Open(string FileName)
        {
            if (!File.Exists(FileName)) 
                throw new FileNotFoundException("iTunesDb file not found.", FileName);
            fileName = FileName;
            using (var fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new BinaryReader(fs))
            {
                string cname = Encoding.ASCII.GetString(reader.ReadBytes(4));
                if (!Parse(reader)) return null;
                return Db;
            }
        }

        protected override bool ParseiTunesObject(BinaryReader Reader)
        {
            Db.FileName = fileName;
            Db.FileSize = TotalSize;

            // 0x0C (4 bytes) - compressed db?
            //     2 on iPhone 3.0 and Nano 5G, 1 on iPod Color and iPod Classic
            //     the iPod Classic 3G  won't work if set to 2.
            var deviceSupportsCompressedDb = ReadInt32(Reader);

            // 0x10 (4 bytes), version number
            //     0x01: iTunes 2
            //     0x02: iTunes 3
            //     0x09: iTunes 4.2
            //     0x0a: iTunes 4.5
            //     0x0b: iTunes 4.7
            //     0x0c: iTunes 4.71/4.8 (required for shuffle)
            //     0x0d: iTunes 4.9
            //     0x0e: iTunes 5
            //     0x0f: iTunes 6
            //     0x10: iTunes 6.0.1(?)
            //     0x11: iTunes 6.0.2
            //     0x12 = iTunes 6.0.5.
            //     0x13 = iTunes 7
            //     0x14 = iTunes 7.1
            //     0x15 = iTunes 7.2
            //     0x19 = iTunes 7.4
            //     0x28 = iTunes 8.2.1
            //     0x2a = iTunes 9.0.1
            //     0x2e = iTunes 9.1
            //     0x30 = iTunes 9.2
            Db.Version = ReadInt32(Reader);

            // 0x14 (4 bytes), child count
            var childCount = ReadInt32(Reader);

            // 0x18 (8 bytes), iTunes database id
            var databaseId = ReadBytes(Reader, 8);

            // 0x20 (2 bytes), platform
            //     1 = macOS
            //     2 = Windows
            Db.Platform = ParseEnum<Platform>(ReadInt16(Reader));

            // 0x22 (2 bytes), unknown
            //     always 611?
            var unknownAt0X22 = ReadInt16(Reader); // 611?

            // 0x24 (8 bytes, iPod (db) id?
            //     no idea how to read
            var ipodid = ReadBytes(Reader, 8);

            // 0x2C (4 bytes), zero padding
            var zeroPaddingAt0X2C = ReadBytes(Reader, 4);

            // 0x30 (4 bytes), hashing scheme (0 or 1)
            var unknownAt0X30 = ReadInt16(Reader);

            // 0x32 (20 bytes), unknown
            //     SHA1-Hash?
            //     no idea how to read.
            var unknownAt0X32 = ReadBytes(Reader, 20);

            // 0x46 (2 bytes), language (de, en, ...)
            Db.Language = ReadStringUtfDetect(Reader, 2);

            // 0x48 (8 bytes), library persistant id
            //     no idea how to read
            var libraryPersistantId = ReadBytes(Reader, 8);

            // 0x50 (4 bytes), unknown
            //     0x01 = iPod Color
            //     0x05 = Nano 3G
            var unknownAt0X50 = ReadInt32(Reader);

            // 0x54 (4 bytes), unknown
            //     0x0f = iPod Color
            //     0x4d = Nano 3G
            var unknownAt0X54 = ReadInt32(Reader);

            // 0x58 (20 bytes), unknown
            //     SHA1-Hash? (hash58)
            //     no idea how to read.
            var unknownAt0X58 = ReadBytes(Reader, 20);

            // 0x6C (4 bytes), timezone offset in seconds
            Db.TimezoneOffsetInSeconds = ReadInt32(Reader);

            var unknownAt0X70 = ReadBytes(Reader, 76);

            Db.UnknownBytes = ReadRemainingBytes(Reader);

//            // 0x70 (2 bytes), Checksum Type
//            //     0x00 = Default
//            //     0x02 = Hash72
//            //     0x04 = HashAB
//            var checksumType = ReadInt16(Reader);
//
//            // 0x72 (2 bytes), unknown
//            //     hash72
//            var unknownAt0X72 = ReadBytes(Reader, 2);
//
//            // 0x74 (44 bytes), unknown
//            //     hash72
//            var unknownAt0X74 = ReadBytes(Reader, 44);
//
//            // 0xa0 (2 bytes), audio language (de, en, ...)
//            var audioLanguage = ReadStringUtfDetect(Reader, 2);
//
//            // 0xa2 (2 bytes), subtitle langauge (de, en, ...)
//            var subtitleLanguage = ReadStringUtfDetect(Reader, 2);
//
//            var zeroPaddingAt0X70 = ReadBytes(Reader, 76);

            Db.Tracks = new TrackList();
            Db.PlayLists = new PlayLists();
            Db.ListContainers = new List<ListContainer>();
            return true;
        }

        protected internal bool OnTrackRead(int TotalTracks, int TracksRead, Track Track)
        {
            bool cancel = false;
            TrackReadEventHandler handler = TrackRead;
            if (handler != null)
            {
                var args = new TrackReadEventArgs(TotalTracks, TracksRead, Track);
                foreach (TrackReadEventHandler trackRead in handler.GetInvocationList())
                {
                    trackRead(this, args);
                    if (args.Cancel)
                    {
                        cancel = true;
                        break;
                    }
                }
            }
            return !cancel;
        }
    }
}

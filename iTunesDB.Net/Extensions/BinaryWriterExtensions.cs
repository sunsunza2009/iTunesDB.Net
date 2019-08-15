using System;
using System.IO;

namespace iTunesDB.Net.Extensions
{
    public static class BinaryWriterExtensions
    {
        public static void WriteHeader(this BinaryWriter writer, string header)
        {
            writer.WriteString(header);
        }

        public static void WriteString(this BinaryWriter writer, string value)
        {
            foreach (var c in value)
            {
                writer.Write(c);
            }
        }

        public static void WriteZeroByteFields(this BinaryWriter writer, int byteCount)
        {
            for (var i = 0; i < byteCount; i++)
            {
                writer.Write(0);
            }
        }

        public static void WriteDateTimeAsMacTime(this BinaryWriter writer, DateTime time)
        {
            var s = time - new DateTime(1904, 1, 1);
            writer.Write((uint) s.TotalSeconds);
        }
    }
}

using System;
using System.IO;
using System.Text;
using iTunesDB.Net.Enumerations;
using iTunesDB.Net.Extensions;

namespace iTunesDB.Net
{
    public static class MhodWriter
    {
        public static void Write(BinaryWriter writer, MhodTypes mhodType, string text, MhodType52SortTypes album)
        {
            writer.WriteHeader("mhod");

            // Size of the mhod header.
            writer.Write(24);

            // Length = Size of header + body
            writer.Write(text.Length + 24);

            // MHOD Type
            writer.Write((int) mhodType);

            // Dummy Space
            for (int i = 0; i < 2; i++)
            {
                writer.Write(0);
            }

            // This was observed to be 2 for inversed endian ordered iTunesDBs for mobile phones with UTF8 strings and 1 for standard iPod iTunesDBs with UTF16 strings. 
            writer.Write(1);

            // Size of string
            writer.Write(text.Length);

            // Dummy Space
            for (int i = 0; i < 8; i++)
            {
                writer.Write(0);
            }

            // Text
            writer.Write(Encoding.Unicode.GetBytes(text));

            switch (mhodType)
            {
                case MhodTypes.Title:
                    break;
                case MhodTypes.Location:
                    break;
                case MhodTypes.Album:
                    break;
                case MhodTypes.Artist:
                    break;
                case MhodTypes.Genre:
                    break;
                case MhodTypes.FileType:
                    break;
                case MhodTypes.EqSetting:
                    break;
                case MhodTypes.Comment:
                    break;
                case MhodTypes.Category:
                    break;
                case MhodTypes.Composer:
                    break;
                case MhodTypes.Grouping:
                    break;
                case MhodTypes.Description:
                    break;
                case MhodTypes.PodcastEnclosureUrl:
                    break;
                case MhodTypes.PodcastRssUrl:
                    break;
                case MhodTypes.ChapterData:
                    break;
                case MhodTypes.Subtitle:
                    break;
                case MhodTypes.TvShow:
                    break;
                case MhodTypes.TvShowEpisodeNumber:
                    break;
                case MhodTypes.TvNetwork:
                    break;
                case MhodTypes.AlbumArtist:
                    break;
                case MhodTypes.SortByArtistName:
                    break;
                case MhodTypes.Keywords:
                    break;
                case MhodTypes.LocaleForTvShow:
                    break;
                case MhodTypes.SortByTitle:
                    break;
                case MhodTypes.SortByAlbum:
                    break;
                case MhodTypes.SortByAlbumArtist:
                    break;
                case MhodTypes.SortByComposer:
                    break;
                case MhodTypes.SortByTvShow:
                    break;
                case MhodTypes.Unknown:
                    break;
                case MhodTypes.SmartPlayListSettings:
                    break;
                case MhodTypes.SmartPlayListRules:
                    break;
                case MhodTypes.LibraryPlayListIndex:
                    break;
                case MhodTypes.LibraryPlayListJumpTable:
                    break;
                case MhodTypes.ColumnSizingOrPlaylistOrderIndicator:
                    break;
                case MhodTypes.AlbumListAlbum:
                    break;
                case MhodTypes.AlbumListArtist:
                    break;
                case MhodTypes.AlbumListSortByArtist:
                    break;
                case MhodTypes.AlbumListPodcastUrl:
                    break;
                case MhodTypes.AlbumListTvShow:
                    break;
                case MhodTypes.AlbumListArtistMhii:
                    break;
                case MhodTypes.Copyright:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mhodType), mhodType, null);
            }
        }
    }
}

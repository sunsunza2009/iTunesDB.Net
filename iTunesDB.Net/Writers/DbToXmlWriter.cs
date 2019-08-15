using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using iTunesDB.Net.Database;
using iTunesDB.Net.Enumerations;
using iTunesDB.Net.Extensions;

namespace iTunesDB.Net.Writers
{
    public class DbToXmlWriter
    {
        public string GetXml(iTunesDb db)
        {
            var stringBuilder = new StringBuilder();
            using (var xmlWriter = XmlWriter.Create(stringBuilder))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("mhbd");
                xmlWriter.WriteAttributeString("dbversion", db.Version.ToString());

                WriteListContainerToXml(db.ListContainers, xmlWriter);

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }

            return stringBuilder.ToString();
        }

        private void WriteListContainerToXml(List<ListContainer> listContainers, XmlWriter xmlWriter)
        {
            foreach (var listContainer in listContainers)
            {
                foreach (var list in listContainer)
                {
                    xmlWriter.WriteStartElement("mhsd");

                    WriteListToXml(list, xmlWriter);

                    xmlWriter.WriteEndElement();
                }
            }
        }

        private void WriteListToXml(DbList list, XmlWriter xmlWriter)
        {
            switch (list)
            {
                case AlbumList albumList:
                    WriteAlbumListToXml(albumList, xmlWriter);
                    break;
                case PlayLists playLists:
                    WritePlayListToXml(playLists, xmlWriter);
                    break;
                case TrackList trackList:
                    WriteTrackListToXml(trackList, xmlWriter);
                    break;
            }
        }

        private void WriteAlbumListToXml(AlbumList albumList, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("mhla");

            foreach (var albumItem in albumList)
            {
                WriteAlbumItemToXml((AlbumItem) albumItem, xmlWriter);
            }

            xmlWriter.WriteNode(nameof(albumList.NumberOfAlbumItems), albumList.NumberOfAlbumItems.ToString());

            xmlWriter.WriteEndElement();
        }

        private void WriteAlbumItemToXml(AlbumItem albumItem, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("mhia");

            xmlWriter.WriteNode(nameof(albumItem.NumberOfStrings),
                albumItem.NumberOfStrings.ToString());
            xmlWriter.WriteNode(nameof(albumItem.Unknown1),
                albumItem.Unknown1.ToString());
            xmlWriter.WriteNode(nameof(albumItem.AlbumId),
                albumItem.AlbumId.ToString());
            xmlWriter.WriteNode(nameof(albumItem.Unknown2),
                albumItem.Unknown2.ToString(CultureInfo.InvariantCulture));
            xmlWriter.WriteNode(nameof(albumItem.Unknown3),
                albumItem.Unknown3.ToString());

            xmlWriter.WriteNodeWithAttribute("mhod", albumItem.AlbumListArtist, "type",
                ((int) DataObjects.AlbumListArtist).ToString());

            xmlWriter.WriteNodeWithAttribute("mhod", albumItem.AlbumListAlbum, "type",
                ((int) DataObjects.AlbumListAlbum).ToString());

            xmlWriter.WriteNodeWithAttribute("mhod", albumItem.AlbumListArtistSort, "type",
                ((int) DataObjects.AlbumListArtistSort).ToString());

            xmlWriter.WriteEndElement();
        }

        private void WritePlayListToXml(PlayLists playLists, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("mhlp");

            foreach (var playList in playLists)
            {
                WritePlayListToXml((PlayList) playList, xmlWriter);
            }

            xmlWriter.WriteEndElement();
        }

        private void WritePlayListToXml(PlayList playList, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("mhyp");

            foreach (var playListItem in playList)
            {
                WritePlayListItemToXml(playListItem, xmlWriter);
            }

            xmlWriter.WriteNode(nameof(playList.DataObjectChildCount), playList.DataObjectChildCount.ToString());
            xmlWriter.WriteNode(nameof(playList.PlaylistItemCount), playList.PlaylistItemCount.ToString());
            xmlWriter.WriteNode(nameof(playList.IsMasterPlaylist), playList.IsMasterPlaylist.ToString());
            xmlWriter.WriteNode(nameof(playList.UnkByte1), playList.UnkByte1.ToString());
            xmlWriter.WriteNode(nameof(playList.UnkByte2), playList.UnkByte2.ToString());
            xmlWriter.WriteNode(nameof(playList.UnkByte3), playList.UnkByte3.ToString());
            xmlWriter.WriteNode(nameof(playList.Timestamp), playList.Timestamp.ToString(CultureInfo.InvariantCulture));
            xmlWriter.WriteNode(nameof(playList.PersistentPlaylistId), playList.PersistentPlaylistId.ToString());
            xmlWriter.WriteNode(nameof(playList.Unk3), playList.Unk3.ToString());
            xmlWriter.WriteNode(nameof(playList.StringMhodCount), playList.StringMhodCount.ToString());
            xmlWriter.WriteNode(nameof(playList.PodcastFlag), playList.PodcastFlag.ToString());
            xmlWriter.WriteNode(nameof(playList.ListSortOrder), ((int) playList.ListSortOrder).ToString());

            xmlWriter.WriteNodeWithAttribute("mhod", playList.Name, "type",
                ((int) DataObjects.Title).ToString());

            xmlWriter.WriteNodeWithAttribute("mhod", playList.PlaylistIndex.ToString(), "type",
                ((int) DataObjects.LibraryPlaylistIndex).ToString());

            xmlWriter.WriteNodeWithAttribute("mhod", playList.PlaylistIndexLetterJumpTable.ToString(), "type",
                ((int) DataObjects.LibraryPlaylistIndexLetterJumpTable).ToString());

            xmlWriter.WriteNodeWithAttribute("mhod", playList.SizingAndOrder.ToString(), "type",
                ((int) DataObjects.SizingAndOrder).ToString());

            xmlWriter.WriteNodeWithAttribute("mhod", playList.Unknown2, "type",
                ((int) DataObjects.Unknown2).ToString());

            xmlWriter.WriteEndElement();
        }

        private void WritePlayListItemToXml(PlayListItem playListItem, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("mhip");

            xmlWriter.WriteNode(nameof(playListItem.DataObjectChildCount),
                playListItem.DataObjectChildCount.ToString());
            xmlWriter.WriteNode(nameof(playListItem.PodcastGroupingFlag), playListItem.PodcastGroupingFlag.ToString());
            xmlWriter.WriteNode(nameof(playListItem.Unk4), playListItem.Unk4.ToString());
            xmlWriter.WriteNode(nameof(playListItem.Unk5), playListItem.Unk5.ToString());
            xmlWriter.WriteNode(nameof(playListItem.GroupId), playListItem.GroupId.ToString());
            xmlWriter.WriteNode(nameof(playListItem.TrackId), playListItem.TrackId.ToString());
            xmlWriter.WriteNode(nameof(playListItem.Timestamp),
                playListItem.Timestamp.ToString(CultureInfo.InvariantCulture));
            xmlWriter.WriteNode(nameof(playListItem.PodcastGroupingReference),
                playListItem.PodcastGroupingReference.ToString());

            xmlWriter.WriteNodeWithAttribute("mhod", playListItem.SizingAndOrder.ToString(), "type",
                ((int) DataObjects.SizingAndOrder).ToString());

            xmlWriter.WriteEndElement();
        }

        private void WriteTrackListToXml(TrackList trackList, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("mhlt");

            foreach (var track in trackList)
            {
                WriteTrackToXml((Track)track, xmlWriter);
            }

            xmlWriter.WriteEndElement();
        }

        private void WriteTrackToXml(Track track, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("mhit");

            xmlWriter.WriteNode(nameof(track.NumberOfStrings), track.NumberOfStrings.ToString());
            xmlWriter.WriteNode(nameof(track.TrackID), track.TrackID.ToString());
            xmlWriter.WriteNode(nameof(track.Visible), track.Visible.ToString());
            xmlWriter.WriteNode(nameof(track.FileType), track.FileType);
            xmlWriter.WriteNode(nameof(track.CodingFormat), ((int)track.CodingFormat).ToString());
            xmlWriter.WriteNode(nameof(track.Compilation), track.Compilation.ToString());
            xmlWriter.WriteNode(nameof(track.Rating), track.Rating.ToString());
            xmlWriter.WriteNode(nameof(track.LastModified), track.LastModified.ToString(CultureInfo.InvariantCulture));
            xmlWriter.WriteNode(nameof(track.SizeBytes), track.SizeBytes.ToString());
            xmlWriter.WriteNode(nameof(track.Length), track.Length.ToString());
            xmlWriter.WriteNode(nameof(track.TrackNumber), track.TrackNumber.ToString());
            xmlWriter.WriteNode(nameof(track.TrackCount), track.TrackCount.ToString());
            xmlWriter.WriteNode(nameof(track.Year), track.Year.ToString());
            xmlWriter.WriteNode(nameof(track.BitRate), track.BitRate.ToString());
            xmlWriter.WriteNode(nameof(track.SampleRate), track.SampleRate.ToString(CultureInfo.InvariantCulture));
            xmlWriter.WriteNode(nameof(track.Volume), track.Volume.ToString());
            xmlWriter.WriteNode(nameof(track.StartTime), track.StartTime.ToString());
            xmlWriter.WriteNode(nameof(track.StopTime), track.StopTime.ToString());
            xmlWriter.WriteNode(nameof(track.SoundCheck), track.SoundCheck.ToString());
            xmlWriter.WriteNode(nameof(track.PlayCount), track.PlayCount.ToString());
            xmlWriter.WriteNode(nameof(track.PlayCountSinceLastSync), track.PlayCountSinceLastSync.ToString());
            xmlWriter.WriteNode(nameof(track.LastPlayed), track.LastPlayed.ToString());
            xmlWriter.WriteNode(nameof(track.DiscNumber), track.DiscNumber.ToString());
            xmlWriter.WriteNode(nameof(track.DiscCount), track.DiscCount.ToString());
            xmlWriter.WriteNode(nameof(track.UserID), track.UserID.ToString());
            xmlWriter.WriteNode(nameof(track.DateAdded), track.DateAdded.ToString(CultureInfo.InvariantCulture));
            xmlWriter.WriteNode(nameof(track.BookmarkTime), track.BookmarkTime.ToString());
            xmlWriter.WriteNode(nameof(track.PersistentID), track.PersistentID);
            xmlWriter.WriteNode(nameof(track.Checked), track.Checked.ToString());
            xmlWriter.WriteNode(nameof(track.ApplicationRating), track.ApplicationRating.ToString());
            xmlWriter.WriteNode(nameof(track.BPM), track.BPM.ToString());

            xmlWriter.WriteNodeWithAttribute("mhod", track.FileType, "type",
                ((int) DataObjects.FileType).ToString());

            xmlWriter.WriteNodeWithAttribute("mhod", track.Name, "type",
                    ((int) DataObjects.Title).ToString());

            xmlWriter.WriteNodeWithAttribute("mhod", track.Comments, "type",
                    ((int) DataObjects.Comment).ToString());

            xmlWriter.WriteEndElement();
        }
    }
}

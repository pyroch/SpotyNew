using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyNew.Spotify
{
    public static class Extensions
    {
        public static void Add(this List<Tuple<string, string, DateTime>> list, string x, string y, DateTime z)
        {
            list.Add(new Tuple<string, string, DateTime>(x, y, z));
        }
    }

    class TrackList
    {
        static List<string> myArtistsIds;
        static List<Tuple<string, string, DateTime>> lastTracksList;

        public static string GetTrackList(SpotifyClient spotify, int amount, string userId)
        {

            List<string> myArtistsIds = new List<string>(); // global list of artists Id's.
            List<Tuple<string, string, DateTime>> lastTracksList = new List<Tuple<string, string, DateTime>>();

            if (spotify == null)
                return null;

            var userPlaylists = spotify.Playlists.GetUsers(userId).Result;

            if (amount > userPlaylists.Items.Count)
            {
                return "You don't have that amount of playlists. (" + userPlaylists.Items.Count + " max)";
            }

            for (int i = 0; i < amount; i++)
            {
                GetTracks(userPlaylists.Items[i].Id, spotify); // calls function that gets artists Id's
            }

            var fArtistIds = myArtistsIds.Distinct(); // getting rid of duplicates.

            foreach (string artistId in fArtistIds)
            {
                if (artistId != null)
                    GetLastAlbum(artistId, spotify);
            }

            var result = lastTracksList.OrderByDescending(x => x.Item3);

            var ts = string.Join("", result.Select(t => string.Format("{0} - {1}, {2}\n", t.Item1, t.Item2, t.Item3.ToString("dd/MM/yyyy"))));
            return ts;
        }


        public static List<Tuple<string, string, DateTime>> GetTrackListTuple(SpotifyClient spotify, int amount, string userId)
        {
            myArtistsIds = new List<string>(); // global list of artists Id's.
            lastTracksList = new List<Tuple<string, string, DateTime>>();

            if (spotify == null)
                return null;

            if (userId == "")
                return null;

            try
            {

                var userPlaylists = spotify.Playlists.GetUsers(userId).Result;


                if (amount > userPlaylists.Items.Count)
                {
                    return null;
                }

                for (int i = 0; i < amount; i++)
                {
                    GetTracks(userPlaylists.Items[i].Id, spotify); // calls function that gets artists Id's
                }
                var fArtistIds = myArtistsIds.Distinct(); // getting rid of duplicates.

                foreach (string artistId in fArtistIds)
                {
                    if (artistId != null)
                        GetLastAlbum(artistId, spotify);
                }

                var result = lastTracksList.OrderByDescending(x => x.Item3);

                return lastTracksList;
            }
            catch
            {
                return null;
            }
        }
        static void GetTracks(string playlistId, SpotifyClient spotify) // function that gets Id's of artists from list of tracks in playlist.
        {
            var playlist = spotify.Playlists.Get(playlistId).Result;
            foreach (PlaylistTrack<IPlayableItem> item in playlist.Tracks.Items)
            {
                if (item.Track is FullTrack track)
                {
                    myArtistsIds.Add(track.Artists[0].Id);
                }
            }
        }

        static void GetLastAlbum(string artistId, SpotifyClient spotify)
        {
            var getAlbumsOfArtist = spotify.Artists.GetAlbums(artistId).Result.Items;

            DateTime d1 = new DateTime();
            DateTime d2;

            int lastTrack = 0;
            for (int i = 0; i < getAlbumsOfArtist.Count; i++)
            {
                if (d1 == DateTime.MinValue)
                {
                    DateTime.TryParse(getAlbumsOfArtist[i].ReleaseDate, out d1);
                }
                if (DateTime.TryParse(getAlbumsOfArtist[i].ReleaseDate, out d2))
                {
                    if (d1 < d2)
                    {
                        d1 = d2;
                        lastTrack = i;
                    }
                }
            }
            DateTime trackDate = (DateTime)d1;
            lastTracksList.Add(spotify.Artists.Get(artistId).Result.Name, getAlbumsOfArtist[lastTrack].Name, trackDate); // add info about artist, track name, release date to list so can sort it whenever later
            System.Threading.Thread.Sleep(50);
        } // function that gets last track/album of artist using the list of artists Id's from previous function.
    }
}

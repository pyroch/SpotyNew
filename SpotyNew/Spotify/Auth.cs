using SpotifyAPI.Web;
using System.Threading.Tasks;

namespace SpotyNew.Spotify
{
    class Auth
    {
        public static async Task<SpotifyClient> GetAuth()
        {
            var config = SpotifyClientConfig.CreateDefault();

            var request = new ClientCredentialsRequest(Custom.Config.userConfig.clientId, Custom.Config.userConfig.clientSecret);
            var response = await new OAuthClient(config).RequestToken(request);

            var spotify = new SpotifyClient(config.WithToken(response.AccessToken));

            return spotify;
        }
    }
}

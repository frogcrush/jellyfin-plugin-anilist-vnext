using System.Globalization;
using System.Linq;

using AnitomySharp;

namespace Jellyfin.Plugin.AniList.Anitomy
{
    public class AnitomyHelper
    {
        public static string ExtractAnimeTitle(string path)
        {
            string input = path;
            var elements = AnitomySharp.AnitomySharp.Parse(input);
            return elements.FirstOrDefault(p => p.Category == Element.ElementCategory.ElementAnimeTitle).Value;
        }

        public static string ExtractEpisodeTitle(string path)
        {
            var elements = AnitomySharp.AnitomySharp.Parse(path);
            return elements.FirstOrDefault(p => p.Category == Element.ElementCategory.ElementEpisodeTitle).Value;
        }

        public static int? ExtractEpisodeNumber(string path)
        {
            var elements = AnitomySharp.AnitomySharp.Parse(path);
            var value = elements.FirstOrDefault(p => p.Category == Element.ElementCategory.ElementEpisodeNumber)?.Value;
            return value != null ? int.Parse(value, CultureInfo.InvariantCulture) : null;
        }

        public static int? ExtractSeasonNumber(string path)
        {
            var elements = AnitomySharp.AnitomySharp.Parse(path);
            var value = elements.FirstOrDefault(p => p.Category == Element.ElementCategory.ElementAnimeSeason)?.Value;
            return value != null ? int.Parse(value, CultureInfo.InvariantCulture) : null;
        }
    }
}

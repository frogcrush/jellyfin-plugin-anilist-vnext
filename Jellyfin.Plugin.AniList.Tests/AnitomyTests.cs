using System;
using System.Collections.Generic;
using System.Text;

namespace Jellyfin.Plugin.AniList.Tests
{
    public class AnitomyTests
    {
        [Theory]
        [InlineData("[Cerberus] Toaru Majutsu no Index [BD 1080p HEVC 10-bit OPUS] [Dual-Audio]", "Toaru Majutsu no Index")]
        public void ExtractAnimeTitle_ShouldExtractTitle(string input, string expected)
        {
            string actual = Anitomy.AnitomyHelper.ExtractAnimeTitle(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Bakuten Shoot Beyblade - 01 - The Blade Raider.mkv", "The Blade Raider")]
        public void ExtractEpisodeTitle_ShouldExtractEpisodeTitle(string input, string expected)
        {
            string actual = Anitomy.AnitomyHelper.ExtractEpisodeTitle(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("[Cerberus] Toaru Majutsu no Index - S01E01 [2E32AB96].mkv", 1)]
        [InlineData("[Coalgirls]_Gochuumon_wa_Usagi_Desu_ka_01_(1920x1080_Blu-ray_FLAC)_[D00C684B].mkv", 1)]
        [InlineData("[Commie] Ookami Shoujo to Kuro Ouji - 11 [BD 720p AAC] [1C255A83].mkv", 11)]
        public void ExtractEpisodeNumber_ShouldExtractEpisodeNumber(string input, int expected)
        {
            var actual = Anitomy.AnitomyHelper.ExtractEpisodeNumber(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Accel World", null)]
        [InlineData("[Cerberus] Seikon no Qwaser II - S02E01 - [7102F4EE].mkv", 2)]
        public void ExtractSeasonNumber_ShouldExtractSeasonNumber(string input, int? expected)
        {
            var actual = Anitomy.AnitomyHelper.ExtractSeasonNumber(input);
            Assert.Equal(expected, actual);
        }
    }
}

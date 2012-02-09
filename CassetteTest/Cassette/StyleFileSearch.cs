using System;
using System.Collections.Generic;
using Cassette.Configuration;

namespace CassetteTest.Cassette
{
    /// <summary>
    /// Default Cassette FileSearch for selecting style files.
    /// </summary>
    public class StyleFileSearch : CoreFileSearch, IFileSearch
    {
        public StyleFileSearch( IList<String> exclusionRegexPatterns = null )
            : base( exclusionRegexPatterns )
        {
            Pattern = StyleFileNamePattern;
        }
    }
}
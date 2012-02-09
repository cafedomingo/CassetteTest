using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Cassette.Configuration;

namespace CassetteTest.Cassette
{
    /// <summary>
    /// Generic Cassette FileSearch for selecting and excluding standard file types.
    /// Excludes:
    ///  - Directories starting with "_"
    ///  - dotLess files starting with "_"
    ///  - Files ending with "min.css", "min.js" or "vsdoc.js"
    /// </summary>
    public abstract class CoreFileSearch : FileSearch, IFileSearch
    {
        /// <summary>
        /// Default pattern for matching script files
        /// </summary>
        protected const String ScriptFileNamePattern = "*.js;*.coffee";

        /// <summary>
        /// Default pattern for matching style files
        /// </summary>
        protected const String StyleFileNamePattern = "*.css;*.less;";

        /// <summary>
        /// Default set of regular expressions for excluding undesired files and directories from bundles
        /// </summary>
        private static readonly IList<String> DefaultExclusionRegexPatterns = new List<String>()
            {
              @"([\\/]_.*)",           //Directories starting with a "_"
              @"([\.-](vsdoc\.js)$)",  //Files ending with vsdoc.js
              @"([\.-](min\.js)$)",    //Files ending with min.js
              @"([\.-](min\.css)$)",   //Files ending with min.css
              @"(_.*\.less$)"          //Files starting with "_" and ending with .less
            };

        protected CoreFileSearch( IList<String> exclusionRegexPatterns = null )
            : base()
        {
            IList<String> allExclusionRegexPatterns = exclusionRegexPatterns == null || !exclusionRegexPatterns.Any()
                ? DefaultExclusionRegexPatterns
                : DefaultExclusionRegexPatterns.Concat( exclusionRegexPatterns ).ToList();

            SearchOption = System.IO.SearchOption.AllDirectories;
            Exclude = new Regex( String.Join( "|", allExclusionRegexPatterns ), RegexOptions.IgnorePatternWhitespace );
        }
    }
}
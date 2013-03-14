// QueryString.cs
// Extended C# QueryString Library
// https://github.com/faisalman/querystring-cs
//
// MIT License
// Copyright © 2013 Faisalman <fyzlman@gmail.com>

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Faisalman.Utils
{
  public class QueryString
  {
    const string urlPattern = @"^https?:\/\/.+\/.*?\?";

    /// <summary>
    /// Build new url from the specified base url and list of queries.
    /// </summary>
    /// <param name='url'>
    /// Base URL.
    /// </param>
    /// <param name='queries'>
    /// Query list to be joined.
    /// </param>
    public static string Build (string url, Dictionary<string, string> queries) {
      return url + "?" + QueryString.Join(queries);
    }

    /// <summary>
    /// Join the specified queries.
    /// </summary>
    /// <param name='queries'>
    /// Query list to be joined.
    /// </param>
    public static string Join (Dictionary<string, string> queries) {
      string querystr = "";
      foreach (KeyValuePair<string, string> query in queries)
      {
        querystr += query.Key + "=" + query.Value + "&";
      }
      return querystr.Substring(0, querystr.Length - 1);
    }

    /// <summary>
    /// Parse the specified url into list of queries.
    /// </summary>
    /// <param name='url'>
    /// URL contains querystring to be parsed.
    /// </param>
    public static Dictionary<string, string> Parse (string url)
    {
      Dictionary<string, string> queries = new Dictionary<string, string>();
      string querystr = Regex.Replace(url, urlPattern, string.Empty);
      foreach (string query in querystr.Split(new string[] { "&amp;", "&" }, StringSplitOptions.None))
      {
        string[] keyVal = query.Split(new char[] { '=' });
        queries.Add(keyVal[0], keyVal[1]);
      }
      return queries;
    }
  }
}
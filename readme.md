# QueryString.cs

Extended C# QueryString Library

## Example

```cs
using System;
using System.Collections.Generic;
using Faisalman.Utils;

class Program
{
  public static void Main (string[] args)
  {
    string url = "http://google.com/search";
    var queries = new Dictionary<string, string>
    {
      { "q", "querystring.cs" },
      { "hl", "en" },
      { "ref", "faisalman" }
    };
    string query = QueryString.Build(url, queries);
    Console.WriteLine(query); // http://google.com/search?q=querystring.cs&hl=en&ref=faisalman
    
    var queries2 = QueryString.Parse(query);
    Console.WriteLine(queries2["ref"]); // faisalman
  }
}
```

## License

MIT License

Copyright © 2013 Faisalman <<fyzlman@gmail.com>>

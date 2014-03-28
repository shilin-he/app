using System;
using System.Collections.Generic;

namespace app.console
{
  public class Bootstrap
  {
    public static void Main(string[] args)
    {
      var listener = new NameListener();
      var zip_listener = new ExtensionListener(".tmp");
      var dmg_listener = new ExtensionListener(".exe");
        var pattern = new PatternListener("Set");

      var total_size = 0L;
      FoundFile size_listener = (sender, eargs) =>
      {
        total_size += eargs.file.Length;
      };

      Finder.run(new SearchOptions
      {
//        path = @"Z:\tempfilestempfiles\downloads"
        path = @"C:\temp"
      }, 
      listener.record_file_name,
      size_listener,
      zip_listener.extension_file_name,
      dmg_listener.extension_file_name,
      pattern.pattern_file_name
      );

      listener.dump();
      zip_listener.dump();
      dmg_listener.dump();
      pattern.dump();

      Console.Out.WriteLine("Total size of all files is: {0}mb", total_size / 1024);
    } 
  }
}
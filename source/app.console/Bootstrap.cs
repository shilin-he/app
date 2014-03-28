using System;
using System.Collections.Generic;

namespace app.console
{
  public class Bootstrap
  {
    public static void Main(string[] args)
    {
      var listener = new NameListener();
      var zip_listener = new ExtensionListener(".zip");
      var dmg_listener = new ExtensionListener(".dmg");

      var total_size = 0L;
      FoundFile size_listener = (sender, eargs) =>
      {
        total_size += eargs.file.Length;
      };

      Finder.run(new SearchOptions
      {
        path = @"Z:\tempfiles\downloads"
      }, 
      listener.record_file_name,
      size_listener
      );

      listener.dump();
      zip_listener.dump();
      dmg_listener.dump();

      Console.Out.WriteLine("Total size of all files is: {0}mb", total_size / 1024);
    } 
  }
}
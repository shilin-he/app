using System;
using System.IO;

namespace app.console.filelisteners
{
  public class Finder
  {
    public event FoundFile file_found = delegate
    {
      
    };

    protected void on_file_found(FileFoundArgs args)
    {
      file_found(this, args); 
    }

    public void search(SearchOptions options)
    {
      var start_time = DateTime.Now;
      foreach (var file_name in Directory.GetFiles(options.path))
      {
        var found_file = new FileInfo(file_name);
        on_file_found(new FileFoundArgs
        {
          file = found_file,
          elapsed_time_since_start_of_search = DateTime.Now - start_time,
          found_at = DateTime.Now
        });
      }
    }

    public static void run(SearchOptions options, params FoundFile[] listeners)
    {
      var finder = new Finder();
      foreach (var listener in listeners) finder.file_found += listener; 
      finder.search(options);
    }
  }

  public class SearchOptions
  {
    public string path { get; set; }
  }
}

/*Find Results:

      Name Listener: 
          name1
          name1
          name1
     
      Size Listener: Total of (2.4mb) found
     
      Average Time To Find Listener: Average latency between hits = (x ms)
    */
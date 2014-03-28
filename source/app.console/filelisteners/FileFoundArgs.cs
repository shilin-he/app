using System;
using System.IO;

namespace app.console.filelisteners
{
  public class FileFoundArgs : EventArgs
  {
    public FileInfo file { get; set; } 
    public DateTime found_at { get; set; } 
    public TimeSpan elapsed_time_since_start_of_search { get; set; } 
  }
}
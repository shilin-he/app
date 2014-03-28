using System;
using System.Collections.Generic;

namespace app.console.filelisteners
{
  public class NameListener
  {
    IList<string> files_found;

    public NameListener()
    {
      files_found = new List<string>();
    }

    public void record_file_name(object sender, FileFoundArgs args)
    {
      files_found.Add(args.file.FullName);
    }

    public void dump()
    {
      foreach (var file in files_found)
      {
        Console.Out.WriteLine("I found the file :{0}", file); 
      } 
    }
  }
}
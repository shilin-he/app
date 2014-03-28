using System;

namespace app.console
{
  public class ExtensionListener
  {
    int number;
    string extension;

    public ExtensionListener(string extension)
    {
      this.extension = extension;
    }

    public void dump()
    {
      Console.Out.WriteLine("I found {0} files with the extension {1}", number, extension);
    }
  }
}
using System;

namespace app.console
{
    public class PatternListener
    {
        int number;
        string pattern;

        public PatternListener(string pattern)
        {
            this.pattern = pattern;
        }

        public void pattern_file_name(object sender, FileFoundArgs args)
        {
            if (args.file.Name.ToUpper().IndexOf(pattern.ToUpper()) >= 0)
            {
                number++;
            }
        }

        public void dump()
        {
            Console.Out.WriteLine("I found {0} files with the pattern {1}", number, pattern);
        }
    }
}
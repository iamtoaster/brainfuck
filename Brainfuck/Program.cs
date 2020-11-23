using System;
using System.IO;
using System.Text;

namespace Brainfuck
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[] { "hello.txt" }; // test
            if (args.Length == 1)
            {
                var app = "";
                using (FileStream fs = File.Open(args[0], FileMode.Open))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);

                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        app += temp.GetString(b);
                    }
                }

                VM.Execute(app);
            }
            else
            {
                Console.WriteLine("You need to supply file.");
                return;
            }

            return;
        }
    }
}

using System;
using System.IO;

namespace IceTest02
{
    class Program
    {

        static void Main(string[] args)
        {
            var fs01 = new FileStream(@"C:\\downloads\\_code\\ICE01\\IceTest01\\icesample02a.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            var fs02 = new FileStream(@"C:\\downloads\\_code\\ICE01\\IceTest01\\icesample02b.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                var reader01 = new StreamReader(fs01);
                var reader02 = new StreamReader(fs02);
                try
                {
                    string line01 = reader01.ReadLine();
                    string line02 = reader02.ReadLine();

                    while ((line01 != null) || (line02 != null))
                    {
                        if (line01 == null)
                        {
                            Console.WriteLine(line02);
                            line02 = reader02.ReadLine();
                        }
                        if (line02 == null)
                        {
                            Console.WriteLine(line01);
                            line01 = reader01.ReadLine();
                        }
                        if (string.Compare(line01, line02) <= 0)
                        {
                            Console.WriteLine(line01);
                            line01 = reader01.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine(line02);
                            line02 = reader02.ReadLine();
                        }
                    }
                }
                finally
                {
                    reader02.Close();
                    reader01.Close();
                }
            }
            finally
            {
                fs02.Close();
                fs01.Close();
            }

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}

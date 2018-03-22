using System;
using System.IO;

namespace IceTest01
{
    class Program
    {
        public static bool IsCUSIP(string line)
        {
            if (!string.IsNullOrEmpty(line))
            {
                if ((line.Length == 8) && (!line.Contains(".")))
                {
                    return true;
                }
            }
            return false;
        }


        public static void Main(string[] args)
        {
            var fs = new FileStream(@"C:\\downloads\\_code\\ICE01\\IceTest01\\icesample01.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                var reader = new StreamReader(fs);
                try
                {
                    var curBond = string.Empty;
                    decimal curPrice = (decimal)-1;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (IsCUSIP(line))
                        {
                            if (!string.IsNullOrEmpty(curBond) && (curPrice >= 0))
                            {
                                Console.WriteLine("{0} {1}", curBond, curPrice);
                                curBond = line;
                                curPrice = -1;
                            }
                            else
                            {
                                curBond = line;
                            }
                        }
                        else
                        {
                            decimal.TryParse(line, out curPrice);
                        }
                    }
                    if (!string.IsNullOrEmpty(curBond) && (curPrice >= 0))
                    {
                        Console.WriteLine("{0} {1}", curBond, curPrice);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {
                fs.Close();
            }

            Console.WriteLine("Done.");
            Console.ReadLine();

        }
    }
}

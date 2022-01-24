using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace DictionaryExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string tempPath = Path.GetTempPath();

            Dictionary<string, int> voteCount = new Dictionary<string, int>();

            try
            {
                Console.WriteLine("---------Dictionary structure example---------");
                Console.WriteLine("\n\n\n     Trying to find 'in.tx' at the system's temp directory");
                Console.Write("\n     .");
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.Write(".");
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.Write(".");
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.Write(".");
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.Write(".");
                Thread.Sleep(TimeSpan.FromSeconds(0.5));


                if (File.Exists(tempPath + "in.txt"))
                {
                    string[] lines = File.ReadAllLines(tempPath + "in.txt");

                    Console.Clear();

                    Console.WriteLine("FILE READING: ");

                    foreach (string line in lines)
                    {
                        int index = line.IndexOf(',');
                        int voteIndex = (line.Length - index) - 1;

                        Console.WriteLine("Name: " + line.Substring(0, index));
                        Console.WriteLine("Votes: " + line.Substring(index + 1, voteIndex));

                        if(voteCount.TryAdd(line.Substring(0, index), int.Parse(line.Substring(index + 1, voteIndex))))
                            continue;
                        else
                        {
                            int count = 0;
                            count = voteCount[line.Substring(0, index)];
                            count = count + int.Parse(line.Substring(index + 1, voteIndex));
                            voteCount[line.Substring(0, index)] = count;
                        }

                    }

                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("VOTE SUMMATION:");

                    foreach (var candidate in voteCount)
                    {
                        Console.WriteLine("\n" + candidate.ToString());
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("---------Dictionary structure example---------");
                    Console.WriteLine("\n\n    The file was not found");

                    Console.WriteLine("\nCreating 'in.txt' at the system temp directory");
                    using(FileStream fs = new FileStream(tempPath + "in.txt", FileMode.Create))
                    {
                        using(StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine("Alex Blue,15");
                            sw.WriteLine("Maria Green,22");
                            sw.WriteLine("Bob Brown,21");
                            sw.WriteLine("Alex Blue,30");
                            sw.WriteLine("Bob Brown,15");
                            sw.WriteLine("Maria Green,27");
                            sw.WriteLine("Maria Green,22");
                            sw.WriteLine("Bob Brown,25");
                            sw.WriteLine("Alex Blue,31");
                        }
                    }
                    Console.Write("\n.");
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    Console.Write(".");
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    Console.Write(".");
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    Console.Write(".");
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    Console.Write(".");
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));

                    Console.WriteLine("\n\n\nThe file was successfully created");
                    Console.WriteLine("\nRun again the program to see the results");
                }
                    
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine(e.Message);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelismTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Variables and Setup
            var dummyDBObj = new DummyDB();
            var dummyDBList = new List<DummyDB>();
            var stopWatch = new Stopwatch();
            var sequentialDummies = new List<DummyDB>();
            var parallelDummies = new List<DummyDB>();

            Console.WriteLine(" \n -> How many objects would you like to create per list?");
            int numOfObjs = int.Parse(Console.ReadLine());
            dummyDBList = dummyDBObj.GenerateDummyDBObjs(numOfObjs);
            #endregion

            #region Sequential
            stopWatch.Start();

            foreach (var dummy in dummyDBList)
            {              
                sequentialDummies.Add(dummy);
                Console.WriteLine($"{dummy.Id}, " +
                    $"{dummy.FirstName}, " +
                    $"{dummy.LastName}, " +
                    $"{dummy.Address}, " +
                    $"{dummy.MobileNumber}");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  -> normalDummies List is filled with dummies: Done! \n");
            Console.ForegroundColor = ConsoleColor.White;
            var sequentialTime = stopWatch.ElapsedMilliseconds / 1000.0;
            #endregion

            #region Parallel
            stopWatch.Restart();

            Parallel.ForEach(dummyDBList, dummy =>
            {
                parallelDummies.Add(dummy);
                Console.WriteLine($"{dummy.Id}, " +
                    $"{dummy.FirstName}, " +
                    $"{dummy.LastName}, " +
                    $"{dummy.Address}, " +
                    $"{dummy.MobileNumber}");
            });

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  -> parallelDummies List is filled with dummies: Done! \n");
            Console.ForegroundColor = ConsoleColor.White;
            var parallelTime = stopWatch.ElapsedMilliseconds / 1000.0;
            #endregion

            #region Results
            Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - \n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -> Results:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" sequentialDummies List - Item Count: {0}", sequentialDummies.Count());
            Console.WriteLine(" parallelDummies List - Item Count: {0}", parallelDummies.Count());
            Console.WriteLine(" Sequential - Duration in seconds: {0}", sequentialTime);
            Console.WriteLine(" Parallel - Duration in seconds: {0}", parallelTime);
            #endregion

            Console.ReadKey();

        } // end static void Main(string[] args)

    } // end class Program

} // end namespace ParallelismTestApp

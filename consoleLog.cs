using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_3037_
{
    public class consoleLog
    {
        public static void message(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"[msg] {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[inf] {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[inf] {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"[inf] {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

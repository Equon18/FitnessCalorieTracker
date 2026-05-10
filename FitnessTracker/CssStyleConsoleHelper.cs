using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCalorieTracker
{
   internal class CssStyleConsoleHelper
    {
        // ---------------------------------------------------------
        // STYLE HELPER METHODS
        // ---------------------------------------------------------
        public static void printHeader(string title)
        {
            //Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("        " + title.ToUpper());
            Console.WriteLine("");
            Console.ResetColor();

            Console.WriteLine();
        }

        public static void printFooter()
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Choose an option: ");
            Console.ResetColor();
        }

        public static void printMenuOption(int number, string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("  [" + number + "] ");
            Console.ResetColor();

            Console.WriteLine(text);
        }

        public static void printSectionTitle(string title)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----- " + title + " -----");
            Console.ResetColor();

            Console.WriteLine();
        }

        public static void printSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void printError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void printInfoLine(string label, string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(label);
            Console.ResetColor();

            Console.WriteLine(value);
        }

        public static void pauseScreen()
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Press Enter to continue...");
            Console.ResetColor();

            Console.ReadLine();
        }
    }
}

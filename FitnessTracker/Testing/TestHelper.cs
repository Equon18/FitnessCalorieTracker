using System;
using System.IO;

// TestHelper.cs
// Responsible: All Team Members

namespace FitnessCalorieTrackerTests
{
    public static class TestHelper
    {
        public static void SetConsoleInput(string input)
        {
            Console.SetIn(new StringReader(input));
        }

        public static StringWriter CaptureConsoleOutput()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            return output;
        }
    }
}

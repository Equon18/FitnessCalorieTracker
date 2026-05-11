using System.Reflection.Metadata.Ecma335;

namespace FitnessCalorieTracker
{
    // Reminder class
    // Responsible: George Moore
    public class Reminder
    {
        private string reminderText;
        private bool complete;
        private DateTime createdDate;
        private DateTime? dueDate;
        private int priority;

        public Reminder()
        {
            this.reminderText = "";
            this.complete = false;
            this.priority = 1;
        }

        public void CreateReminder()
        {
            Console.Write("Enter reminder: ");
            this.reminderText = Console.ReadLine() ?? "";
            this.createdDate = DateTime.Now;
            this.dueDate = this.PromptForDueDate();
            this.priority = this.PromptForPriority();
            this.complete = false;

            Console.WriteLine("Reminder saved.");
        }

        public void DisplayReminder()
        {
            string status = this.complete ? "Complete" : "Pending";
            string priorityText = this.GetPriorityText();

            Console.WriteLine(this.reminderText + " - " + status + " - " + priorityText);
        }

        public void MarkComplete()
        {
            this.complete = true;

            Console.WriteLine("Reminder marked complete.");
        }

        private DateTime? PromptForDueDate()
        {
            Console.Write("Enter due date (MM/DD/YYYY) or press Enter to skip: ");
            string input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            while (!DateTime.TryParseExact(input, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dueDate))
            {
                Console.Write("Invalid date format. Please enter MM/dd/yyyy or press Enter to skip: ");
                input = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                {
                    return null;
                }
            }

            return dueDate;
        }

        private int PromptForPriority()
        {
            Console.WriteLine("Select priority level:");
            Console.WriteLine("1. Low");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. High");
            Console.Write("Enter priority (1-3) or press Enter for Medium: ");
            string input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                return 1; // Default to Low
            }

            while (!int.TryParse(input, out int priority) || priority < 1 || priority > 3)
            {
                Console.Write("Invalid priority. Enter 1 (Low), 2 (Medium), or 3 (High): ");
                input = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                {
                    return 1; // Default to Low
                }
            }

            return priority;
        }

        private string GetPriorityText()
        {
            return this.priority switch
            {
                1 => "Low",
                2 => "Medium",
                3 => "High",
                _ => "Unknown"
            };
        }
    }
}
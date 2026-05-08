namespace FitnessCalorieTracker
{
    // Reminder class
    // Responsible: George Moore
    public class Reminder
    {
        private string reminderText;
        private bool complete;

        public Reminder()
        {
            this.reminderText = "";
            this.complete = false;
        }

        public void CreateReminder()
        {
            Console.Write("Enter reminder: ");
            this.reminderText = Console.ReadLine() ?? "";
            this.complete = false;

            Console.WriteLine("Reminder saved.");
        }

        public void DisplayReminder()
        {
            string status = this.complete ? "Complete" : "Pending";

            Console.WriteLine(this.reminderText + " - " + status);
        }

        public void MarkComplete()
        {
            this.complete = true;

            Console.WriteLine("Reminder marked complete.");
        }
    }
}
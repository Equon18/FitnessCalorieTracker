namespace FitnessCalorieTracker
{
    // User class
    // Responsible: Quentin Robinson
    public class User
    {
        private string name;
        private int age;
        private double weight;
        private int calorieGoal;
        private bool profileCreated;

        public User()
        {
            this.name = "";
            this.age = 0;
            this.weight = 0;
            this.calorieGoal = 0;
            this.profileCreated = false;
        }

        public void CreateProfile()
        {
            Console.Write("Enter name: ");
            this.name = Console.ReadLine() ?? "";

            Console.Write("Enter age: ");
            this.age = this.readNumber();

            while (this.age <= 0)
            {
                Console.Write("Age must be greater than 0. Enter age again: ");
                this.age = this.readNumber();
            }

            Console.Write("Enter weight: ");
            this.weight = this.readDecimalNumber();

            while (this.weight <= 0)
            {
                Console.Write("Weight must be greater than 0. Enter weight again: ");
                this.weight = this.readDecimalNumber();
            }

            Console.Write("Enter daily calorie goal: ");
            this.calorieGoal = this.readNumber();

            while (this.calorieGoal <= 0)
            {
                Console.Write("Calorie goal must be greater than 0. Enter calorie goal again: ");
                this.calorieGoal = this.readNumber();
            }

            this.profileCreated = true;

            Console.WriteLine("Profile saved.");
        }

        public void DisplayProfile()
        {
            if (!this.profileCreated)
            {
                Console.WriteLine("No profile has been created yet.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("User Profile");
            Console.WriteLine("Name: " + this.name);
            Console.WriteLine("Age: " + this.age);
            Console.WriteLine("Weight: " + this.weight);
            Console.WriteLine("Daily Calorie Goal: " + this.calorieGoal);
        }

        public int GetCalorieGoal()
        {
            return this.calorieGoal;
        }

        public bool HasProfile()
        {
            return this.profileCreated;
        }

        private int readNumber()
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Enter a valid number: ");
            }

            return number;
        }

        private double readDecimalNumber()
        {
            double number;

            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Enter a valid number: ");
            }

            return number;
        }
    }
}
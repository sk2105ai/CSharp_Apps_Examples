using OOPS_Examples;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Demonstrating Encapsulation by assigning salary of employees using controlled methods---");
        Employee emp1 = new Employee("Alice", 50000);
        emp1.DisplayDetails();
        emp1.GiveRaise(5000); // Using the controlled method to modify salary
        // emp1.Salary = 60000; // This would cause a compile-time error due to private set
        Console.WriteLine();

        Console.WriteLine("--- Demonstrating Inheritance and Polymorphism ---");
        // Creating instances of derived classes
        Manager mgr1 = new Manager("Bob", 80000, "Engineering");
        Developer dev1 = new Developer("Charlie", 70000, "C#");

        // Storing derived class objects in an array of the base class type (Employee).
        // This is where polymorphism shines - we can treat Managers and Developers as Employees.
        Employee[] employees = new Employee[] { emp1, mgr1, dev1 };

        // Iterating through the array and calling DisplayDetails().
        // Even though we call DisplayDetails() on an Employee reference,
        // the actual method executed is determined by the object's true type at runtime
        // (Manager's DisplayDetails or Developer's DisplayDetails). This is runtime polymorphism.
        Console.WriteLine("\nDisplaying different details using based on Employee references (Polymorphism):");
        foreach (Employee emp in employees)
        {
            emp.DisplayDetails(); // Polymorphic call
            // We cannot directly call mgr1.ConductMeeting() or dev1.WriteCode() here
            // because 'emp' is treated as an Employee. We'd need casting if necessary.

            // Example of using 'as' operator for safe casting and accessing derived class methods
            if (emp is Manager manager)
            {
                manager.ConductMeeting();
            }
            else if (emp is Developer developer)
            {
                developer.WriteCode();
            }
            Console.WriteLine("---");
        }
        Console.WriteLine();

        Console.WriteLine("--- Demonstrating Abstraction ---");
        // We cannot create an instance of the abstract class Shape.
        // Shape myShape = new Shape(); // This would cause a compile-time error.

        // We create instances of concrete derived classes.
        Shape circle = new Circle(10);
        Shape rectangle = new Rectangle(5, 4);

        // Storing derived class objects in an array of the base abstract class type (Shape).
        Shape[] shapes = new Shape[] { circle, rectangle };

        Console.WriteLine("Calculating areas using Shape references (Abstraction and Polymorphism):");
        foreach (Shape shape in shapes)
        {
            // We call the abstract method CalculateArea().
            // The specific implementation executed depends on the actual object type (Circle or Rectangle).
            // This demonstrates both abstraction (hiding implementation details of area calculation)
            // and polymorphism (calling the appropriate method based on object type).
            shape.DisplayInfo(); // Calling a concrete method from the abstract base class
            Console.WriteLine($"Area: {shape.CalculateArea()}"); // Calling the abstract method polymorphically
            Console.WriteLine("---");
        }
        Console.WriteLine();

        Console.WriteLine("Demonstrations complete. Press Enter to exit.");
        Console.ReadLine();
    }
}
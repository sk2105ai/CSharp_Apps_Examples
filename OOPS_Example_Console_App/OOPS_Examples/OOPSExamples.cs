using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Examples
{ 

    // --- Encapsulation Example ---
    // Encapsulation is the bundling of data (attributes) and methods (behaviors)
    // that operate on the data into a single unit, a class.
    // It also restricts direct access to some of an object's components,
    // which is a means of preventing accidental modification of data.
    // This is achieved by using access modifiers like private, public, protected.
    public class Employee
    {
        // Private fields encapsulate the data.
        private string name;
        private decimal salary;

        // Public properties provide controlled access to the private fields.
        public string Name
        {
            get { return name; } // Read-only access for name
            private set { name = value; } // Private set enforces that name is set internally or via constructor
        }

        public decimal Salary
        {
            get { return salary; } // Read-only access for salary
                                   // Private set prevents external classes from directly changing the salary.
                                   // We'll provide a method to modify it.
            private set { salary = value; }
        }


        /// <summary>
        /// Constructor to initialize the Employee object.
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="initialSalary">decimal</param>
        /// <CreatedBy>Shahir Khan</CreatedBy>
        /// <CreatedDate>May 02, 2025</CreatedDate>
        public Employee(string name, decimal initialSalary)
        {
            try
            {
                // Using the private setters within the class.
                Name = name;
                Salary = initialSalary;
                Console.WriteLine($"Employee created: {Name}");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in initializing employee details. refer details: " + ex.Message.ToString());
            }
        }


        /// <summary>
        /// Public method to allow raising the salary, demonstrating controlled modification.
        /// </summary>
        /// <param name="amount">decimal</param>
        /// <CreatedBy>Shahir Khan</CreatedBy>
        /// <CreatedDate>May 02, 2025</CreatedDate>
        public void GiveRaise(decimal amount)
        {
            try
            {
                if (amount > 0)
                {
                    salary += amount; // Modify the private salary field
                    Console.WriteLine($"{Name} received a raise of {amount:C}. New salary: {Salary:C}");
                }
                else
                {
                    Console.WriteLine($"Invalid raise amount for {Name}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Giving Raise. refer details: " + ex.Message.ToString());
            }
        }

        
        /// <summary>
        /// Virtual method allows derived classes to provide their own implementation.
        /// </summary>
        /// <CreatedBy>Shahir Khan</CreatedBy>
        /// <CreatedDate>May 02, 2025</CreatedDate>
        public virtual void DisplayDetails()
        {
            try
            {
                Console.WriteLine($"Employee Name: {Name}, Salary: {Salary:C}");            
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in displaying details. refer details: " + ex.Message.ToString());
            }
}
    }

    // --- Inheritance Example ---
    // Inheritance allows a new class (derived class or subclass) to inherit
    // properties and behaviors (fields and methods) from an existing class
    // (base class or superclass). This promotes code reusability.
    
    // --- Polymorphism Example ---
    // Polymorphism means "many forms". It allows objects of different classes
    // to be treated as objects of a common base class.
    // The most common forms are method overriding (runtime polymorphism)
    // and method overloading (compile-time polymorphism - not explicitly shown here but common).
    public class Manager : Employee // Manager inherits from Employee
    {
        public string Department { get; set; }


        /// <summary>
        /// Constructor for the Manager class. The 'base' keyword is used to call the constructor of the base class (Employee).
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="initialSalary">decimal</param>
        /// <param name="department">string</param>
        /// CreatedBy>Shahir Khan</CreatedBy>
        /// <CreatedDate>May 02, 2025</CreatedDate>
        public Manager(string name, decimal initialSalary, string department) : base(name, initialSalary)
        {
            try
            {
                Department = department;
                Console.WriteLine($"Manager created: {Name} in {Department} department.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in initializing Manager details. refer details: " + ex.Message.ToString());
            }
            
        }


        /// <summary>
        /// Override the virtual method from the base class (Employee). This is an example of polymorphism (specifically, method overriding).
        /// </summary>
        /// <CreatedBy>Shahir Khan</CreatedBy>
        /// <CreatedDate>May 02, 2025</CreatedDate>
        public override void DisplayDetails()
        {
            try
            { 
            // Call the base class implementation to reuse its logic.
            base.DisplayDetails();
            Console.WriteLine($"Department: {Department}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in displaying Manager details. refer details: " + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Manager-specific method.
        /// </summary>
        /// <CreatedBy>Shahir Khan</CreatedBy>
        /// <CreatedDate>May 02, 2025</CreatedDate>
        public void ConductMeeting()
        {
            try
            {
                Console.WriteLine($"{Name} is conducting a meeting for the {Department} department.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in executing Manager task details. refer details: " + ex.Message.ToString());
            }
        }
    }

    public class Developer : Employee // Developer also inherits from Employee
    {
        public string ProgrammingLanguage { get; set; }


        /// <summary>
        /// Constructor for the Developer class.
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="initialSalary">decimal</param>
        /// <param name="programmingLanguage">string</param>
        /// <CreatedBy>Shahir Khan</CreatedBy>
        /// <CreatedDate>May 02, 2025</CreatedDate>
        public Developer(string name, decimal initialSalary, string programmingLanguage) : base(name, initialSalary)
        {
            try
            {
                ProgrammingLanguage = programmingLanguage;
                Console.WriteLine($"Developer created: {Name} specializing in {ProgrammingLanguage}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in initializing developer details. refer details: " + ex.Message.ToString());
            }
        }


        /// <summary>
        /// Override the virtual method from the base class (Employee).
        /// </summary>
        /// <CreatedBy>Shahir Khan</CreatedBy>
        /// <CreatedDate>May 02, 2025</CreatedDate>
        public override void DisplayDetails()
        {
            try
            {
                base.DisplayDetails();
                Console.WriteLine($"Programming Language: {ProgrammingLanguage}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in displaying developer details. refer details: " + ex.Message.ToString());
            }
        }


        /// <summary>
        /// Developer-specific method for specific language.
        /// </summary>
        /// <CreatedBy>Shahir Khan</CreatedBy>
        /// <CreatedDate>May 02, 2025</CreatedDate>
        public void WriteCode()
        {
            try
            {
                Console.WriteLine($"{Name} is writing code in {ProgrammingLanguage}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in executing developer related task. refer details: " + ex.Message.ToString());
            }
        }
    }

    // --- Abstraction Example ---
    // Abstraction is the concept of hiding complex implementation details
    // and showing only the essential features of an object.
    // In C#, abstraction can be achieved using abstract classes or interfaces.

    // Abstract class: Cannot be instantiated directly.
    // It can contain abstract methods (which must be implemented by derived classes)
    // and concrete methods (with implementation).
    public abstract class Shape
    {

        /// <summary>
        /// Abstract method: No implementation in the base class. Derived classes MUST provide an implementation.
        /// </summary>
        /// <returns></returns>
        /// <CreatedBy>Shahir Khan</CreatedBy>
        /// <CreatedDate>May 02, 2025</CreatedDate>
        public abstract double CalculateArea();


        /// <summary>
        /// Non-Abstract method: Has implementation in the base class itself.
        /// </summary>
        /// <CreatedBy>Shahir Khan</CreatedBy>
        /// <CreatedDate>May 02, 2025</CreatedDate>
        public void DisplayInfo()
        {
            try
            {
                Console.WriteLine("This is a shape.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in displaying shape info details. refer details: " + ex.Message.ToString());
            }
        }
    }

    // Derived class implementing the abstract method.
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }


        /// <summary>
        /// Implementing the abstract method from the base class.
        /// </summary>
        /// <returns>double</returns>
        /// <CreatedBy>Shahir Khan</CreatedBy>
        /// <CreatedDate>May 02, 2025</CreatedDate>
        public override double CalculateArea()
        {
            try
            {
                // Math.PI is encapsulated within the Math class.
                return Math.PI * Radius * Radius;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in calculating circle area. refer details: " + ex.Message.ToString());
                return 0;
            }
        }
    }

    // Another derived class implementing the abstract method.
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }


        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        
        /// <summary>
        /// Implementing the abstract method from the base class.
        /// </summary>
        /// <returns></returns>
        /// <CreatedBy>Shahir Khan</CreatedBy>
        /// <CreatedDate>May 02, 2025</CreatedDate>
        public override double CalculateArea()
        {
            try
            {
                return Width * Height;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in calculating rectangle area. refer details: " + ex.Message.ToString());
                return 0;
            }
        }
    }  

}

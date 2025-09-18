

namespace SampleConApp
{
    class BaseClass // This class is internal. internal classes are accessible only within the same assembly/project. If u want to make it accessible outside the assembly/project , you can change it to public. public Class BaseClass
    {
        public void Display()
        {
            Console.WriteLine("Base Class Display Method");
        }
    }
     
    //A derived class that inherits from BaseClass is required if u want to add new functionslity or override existing functionslity of the base class. A class is immutablr by default,meaning u can't change its functionsality unless u inherit from it. (Open Closed principle of SOLID)

    // C# does not support multiple inheritance, meaning a class can't inherit from more than one base class at same level. however it can implement multiple interfaces. C# supports multilevel inheritance meaning a class can inherit from another derived class

    class DerivedClass:BaseClass
    {
        public void show()
        {
            Console.WriteLine("Child Class");
        }

    }

    class InheritanceExample
    {
        static void Main(string[] args)
        {
            DerivedClass obj = new DerivedClass();
            obj.Display();
            obj.show();

        }
    }
}

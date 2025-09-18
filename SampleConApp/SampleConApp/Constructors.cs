using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp.Con
{
    class SuperClass
    {
        //public SuperClass()
        //{
        //    Console.WriteLine("Super class constructor is called");
        //}
        public SuperClass(string value)
        {
            Console.WriteLine($"Super class constructor is called with {value} as parameter");
        }
    }

    class BaseClass : SuperClass
    {
        public BaseClass(string msg) : base(msg) //invoking the base class constructor
        {
            Console.WriteLine("Base class constructor is called");
        }
    }

    class DerivedClass : BaseClass
    {
        public DerivedClass(string msg1) : base(msg1)
        {
            Console.WriteLine("Derived class constructor is called");
        }


        internal class Constructors
        {
            static void Main(string[] args)
            {
                //SuperClass superClass = new SuperClass(); // using new operatorr to create an instance of the super class 
                DerivedClass derivedClass = new DerivedClass("Hi");

            }




        }
    }
}

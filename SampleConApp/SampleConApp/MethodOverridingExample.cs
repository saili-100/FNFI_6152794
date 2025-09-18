using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    //Method Overriding is a feature that allows a derived class to provide a specific/customized implementation of a method that is already defined in its base class. This is useful when the derived class needs to modify or extend the behavior of the base class method.
    // To override a method, the base class method must be marked with the `virtual` keyword, and the derived class method must be marked with the `override` keyword. This allows the derived class to change the implementation of the method while still maintaining the same method signature.
    enum PaymentType
    {
        Cash,
        Cheque,
        Card,
        UPI
    }
    class ParentClass
    {
        public void Display()
        {
            Console.WriteLine("WELCOME TO PAYMENT GATEWAY");
        }
        public virtual void MakePayment(double amount, PaymentType paymentType)
        {
            if (paymentType == PaymentType.Cash)
            {
                Console.WriteLine($"Payment of  {amount} in cash");
            }
            else if (paymentType == PaymentType.Cheque)
            {
                Console.WriteLine($"Payment of {amount} made by cheque");
            }
            else
            {
                Console.WriteLine("Invalid mode of Payment. Payment not accepted");
            }
        }
        //base keyword is used to refer the immediate base class from the current class.

        class SonClass : ParentClass
        {
            public void show()
            {
                Console.WriteLine("Child show method");
            }
            public override void MakePayment(double amount, PaymentType paymentType)
            {
                //base.MakePayment(amount, paymentType);
                if (paymentType == PaymentType.Card)
                {
                    Console.WriteLine($"Payment of {amount} made by card.");
                }
                else if (paymentType == PaymentType.UPI)
                {
                    Console.WriteLine($"Payment of {amount} made by UPI.");
                }
                else if (paymentType == PaymentType.Cash)
                {
                    Console.WriteLine($"Payment of {amount} made by Cash.");
                }
                else
                {
                    Console.WriteLine("Invalid mode of Payment. Payment not accepted");
                }
            }
           
        }
        //This is called as RUNTIME POLYMORPHISM or DYNAMIC BINDING.
        internal class MethodOverridingExample
        {
            static ParentClass CreateObject()
            {
                Console.WriteLine("Enter the type of the object U want to create, Press P for Parent and S for Son");
                string choice = Console.ReadLine();
                if (choice.ToUpper() == "P")
                {
                    return new ParentClass(); //Returning ParentClass object
                }
                else if (choice.ToUpper() == "S")
                {
                    return new SonClass(); //Returning SonClass object
                }
                else
                {
                    Console.WriteLine("Invalid choice, No object is created");
                    return null;
                }
            }
            static void Main(string[] args)
            {
                ParentClass parent = CreateObject(); //Upcasting: Treating ParentClass as ParentClass
                if (parent == null)
                {
                    Console.WriteLine("No object created, Exiting the program.");
                    return;
                }
                parent.Display();
                parent.MakePayment(1000, PaymentType.Cash);
                parent.MakePayment(2000, PaymentType.Cheque);

                //parent = new SonClass(); //Upcasting: Treating SonClass as ParentClass
                parent.MakePayment(2000, PaymentType.Cheque);

                //Downcasting: Only methods that are defined in ParentClass can be called on parent object. If u want to call methods that are defined in SonClass , U need to downcast the parent object to SonClass using the 'as' keyword or by direct casting.
                if(parent is SonClass) // is keyword shall check for the type of the object at run time
                {
                    SonClass son = parent as SonClass; //Downcasting: Treating ParentClass as SonClass
                    son.show();
                }

            }
        }
    }
}

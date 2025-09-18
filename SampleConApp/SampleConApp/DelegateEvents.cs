﻿//Similar to Function pointers of C++. They are used to pass functions are arguments to other Functions. Example could be predicates that are passed for filtering a collection. The Predicate shall provide a logic on how to filter the collection.
//In C#, callbacks and predicates are implementing using delegate. 
//A Delegate is a signature of a method that can be used to call inside another function. 
//Delegate is more like a function type. 
//Delegates are type-safe and secure, meaning they can only call methods that match their signature.

using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

namespace SampleConApp
{
    delegate double MathOp(double a, double b);
    internal class DelegateEvents
    {
        class ConsoleUtil
        {
            public static double GetInputDouble(string question)
            {
                Console.WriteLine(question);
                double var1 = double.Parse(Console.ReadLine());
                //double var2 = double.Parse(Console.ReadLine());
                return var1;
                //return var2;
            }
        }
        static void InvokeFunc(Func<double, double, double> func)
        {
            double v1 = ConsoleUtil.GetInputDouble("Enter First value");
            double v2 = ConsoleUtil.GetInputDouble("Enter second Value");
            double result = func(v1, v2);
            Console.WriteLine("The result " + result);
            static void InvokeMethod(MathOp func)
            {
                double v1 = ConsoleUtil.GetInputDouble("Enter First value");
                double v2 = ConsoleUtil.GetInputDouble("Enter Second value");
                double result = func(v1, v2);
                Console.WriteLine("The result : " + result);
            }
            static void Main(string[] args)
            {
                /////////Old syntax for using the delegate object//////////
                MathOp obj = new MathOp(add);
                InvokeMethod(obj);

                /////////New syntax for using the delegate object//////////
                InvokeMethod(add);//Passing the method as a delegate directly
                InvokeMethod(someFun);
                InvokeFunc(test);

            }
            static double test(double d1, double d2)
            {
                return d1 * d2;
            }

            static double add(double a, double b) => a + b;

            static double someFun(double v1, double v2) => v1 * (v2);

        }
    }
}

//Similar to Function pointers of C++. They are used to pass functions are arguments to other Functions. Example could be predicates that are passed for filtering a collection. The Predicate shall provide a logic on how to filter the collection.
//In C#, callbacks and predicates are implementing using delegate. 
//A Delegate is a signature of a method that can be used to call inside another function. 
//Delegate is more like a function type. 
//Delegates are type-safe and secure, meaning they can only call methods that match their signature.

//using System.Reflection.Metadata.Ecma335;
//using System.Threading.Channels;

//namespace SampleConApp
//{
//    delegate double MathOp(double a, double b);
//    internal class Ex17DelegatesAndEvents
//    {

//        static void InvokeMethod(MathOp func)
//        {
//            double v1 = ConsoleUtil.GetInputDouble("Enter First value");
//            double v2 = ConsoleUtil.GetInputDouble("Enter Second value");
//            double result = func(v1, v2);
//            Console.WriteLine("The result : " + result);
//        }
//        static void Main(string[] args)
//        {
//            /////////Old syntax for using the delegate object//////////
//            MathOp obj = new MathOp(add);
//            InvokeMethod(obj);

//            /////////New syntax for using the delegate object//////////
//            InvokeMethod(add);//Passing the method as a delegate directly
//            InvokeMethod(someFun);
//        }

//        static double add(double a, double b) => a + b;

//        static double someFun(double v1, double v2) => v1 * (v2);

//    }
//}

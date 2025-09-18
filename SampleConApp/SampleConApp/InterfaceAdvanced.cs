using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    interface IExample
    {
        void ShowExample();
    }
    interface ISimple
    {
        void ShowSimple();
    }
    class SimpleExample : IExample,ISimple //Multiple Interface implementation
    {
        public void ShowExample()
        {
            Console.WriteLine("This is an example of implementing multiple interfaces");
        }

        public void ShowSimple()
        { 
            Console.WriteLine("I am simple"); 
        }



    }
        
    internal class InterfaceAdvanced
    {
        static void Main(string[] args)
        {
            SimpleExample obj = new SimpleExample();
            obj.ShowExample();
            obj.ShowSimple();

        }
        
        

    }
}
// multiple interfaces having same method will be implemented through interface name.method name()
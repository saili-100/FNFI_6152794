using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Employee:object
    {
        //data shall be private by default
        private int _id;
        private string _name;
        private string _address;
        double _salary;

        public int EmpID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string EmpName
        {
            get { return _name; }
            set { _name = value; }
        }

        public string EmpAddress
        {
            get { return _address; }
            set { _address = value; }
        }

        public double EmpSalary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public override string ToString()
        {
            return EmpID.ToString();
        }

        //GetHashCode() is used to get a hash code for the object. It is used in collections like HashSet, Dictionary etc. The hash value is used to quickly locate the object in the collection.
        public override int GetHashCode()
        {
            return EmpID;
        }
        //Implement the logical Equivalence for the Employee class.
        public override bool Equals(object? obj)
        {
            //If 2 EmpIds are same, then the objects are considered equal.
            if (obj is Employee emp)
            {
                if (this.EmpID == emp.EmpID)
                    return true;
                else
                    return false;
            }
            return false; //If the object is not of type Employee, then return false.
        }
        //    internal class ClassandObjects
        //{
        static void Main(string[] args)
        {
            //        /* Class is UDT It comes with a set of OOP features like Encapsulation Inheritance Polymorphism,
            //         Class can have fields(Data) properties(Accessors) method(functions) events(Actions) constructors(Sp function that is invokes while creating the object)*/
            //    }
            //}
            Employee emp = new Employee();
            emp.EmpID = 1;
            emp.EmpName = "Saili";
            emp.EmpSalary = 100;
            emp.EmpAddress = "Banglore";
            Console.WriteLine($"{emp.EmpID} {emp.EmpName} {emp.EmpSalary}{emp.EmpAddress}");    




        }

        //       Console.
        //   }
    }
}
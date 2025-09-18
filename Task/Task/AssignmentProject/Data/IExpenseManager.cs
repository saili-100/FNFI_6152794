using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentProject.Entities;

//create a folder call Utils in the Project and add a class called ExpenseUtil.this class shall contain only static methods. So U can make the class as static. Create a function called CreateExpenseManager that shall return IExpenseManager object.
namespace AssignmentProject.Data
{
    internal interface IExpenseManager
    {
        public void AddExpense(Expense expense);
        public void UpdateExpense(int ID, Expense updatedExpense);
        IEnumerable<Expense> GetAllExpenses();
        IEnumerable<Expense> GetExpenseOnCategory(string category);
        static void Main(string[] args)
        {

        }
    }
}


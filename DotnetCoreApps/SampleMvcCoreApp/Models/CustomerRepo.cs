
namespace SampleMvcCoreApp.Models
{
    public class CustomerRepo
    {
        public void AddCustomer(MyCustomer customer)
        {
            var context = new CstDbContext();
            context.MyCustomers.Add(customer);
            context.SaveChanges();
        }

        public List<MyCustomer> GetAllCustomers()
        {
            var context = new CstDbContext();
            return context.MyCustomers.ToList();
        }

        // Delete and Update Customer
        public MyCustomer GetCustomerById(int id)
        {
            var context = new CstDbContext();
            return context.MyCustomers.Find(id);
        }

        internal void UpdateCustomer(MyCustomer cst)
        {
            var context = new CstDbContext();
            var record = context.MyCustomers.Find(cst.CstId);
            if (record != null)
            {
                record.CstName = cst.CstName;
                record.CstAddress = cst.CstAddress;
                record.BillAmount = cst.BillAmount;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Record not found");
            }
        }

        internal void DeleteCustomer(int id)
        {
            var context = new CstDbContext();
            var record = context.MyCustomers.Find(id);
            if (record != null)
            {
                context.MyCustomers.Remove(record);
                context.SaveChanges();
            }

        }
    }
}

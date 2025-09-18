using System;
using System.Collections.Generic;

namespace DotNetCorelib.Data;

public partial class Employee
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public string EmpAddress { get; set; } = null!;

    public decimal EmpSalary { get; set; }

    public int? Id { get; set; }

    public virtual DeptTable? Dept { get; set; }
}

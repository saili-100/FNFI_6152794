use FNFTraining
--hackathon 2

create table Employees (Emp_Id int primary key identity(1,1), Name varchar(50),Salary money ,Manager_Id int
FOREIGN KEY(Manager_Id) REFERENCES EMPLOYEES(Emp_Id));

insert into Employees (Name,Salary,Manager_Id) values
('Rohit',20000,3),
('Sangeeta',12000,5),
('Sanjay',10000,5),
('Arun',25000,3),
('Zaheer',30000,null);

select emp.Name as "emp_Name",mgr.Name as "mgr_Name" from Employees emp left join Employees mgr on 
emp.Manager_Id = mgr.Emp_Id order by emp.Name;


use SailiSQLAssignment
select * from EMPLOYEES;
SELECT * FROM DEPARTMENTS;
select * from JOBS;
select * from LOCATIONS;
select * from JOB_HISTORY;
select * from REGIONS;


-- Q1 
Select emp.LASTNAME,dept.DEPARTMENT_ID,dept.DEPARTMENT_NAME FROM EMPLOYEES emp JOIN DEPARTMENTS dept 
ON emp.DEPARTMENT_ID = dept.DEPARTMENT_ID;

--Q2
SELECT distinct JOBS.JOB_TITLE,dept.LOCATION_ID FROM EMPLOYEES AS emp JOIN DEPARTMENTS as dept ON emp.DEPARTMENT_ID = dept.DEPARTMENT_ID 
join JOBS on emp.JOB_ID = JOBS.JOB_ID where emp.DEPARTMENT_ID = 30;

-- last name, deptname,location_id and city who earn commission
--Q3 
select emp.LASTNAME,dept.DEPARTMENT_NAME,dept.LOCATION_ID,loc.CITY from 
EMPLOYEES emp join DEPARTMENTS as dept ON emp.DEPARTMENT_ID = dept.DEPARTMENT_ID 
join locations as loc ON dept.LOCATION_ID = loc.LOCATION_ID 
where emp.COMMISSION_PCT is not null;

--Q4 
select emp.LASTNAME,dept.DEPARTMENT_NAME from EMPLOYEES emp join DEPARTMENTS dept
on emp.DEPARTMENT_ID = dept.DEPARTMENT_ID where emp.LASTNAME like '%a%';

--Q5 
select emp.LASTNAME,emp.JOB_ID,JOBS.JOB_TITLE,dept.DEPARTMENT_ID,dept.DEPARTMENT_NAME from EMPLOYEES emp join JOBS 
on emp.JOB_ID = JOBS.JOB_ID 
join DEPARTMENTS as dept on emp.DEPARTMENT_ID = dept.DEPARTMENT_ID  
join locations as loc ON dept.LOCATION_ID = loc.LOCATION_ID where loc.CITY='Toronto';

--Q6 
-- trick self join
--manager id refers to same employee 
select emp.LASTNAME as "Employee",emp.EMPLOYEE_ID as "Emp#",emp1.LASTNAME as "Manager",emp1.EMPLOYEE_ID as "Manager#" from EMPLOYEES emp join EMPLOYEES emp1 on emp.MANAGER_ID = emp1.EMPLOYEE_ID;

--Q7 Modify the above to display the same columns for all employees (including "King", who has no manager). Order the result by the employee number.

select emp.LASTNAME as "Employee",emp.EMPLOYEE_ID as "Emp#",emp1.LASTNAME as "Manager",emp1.EMPLOYEE_ID as "Manager#" from EMPLOYEES emp left join EMPLOYEES emp1 on emp.MANAGER_ID = emp1.EMPLOYEE_ID order by emp.EMPLOYEE_ID;

--Q8 Create query that displays employee lastnames, department numbers, and all the employees who work in the same department as a given employee. Give each column an appropriate label.
--select emp.LASTNAME,emp.DEPARTMENT_ID,dept.DEPARTMENT_NAME from EMPLOYEES emp join DEPARTMENTS --dept on emp.DEPARTMENT_ID = dept.DEPARTMENT_ID 
--group by dept.DEPARTMENT_NAME having emp.DEPARTMENT_ID = dept.DEPARTMENT_ID ;

--Q9 Create a query that displays the name, job, department name, salary and grade for all employees.

select emp.FIRSTNAME as "Name",emp.JOB_ID as "Job",dept.DEPARTMENT_NAME as "Department",emp.SALARY as "Salary",
case 
	when emp.salary>=15000 then 'A'
	when emp.salary>=10000 then 'B'
	when emp.salary>=5000 then 'C'
	else 'D'
end as "Grade"
from EMPLOYEES emp join DEPARTMENTS dept on emp.DEPARTMENT_ID = dept.DEPARTMENT_ID

--Q10 Create a query to display the name and hiredate of any employee hired after employee "Davies"
select lastname,HIRE_DATE from EMPLOYEES where HIRE_DATE >(select HIRE_DATE from EMPLOYEES where lastname='Davies');

--Q11 Display the names and hire dates for all employees who were hired before their managers, along with their manager's names and hiredates. Label the columns "Employee", "Emp hired", 
/*select emp.LASTNAME as "Employee",emp.HIRE_DATE as "Emp hired",manager.LASTNAME as "Manager",manager.HIRE_DATE as "Manager hired" from EMPLOYEES emp join EMPLOYEES manager on emp.MANAGER_ID = manager.EMPLOYEE_ID where emp.HIRE_DATE < manager.HIRE_DATE;*/

select emp.LASTNAME as "Employee",emp.HIRE_DATE as "Emp hired",manager.LASTNAME as "Manager",manager.HIRE_DATE as "Manager hired" 
from EMPLOYEES emp left join EMPLOYEES manager 
on emp.MANAGER_ID = manager.EMPLOYEE_ID where emp.HIRE_DATE < manager.HIRE_DATE;

--Q12 Display the highest, lowest, sum and average salary of all employees. Label the columns "Maximum", "Minimum", "Sum", and "Average" respectively.

select Max(SALARY) as "Maximum" ,min(SALARY) as "Minimum", sum(SALARY) as "Sum" ,avg(SALARY) AS "Average" from EMPLOYEES;

--Q13 Modify the above query to display the same data for each job type.
select * from EMPLOYEES;
select * from JOBS;

select max(MAX_SALARY)+max(MIN_SALARY) as "Maximum",min(MIN_SALARY) + min(MAX_SALARY) as "Minimum",sum(MIN_SALARY)+ sum(MAX_SALARY) as "Sum" ,avg(MIN_SALARY) + avg(MAX_SALARY) as "Average" from JOBS;

--Q14 Write a query to display the number of people with the same job.
select count(*) as "Number of people",emp.JOB_ID from EMPLOYEES emp group by emp.JOB_ID

--Q15 Determine the number of managers without listing them. Label the column "Number of Managers". [Hint: use the MANAGER_ID column to determine the number of managers]
select * from EMPLOYEES

select count(distinct MANAGER_ID) as "Number of Managers" from EMPLOYEES; -- 18

--Q16 Write a query that displays the difference between the highest and the lowes salaries. Label the column as "Difference".

select max(SALARY)-min(SALARY) as "Difference" from EMPLOYEES 

--Q17 Display the manager number and the salary of the lowest paid employee for that manager. Exclude anyone whose manager is not known. Exclude any group where the minimum salary is less than $6000. Sort the output in descending order of salary.

select MANAGER_ID as "Manager Number", min(SALARY) as "Lowest Salary"  from EMPLOYEES
where MANAGER_ID is not NUll
GROUP BY MANAGER_ID
HAVING min(SALARY)>=6000
ORDER BY min(SALARY) DESC;

--Q18 Write a query to display each department's name, location, number of employees, and the average salary for all employees in that department. Label the columns "Name", "Location", "No.of people", and "SAlary" respectively. Round the average salary to two decimal places.

select dept.DEPARTMENT_NAME as "Name",count(*) as "NO.of people",Round(avg(emp.SALARY),2) as "Salary",l.CITY as "Location" from EMPLOYEES emp join DEPARTMENTS dept on emp.DEPARTMENT_ID = dept.DEPARTMENT_ID 
join LOCATIONS l ON dept.LOCATION_ID = l.LOCATION_ID
group by dept.DEPARTMENT_NAME,l.CITY

--dept.LOCATION_ID,

--Q19 Write a query to display the lastname, and hiredate of any employee in the department as the employee "Zlotkey". Exclude "Zlotkey".
select * from EMPLOYEES where LASTNAME = 'Zlotkey'; 
select LASTNAME,HIRE_DATE from EMPLOYEES where DEPARTMENT_ID= (select DEPARTMENT_ID from EMPLOYEES where LASTNAME='Zlotkey') and LASTNAME<>'Zlotkey';


--Q20 Create a query to display the employee numbers and lastnames of all employees who earn more than the average salary. Sort the result in ascending order of salary.
SELECT EMPLOYEE_ID,LASTNAME FROM EMPLOYEES WHERE SALARY > (select avg(SALARY) FROM EMPLOYEES)
order by SALARY;

--Q21 Write a query that displays the employee number and lastname of all employees who work in a department with any employee whose lastname contains a "u".
select EMPLOYEE_ID,LASTNAME from EMPLOYEES where DEPARTMENT_ID in (select DEPARTMENT_ID from EMPLOYEES where LASTNAME like '%u%');

--Q22 Display the lastname, department number, and job id of all employees whose department location id is 1700.
select emp.LASTNAME,emp.DEPARTMENT_ID,emp.JOB_ID from EMPLOYEES emp join DEPARTMENTS dept on emp.DEPARTMENT_ID=dept.DEPARTMENT_ID
where dept.LOCATION_ID=1700;

--Q23 Display the lastname and salary of every employee who reports to "King".
--Q24 Display the department number, lastname, and job id for every employee in the "Executive" department.
select emp.LASTNAME,emp.DEPARTMENT_ID,emp.JOB_ID from EMPLOYEES emp join DEPARTMENTS dept on emp.DEPARTMENT_ID=dept.DEPARTMENT_ID
where dept.DEPARTMENT_NAME='Executive'

--Q25 Display the employee number, lastname, and salary of all employees who earn more than the average salary and who work in a department with any employee with a "u" in their lastname.

--Q26 Write a query to get unique department ID from employee table.
select distinct DEPARTMENT_ID from EMPLOYEES;

--Q27 Write a query to get all employee details from the employee table order by first name, descending.
select * from EMPLOYEES order by FIRSTNAME DESC;

--Q28 Write a query to get the names (first_name, last_name), salary, PF of all the employees (PF is calculated as 15% of salary).
select (FIRSTNAME + ' ' + LASTNAME) as names ,salary, salary*0.15 as PF from Employees

--Q29 Write a query to get the employee ID, names (first_name, last_name), salary in ascending order of salary.
select EMPLOYEE_ID,(FIRSTNAME + ' ' + LASTNAME) as names ,salary from Employees order by SALARY 

--Q30Write a query to get the total salaries payable to employees.

--Q31 Write a query to get the maximum and minimum salary from employees table.
select min(salary) as "minimum salary",max(salary) as "maximum salary" from EMPLOYEES

--Q32 Write a query to get the average salary and number of employees in the employees table.
select avg(salary) as "Average Salary",count(EMPLOYEE_ID) as "number of employees" from EMPLOYEES
--Q33 Write a query to get the number of employees working with the company.
--Q34 Write a query to get the number of jobs available in the employees table.

--Q35 Write a query get all first name from employees table in upper case.
select UPPER(FIRSTNAME) as "Names in UpperCase" from EMPLOYEES;

--Q36 Write a query to get the first 3 characters of first name from employees table.
select FIRSTNAME from EMPLOYEES where FIRSTNAME like '___';

--Q37 Write a query to get the names (for example Ellen Abel, Sundar Ande etc.) of all the employees from employees table.
select (FIRSTNAME + ' ' + LASTNAME) as names from EMPLOYEES

--Q38 Write a query to get first name from employees table after removing white spaces from both side.

select TRIM(FIRSTNAME),LEN(FIRSTNAME) as "First Name" from EMPLOYEES;

--Q39 Write a query to get the length of the employee names (first_name, last_name) from employees table.
select (FIRSTNAME + LASTNAME),LEN(FIRSTNAME + LASTNAME) as "Full Name" from EMPLOYEES;

--Q40 Write a query to check if the first_name fields of the employees table contains numbers.
select ISNUMERIC(FIRSTNAME) from EMPLOYEES;

--Q41 Write a query to select first 10 records from a table.
select top(10) * from EMPLOYEES;

--Q42 Write a query to get monthly salary (round 2 decimal places) of each and every employee.
select ROUND((salary/12),2) as "monthly salary" from EMPLOYEES

--Q43 Write a query to display the name (first_name, last_name) and salary for all employees whose salary is not in the range $10,000 through $15,000.
select (FIRSTNAME + LASTNAME) as "full Name" ,salary from EMPLOYEES where salary not Between 10000 and 15000;

--Q44 Write a query to display the name (first_name, last_name) and department ID of all employees in departments 30 or 100 in ascending order.

select (FIRSTNAME + LASTNAME) as "full name" ,DEPARTMENT_ID  from Employees 
where DEPARTMENT_ID in (30,100) order by DEPARTMENT_ID;

--Q45 Write a query to display the name (first_name, last_name) and salary for all employees whose salary is not in the range $10,000 through $15,000 and are in department 30 or 100.
select (FIRSTNAME + LASTNAME) as "full Name" ,salary,DEPARTMENT_ID from EMPLOYEES where 
salary not Between 10000 and 15000 and (DEPARTMENT_ID in (30,100)) ;

--Q46 Write a query to display the name (first_name, last_name) and hire date for all employees who were hired in 1987.

--Q47 Write a query to display the first_name of all employees who have both "b" and "c" in their first name.
select FIRSTNAME from EMPLOYEES where FIRSTNAME like '%b%' and FIRSTNAME like '%c%';

--Q48 Write a query to display the last name, job, and salary for all employees whose job is that of a Programmer or a Shipping Clerk, and whose salary is not equal to $4,500, $10,000, or $15,000.
-- employess and jobs table 

--Q49 Write a query to display the last name of employees whose names have exactly 6 characters.
select LASTNAME from EMPLOYEES where LEN(LASTNAME)=6;

--Q50 Write a query to display the last name of employees having 'e' as the third character.
select LASTNAME from EMPLOYEES where LASTNAME like '__e%'

--Q51 Write a query to display the jobs/designations available in the employees table.
select distinct(JOB_ID) from EMPLOYEES

--Q52 Write a query to display the name (first_name, last_name), salary and PF (15% of salary) of all employees.

select (FIRSTNAME+LASTNAME) as "Full name",SALARY,(0.15*SALARY) as PF from EMPLOYEES;

--Q53 Write a query to select all record from employees where last name in 'BLAKE', 'SCOTT', 'KING' and 'FORD'.

select * from EMPLOYEES where LASTNAME in ('BLAKE','SCOTT','KING','FORD');

--Q54 Write a query to list the number of jobs available in the employees table.
select distinct(JOB_ID) as "number of employees" from EMPLOYEES

--Q55 Write a query to get the total salaries payable to employees.
select sum(SALARY) as "total salaries" from EMPLOYEES;

--Q56 Write a query to get the minimum salary from employees table.
select min(SALARY) as "total salaries" from EMPLOYEES;

--Q57 Write a query to get the maximum salary of an employee working as a Programmer.
select max(emp.SALARY) as "maximum salary" from EMPLOYEES emp join JOBS on emp.JOB_ID=JOBS.JOB_ID where JOBS.JOB_TITLE = 'Programmer';

--Q58 Write a query to get the average salary and number of employees working the department 90.
select avg(SALARY),count(EMPLOYEE_ID) from EMPLOYEES where DEPARTMENT_ID = 90;

--Q59 Write a query to get the highest, lowest, sum, and average salary of all employees.

select max(SALARY) AS "highest" ,min(SALARY) as "lowest", sum(SALARY) as "total",avg(SALARY) as "Average Salary" from EMPLOYEES;

--Q60 Write a query to get the number of employees with the same job
select JOB_ID,count(EMPLOYEE_ID) as "number of employees" from EMPLOYEES group by JOB_ID;

--Q61 Write a query to get the difference between the highest and lowest salaries.
select (max(SALARY) - min(SALARY)) as "Difference" from EMPLOYEES;

--Q62 Write a query to find the manager ID and the salary of the lowest-paid employee for that manager.

--Q63 Write a query to get the department ID and the total salary payable in each department.
select DEPARTMENT_ID,sum(SALARY) as "total Salary" from EMPLOYEES group by DEPARTMENT_ID

--Q64 Write a query to get the average salary for each job ID excluding programmer.
select emp.JOB_ID,avg(emp.SALARY) as "average Salary" from EMPLOYEES emp join JOBS job 
on emp.JOB_ID = job.JOB_ID 
where job.JOB_TITLE <> 'Programmer'
group by emp.JOB_ID

--Q65 Write a query to get the total salary, maximum, minimum, average salary of employees (job ID wise), for department ID 90 only.
select JOB_ID ,sum(SALARY) as "total salary",max(SALARY) as "max salary",min(SALARY) as "min salary",avg(SALARY) as "average salary" from EMPLOYEES where DEPARTMENT_ID = 90
group by JOB_ID

--Q66 Write a query to get the job ID and maximum salary of the employees where maximum salary is greater than or equal to $4000.
select JOB_ID,max(SALARY) from EMPLOYEES group by JOB_ID having max(SALARY) >=4000;

--Q67 Write a query to get the average salary for all departments employing more than 10 employees.
select DEPARTMENT_ID,avg(SALARY) as "Avg Salary" from EMPLOYEES group by DEPARTMENT_ID having count(EMPLOYEE_ID)>10;

--Q68 Write a query to find the name (first_name, last_name) and the salary of the employees who have a higher salary than the employee whose last_name='Bull'.
select (FIRSTNAME + LASTNAME) as "full name",SALARY from EMPLOYEES where SALARY > (select SALARY from EMPLOYEES where LASTNAME='BULL');

--Q69 Write a query to find the name (first_name, last_name) of all employees who works in the IT department.
select (FIRSTNAME + LASTNAME) as "full name" from EMPLOYEES emp join DEPARTMENTS dept 
on emp.DEPARTMENT_ID = dept.DEPARTMENT_ID where dept.DEPARTMENT_NAME = 'IT';

--Q70 

# Employee-Management-System
1.Login Service :

2.Employee Service:

	Models:

		1.Employee:

			ID(Auto Generated) => Int

			EmpId(Primary Key) => String

			ManagerId => String

			EmpName => String

			EmpAge => int

			EmpDOB => DateTime

	    Modules:
			* Module 1 : Add Employee
			* Module 2: Update Employee(Only Phone , Address , Passport Number , Driving License Number
			* Module 3: List Employees Under Manager
			* Module 4: Change Employee State(Active , Inactive , Quit)

3.Apply/Approve Leave Service:

			* Module 5: Apply Leave(Employee)
						Approve Leave(Manager)

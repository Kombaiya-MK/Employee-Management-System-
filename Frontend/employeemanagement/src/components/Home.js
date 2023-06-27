import { useState, useEffect } from "react";
import './Home.css'

const Home = () => {
  const [employees, setEmployees] = useState([]);
  const [employeesFetched, setEmployeesFetched] = useState(false);

  var managerid = {
    managerId: "KB001",
  };

  useEffect(() => {
    fetchEmployees();
  }, []);

  const fetchEmployees = () => {
    console.log("hello");
    fetch("http://localhost:5166/api/Employee/GetEmployees/Get Employees By Manager ID", {
      method: "POST",
      headers: {
        accept: "text/plain",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(managerid),
    })
      .then((response) => response.json())
      .then((data) => {
        setEmployees(data);
        setEmployeesFetched(true);
        console.log(data);
      })
      .catch((error) => console.log(error));
  };

  return (
    <div className="container">
      {employeesFetched ? (
        <table>
          <thead className="th">
            <tr>
              <th>Name</th>
              <th>Age</th>
              <th>Date of Birth</th>
              <th>Email</th>
              <th>Gender</th>
              <th>Passport Number</th>
              <th>Phone Number</th>
              <th>Role</th>
              <th>Status</th>
            </tr>
          </thead>
          <tbody>
            {employees.map((employee) => (
              <tr key={employee.empId}>
                <td>{employee.name}</td>
                <td>{employee.age}</td>
                <td>{employee.dateOfBirth}</td>
                <td>{employee.email}</td>
                <td>{employee.gender}</td>
                <td>{employee.passportNumber}</td>
                <td>{employee.phoneNumber}</td>
                <td>{employee.user.role}</td>
                <td>{employee.user.status}</td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        <button
          onClick={fetchEmployees}
          className="btn btn-primary d-block mx-auto"
          style={{ backgroundColor: "rgb(87, 239, 87)" }}
        >
          Get Employees
        </button>
      )}
    </div>
  );
};

export default Home;

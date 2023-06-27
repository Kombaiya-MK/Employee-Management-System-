import React, { useState, useEffect } from 'react';


const Home = () => {
  const [employees, setEmployees] = useState([]);
  const [employeesFetched, setEmployeesFetched] = useState(false);

  useEffect(() => {
    fetchEmployees();
  }, []);

  const fetchEmployees = () => {
    fetch('/api/employees')
      .then(response => response.json())
      .then(data => {
        setEmployees(data);
        setEmployeesFetched(true);
      })
      .catch(error => console.log(error));
  };

  return (
    <div>
      {employeesFetched ? (
        <table>
          <thead>
            <tr>
              <th>Name</th>
              <th>Age</th>
              <th>Department</th>
            </tr>
          </thead>
          <tbody>
            {employees.map(employee => (
              <tr key={employee.id}>
                <td>{employee.name}</td>
                <td>{employee.age}</td>
                <td>{employee.department}</td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        <button
        onClick={fetchEmployees}
        className="btn btn-primary d-block mx-auto"
        style={{ backgroundColor: 'rgb(87, 239, 87)' }}
      >
        Get Employees
      </button>
      )}
    </div>
  );
};

export default Home;

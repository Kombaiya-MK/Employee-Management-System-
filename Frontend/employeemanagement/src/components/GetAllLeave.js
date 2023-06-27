import React, { useState, useEffect } from 'react';
import './GetAllLeave.css';

function GetAllLeave() {
  const [leavedatas, setLeaves] = useState([]);
  useEffect(() => {}, [leavedatas]);

  var leaves = () => {
    var userDTO={
        "managerId":"111"
    }
    fetch('http://localhost:5009/api/Leave/GetAllLeaves', {
        "method": "POST",
  headers: {
    "accept": "text/plain",
    "Content-Type": 'application/json'
  },
  "body": JSON.stringify(userDTO)
    })   .then(response => response.json())
      .then(res => {
        //console.log (res)
        setLeaves(res);
      })

      .catch(error => {
        console.error(error);
      });
  };
  const [buttonColor, setButtonColor] = useState();

  var change = u => {

    //console.log("in change");
    var updatedLeaveData = {
        leaveId: u.leaveId,
      leaveStatus: u.leaveStatus === "Approve" ? "Dis-Approve" : "Approve"
      //setButtonColor('green');
    };
  
    fetch('http://localhost:5009/api/Leave/UpdateLeaveStatus', {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(updatedLeaveData)
    })
      .catch(error => {
        console.error(error);
      });
  };

  

  return (
    <div>
      <button className='btn-get' onClick={leaves}>Get All</button>
      <br/>      <br/>

      
       <table className="table table-striped">
        <thead>
          <tr>
            <th scope="col">Leave Id</th>
            <th scope="col">Leave Type</th>
            <th scope="col">Employee Id</th>
            <th scope="col">Manager Id</th>
            <th scope="col">Reason</th>
            <th scope="col">Start Date</th>
            <th scope="col">End Date</th>
            <th scope="col">Leave Status</th>
          </tr>
        </thead>
        <tbody>
          {leavedatas.map(u => (
            <tr key={u.leaveId}>
              <th scope="row">{u.leaveId}</th>
              <td>{u.leaveType}</td>
              <td>{u.empId}</td>
              <td>{u.managerId}</td>

              <td>{u.reason}</td>
              <td>{u.startDate}</td>
              <td>{u.endDate}</td>
              
              <td>
                <button style={{ backgroundColor: buttonColor }} className="btn-change" onClick={change(u)}>{u.leaveStatus}</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table> 

    </div>
  );
}

export default GetAllLeave;

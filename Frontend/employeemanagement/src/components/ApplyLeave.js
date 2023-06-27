import React, { useState } from "react";
import './ApplyLeave.css'

function ApplyLeave()
{
    const [leave, setLeave] = useState({

        "leaveType": "",
        "empId": "",
        "managerId":"",
        "reason":"",
        "startDate":"",
        "endDate":"",
        

      });
      var applyLeave=()=>
      {
        fetch('http://localhost:5009/api/Leave/AddLeave',
        {
            "method": "POST",
      headers: {
        "accept": "text/plain",
        "Content-Type": 'application/json'
      },
      "body": JSON.stringify({ ...leave, "leave": {} })
        })
        .then(async (data) => {
            if (data.status == 201) {
    
              var myData = await data.json();
              console.log(myData)
            }
    
          }).catch((err) => {
            console.log(err.error)
          })
      }
    return (
        <div className="Main-Leave">
    <div className="Sub-Leave">
      < div className="sub">
        <div className="Leave">
          <h3> Leave Form</h3>
          <input type="text" placeholder="Leave Type " className="form-control" onChange={(event) => {
            setLeave({ ...leave, "leaveType": event.target.value })

          }} />
          <br />
          <input type="Text" placeholder="Employee Id" className="form-control" onChange={(event) => {
            setLeave({ ...leave, "empId": event.target.value })
          }} /><br />
          <input type="Text" placeholder="Manager Id" className="form-control" onChange={(event) => {
            setLeave({ ...leave, "managerId": event.target.value })
          }} /><br />
          <input type="Text" placeholder="Reason" className="form-control" onChange={(event) => {
            setLeave({ ...leave, "reason": event.target.value })
          }} /><br />
          <label className="label">Start Date</label>
          <input type="Date" placeholder="" className="form-control" onChange={(event) => {
            setLeave({ ...leave, "startDate": event.target.value })
          }} /><br />
          <label className="label">End Date</label>
          <input type="Date" placeholder="End Date" className="form-control" onChange={(event) => {
            setLeave({ ...leave, "endDate": event.target.value })
          }} />
<br/>               <button  className="leavebutton " type="submit" onClick={applyLeave}>Apply Leave</button>

        </div>
      </div>
      </div>
      </div>

    );
}
export default ApplyLeave;

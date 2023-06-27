import { useState } from "react";
import './AddEmployee.css'

function AddEmployees(){

    //const [gender, setGender] = useState("Male");
    const [Employee , setEmployee] = useState(
        {
            "empId": "",
            "user": {
              "empId": "",
              "managerId": "",
              "role": "Admin",
              "status": "",
              "passwordHash": "",
              "passwordKey": ""
            },
            "name": "",
            "dateOfBirth": "",
            "age": 0,
            "gender": "",
            "phoneNumber": "",
            "email": "",
            "address": "",
            "passportNumber": "",
            "dlNumber": "",
            "passwordClear": ""
          }
    )

    var AddEmployee = () => {
        console.log(Employee)
        fetch("http://localhost:5166/api/Employee/Register/Register" , {
            "method":"POST",
            headers:{
                "accept": "text/plain",
                "Content-Type": "application/json"
            },
            "body":JSON.stringify({...Employee,"Employee":{} })})
            .then(async (data)=>{
                     var myData = await data.json();
                     console.log(myData);
                     alert("Welcome " + myData.role);
               }).catch((err)=>{
                 console.log(err.error)

            
        })
    }
    return(
        <div class="container">
            <div className="form-group">
             <h2>Employee Information</h2>
                
                    {/* ----------------------Row 1--------------------------- */}
                    <label className="form-label" htmlFor="employeeName">
                        Name
                    </label>
                    <input
                        className="form-control" id="employeeName" type="text" value={Employee.name} onChange={(event) => {
                            setEmployee({ ...Employee, name: event.target.value });
                        }}
                    />
                    <label className="form-label" htmlFor="dateOfBirth">
                        Date of Birth
                    </label>
                    <input
                        className="form-control" id="dateOfBirth" type="date"value={Employee.dateOfBirth} onChange={(event) => {
                            setEmployee({ ...Employee, dateOfBirth: event.target.value });
                        }}
                    />
                    {/* </div>
                    <div className="form-group"> */}
                    <label className="form-label" htmlFor="gender">
                        Gender
                    </label>
                    <input
                        className="form-control"
                        id="gender"
                        type="text"
                        value={Employee.gender}
                        onChange={(event) => {
                        setEmployee({ ...Employee, gender: event.target.value });
                        }}
                    />

                    <label className="form-label" htmlFor="phoneNumber">
                        Phone Number
                    </label>
                    <input
                        className="form-control"
                        id="phoneNumber"
                        type="phone"
                        value={Employee.phoneNumber}
                        onChange={(event) => {
                        setEmployee({ ...Employee, phoneNumber: event.target.value });
                        }}
                    />

                    <label className="form-label" htmlFor="email">
                       Email
                    </label>
                    <input
                        className="form-control"
                        id="email"
                        type="email"
                        value={Employee.email}
                        onChange={(event) => {
                        setEmployee({ ...Employee, email: event.target.value });
                        }}
                    />

                    <label className="form-label" htmlFor="address">
                        Address
                    </label>
                    <input
                        className="form-control"
                        id="address"
                        type="text"
                        value={Employee.address}
                        onChange={(event) => {
                        setEmployee({ ...Employee, address: event.target.value });
                        }}
                    />

                    <label className="form-label" htmlFor="passportNumber">
                        Passport Number
                    </label>
                    <input
                        className="form-control"
                        id="passportNumber"
                        type="text"
                        value={Employee.passportNumber}
                        onChange={(event) => {
                        setEmployee({ ...Employee, passportNumber: event.target.value });
                        }}
                    />

                    <label className="form-label" htmlFor="dlNumber">
                        Driving License Number
                    </label>
                    <input
                        className="form-control"
                        id="dlNumber"
                        type="text"
                        value={Employee.dlNumber}
                        onChange={(event) => {
                        setEmployee({ ...Employee, dlNumber: event.target.value });
                        }}
                    />

                    <label className="form-label" htmlFor="password">
                        Password
                    </label>
                    <input
                        className="form-control"
                        id="password"
                        type="password"
                        value={Employee.passwordClear}
                        onChange={(event) => {
                        setEmployee({ ...Employee, passwordClear: event.target.value });
                        }}
                    />
                    <label className="form-label" htmlFor="managerId">
                        Manager ID
                    </label>
                    <input
                        className="form-control"
                        id="managerId"
                        type="text"
                        value={Employee.user.managerId}
                        onChange={(event) => {
                        setEmployee({ ...Employee, managerId: event.target.value });
                        }}
                    />
                    <br/>
                    <button className="btn btn-primary" >
                                Cancel
                    </button>&nbsp;&nbsp;&nbsp;
                    <button className="btn btn-primary" onClick={AddEmployee}>
                        Confirm
                    </button>
            </div>
                    
        </div>
   
    )



}
export default AddEmployees;


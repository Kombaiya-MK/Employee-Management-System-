import { useState } from "react";
import './AddEmployee.css'

function AddEmployees(){

    const [Employee , setEmployee] = useState(
        {
            "id": 0,
            "empId": "",
            "user": {
              "empId": "",
              "managerId": "",
              "role": "",
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
        <div>
            <div className="alert alert-primary">
                <h2>Add Employee Details</h2>
                <div>
                    <label className="form-control" id="forms">
                        Employee Name
                    </label>
                    <input className="form-control" id="forms" type="text" value = {Employee.name} onChange={(event)=>{
                        setEmployee({...Employee,"name":event.target.value})
                    }}/>
                    <label className="form-control" id="forms">
                        Employee dateOfBirth
                    </label>
                    <input className="form-control" id="forms" type="date" value = {Employee.dateOfBirth} onChange={(event)=>{
                        setEmployee({...Employee,"dateOfBirth":event.target.value})
                    }}/>
                    <label className="form-control" id="forms">
                        Employee Age
                    </label>
                    <input className="form-control" id="forms" type="number" value = {Employee.age} onChange={(event)=>{
                        setEmployee({...Employee,"age":event.target.value})
                    }}/>
                    <label className="form-control" id="forms">
                        Employee gender
                    </label>
                    <input className="form-control" id="forms"  type="text" value = {Employee.gender} onChange={(event)=>{
                        setEmployee({...Employee,"gender":event.target.value})
                    }}/>
                    <label className="form-control" id="forms">
                        Employee phone Number
                    </label>
                    <input className="form-control" id="forms" type="phone" value = {Employee.phoneNumber} onChange={(event)=>{
                        setEmployee({...Employee,"phoneNumber":event.target.value})
                    }}/>
                    <label className="form-control" id="forms">
                        Employee email
                    </label>
                    <input className="form-control" id="forms" type="email" value = {Employee.email} onChange={(event)=>{
                        setEmployee({...Employee,"email":event.target.value})
                    }}/>
                    <label className="form-control" id="forms">
                        Employee address
                    </label>
                    <input className="form-control" id="forms" type="text" value = {Employee.address} onChange={(event)=>{
                        setEmployee({...Employee,"address":event.target.value})
                    }}/>
                    <label className="form-control" id="forms">
                        Employee passport Number
                    </label>
                    <input className="form-control" id="forms" type="text" value = {Employee.passportNumber} onChange={(event)=>{
                        setEmployee({...Employee,"passportNumber":event.target.value})
                    }}/>
                    <label className="form-control" id="forms">
                        Employee Driving License Number
                    </label>
                    <input className="form-control" id="forms" type="text" value = {Employee.dlNumber} onChange={(event)=>{
                        setEmployee({...Employee,"dlNumber":event.target.value})
                    }}/>
                    <label className="form-control" id="forms">
                        Password 
                    </label>
                    <input className="form-control" id="forms" type="password" value = {Employee.passwordClear} onChange={(event)=>{
                        setEmployee({...Employee,"passwordClear":event.target.value})
                    }}/>
                    <button className="btn btn-primary" onClick={AddEmployee}>Confirm</button>
                </div>
            </div>
    </div>
    )



}
export default AddEmployees;


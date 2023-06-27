import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.css"
import './Login.css'
import { Navigate } from "react-router-dom";


function Login()
{
    const [Employee , setEmployee] = useState(
        {
            "empId": "string",
            "password": "string",
            "managerID": "string",
            "status": "string",
            "role": "string",
            "token": "string"
        }
        
    );

    var Login = () => {
        console.log(Employee)
        console.log("hello")
        fetch("http://localhost:5199/api/User/Login" ,{
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
                     setEmployee(myData);

               }).catch((err)=>{
                 console.log(err.error)
        })
    }
    return (
        <div>
            <label className="form-control Login label">Employee ID</label>
            <input type="number" className="form-control Login " placeholder="Enter ID...." onChange={(event)=>{
                setEmployeetUser({...Employee,"empId":event.target.value})
            }} />
            <label  className="form-control Login label">Password</label>
            <input type="text" className="form-control Login" placeholder="Enter Password...." onChange={(event)=>{
                setEmployee({...Employee,"password":event.target.value})
            }} />
            <button onClick={Login} className="btn btn-success">Login</button>
        </div>
    )
}

export default Login;
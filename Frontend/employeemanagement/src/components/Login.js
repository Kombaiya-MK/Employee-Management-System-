import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.css"
import { Navigate } from "react-router-dom";
import Navbar from "./Navbar";
import './Login.css'


function Login()
{
    const [Employee , setEmployee] = useState(
        {
            "empId": "",
            "password": "",
            "managerID": "",
            "status": "",
            "role": "",
            "token": ""
        }
        
    );

    var Login = () => {
        fetch("http://localhost:5166/api/Employee/Login/Login" ,{
            "method":"POST",
            headers:{
                "accept": "text/plain",
                "Content-Type": "application/json"
            },
            "body":JSON.stringify({...Employee,"Employee":{} })})
            .then(async (data)=>{
                    var myData = await data.json();
                    console.log(myData)
                    if(myData.status == 201)
                    {
                        Navigate("/Home");
                    }
                     setEmployee(myData);

               }).catch((err)=>{
                 console.log(err.error)
        })
    }
    return (
        <div>
            {/* <label className="form-control Login label">Employee ID</label>
            <input type="text" className="form-control Login " placeholder="Enter ID...." onChange={(event)=>{
                setEmployee({...Employee,"empId":event.target.value})
            }} />
            <label  className="form-control Login label">Password</label>
            <input type="text" className="form-control Login" placeholder="Enter Password...." onChange={(event)=>{
                setEmployee({...Employee,"password":event.target.value})
            }} /> */}
            <section className="vh-100" style={{ backgroundColor: '#9A616D' }}>
      <div className="container py-5 h-100">
        <div className="row d-flex justify-content-center align-items-center h-100">
          <div className="col col-xl-10">
            <div className="card" style={{ borderRadius: '1rem' }}>
              <div className="row g-0">
                <div className="col-md-6 col-lg-5 d-none d-md-block">
                  <img
                    src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/img1.webp"
                    alt="login form"
                    className="img-fluid"
                    style={{ borderRadius: '1rem 0 0 1rem' }}
                  />
                </div>
                <div className="col-md-6 col-lg-7 d-flex align-items-center">
                  <div className="card-body p-4 p-lg-5 text-black">
                    <form>
                      <h5 className="fw-normal mb-3 pb-3" style={{ letterSpacing: '1px' }}>
                        Sign into your account
                      </h5>
                      <div className="form-outline mb-4">
                        <input
                          type="email"
                          id="form2Example17"
                          className="form-control form-control-lg"
                          placeholder="Enter ID...."
                          value={Employee.empId}
                          onChange={(event) => setEmployee({ ...Employee, empId: event.target.value })}
                        />
                        <label className="form-label" htmlFor="form2Example17">
                          Employee ID
                        </label>
                      </div>
                      <div className="form-outline mb-4">
                        <input
                          type="password"
                          id="form2Example27"
                          className="form-control form-control-lg"
                          placeholder="Enter Password...."
                          value={Employee.password}
                          onChange={(event) => setEmployee({ ...Employee, password: event.target.value })}
                        />
                        <label className="form-label" htmlFor="form2Example27">
                          Password
                        </label>
                      </div>
                      <div className="pt-1 mb-4">
                        <button className="btn btn-dark btn-lg btn-block" type="button" onClick={Login}>
                          Login
                        </button>
                      </div>
                      <a href="#!" className="small text-muted">
                        Terms of use.
                      </a>
                      <a href="#!" className="small text-muted">
                        Privacy policy
                      </a>
                    </form>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
        </div>
    )
}

export default Login;
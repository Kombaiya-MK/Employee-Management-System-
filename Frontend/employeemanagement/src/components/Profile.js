import React, { useState, useEffect } from 'react';
import './Profile.css';

function Profile() {
  const [showInput1, setShowInput1] = useState(false);
  const [showInput2, setShowInput2] = useState(false);
  const [showInput3, setShowInput3] = useState(false);
  const [showInput4, setShowInput4] = useState(false);

  const [profile, setProfile] = useState(null);

  const [phoneNo , setPhoneNo]=useState({
      "phoneNumber":""
  });

  const [passNo , setPassNo]=useState({
    "passportNo":""
  });

   const [dlNumber , setdlNumber]=useState({
  "dlNo":""
   });

   const [address , setAddress]=useState({
  "newAddress":""
   });

  useEffect(() => {
    fetchData();
  }, []);

  const handleButtonClick1 = () => {
    setShowInput1(true);
  };
  const handleButtonClick2 = () => {
    setShowInput2(true);  
  };
  const handleButtonClick3 = () => {
    setShowInput3(true);
  };
  const handleButtonClick4 = () => {
    setShowInput4(true);
  };

  //fetch Data 
  const fetchData = async () => {
    try {
      const response = await fetch("http://localhost:5166/api/Employee/GetProfile/Get%20Profile", {
        method: "POST",
        headers: {
          accept: "text/plain",
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ empID: "string" }),
      });
      const data = await response.json();
      setProfile(data);
      console.log(data);
    } catch (error) {
      console.error('Error fetching data:', error);
    }
  };

  const changePhoneNo = async () => {
    const output = {
      "empID": "string",
      "updateData": phoneNo.phoneNumber,
    };
    console.log(output);
    try {
      const response = await fetch("http://localhost:5166/api/Employee/UpdatePhoneNo/Update Phone Number", {
        method: "PUT",
        headers: {
          accept: "text/plain", 
          "Content-Type": "application/json",
        },
        body: JSON.stringify(output),
      });
      const data = await response.json();
    } catch (error) {
      console.error(error);
    }
    setShowInput1(false);
    fetchData();
  };

  const changePassNo = async () => {
    const output = {
      "empID": "string",
      "updateData": passNo.passportNo,
    };
    console.log(output);
    try {
      const response = await fetch("http://localhost:5166/api/Employee/UpdatePassportNo/Update Passport number", {
        method: "PUT",
        headers: {
          accept: "text/plain", 
          "Content-Type": "application/json",
        },
        body: JSON.stringify(output),
      });
      const data = await response.json();
    } catch (error) {
      console.error(error);
    }
    setShowInput2(false);
    fetchData();
  };


  const changeDLNo = async () => {
    const output = {
      "empID": "string",
      "updateData": dlNumber.dlNo,
    };
    console.log(output);
    try {
      const response = await fetch("http://localhost:5166/api/Employee/UpdateDLNumber/Update DL Number", {
        method: "PUT",
        headers: {
          accept: "text/plain", 
          "Content-Type": "application/json",
        },
        body: JSON.stringify(output),
      });
      const data = await response.json();
    } catch (error) {
      console.error(error);
    }
    setShowInput3(false);
    fetchData();
  };


  const changeAddress = async () => {
    const output = {
      "empID": "string",
      "updateData": address.newAddress
    };
    console.log(output);
    try {
      const response = await fetch("http://localhost:5166/api/Employee/UpdateAddress/Update Address", {
        method: "PUT",
        headers: {
          accept: "text/plain", 
          "Content-Type": "application/json",
        },
        body: JSON.stringify(output),
      });
      const data = await response.json();
    } catch (error) {
      console.error(error);
    }
    setShowInput4(false);
    fetchData();
  };


  return (
    <div class="profile-container">
  <h3>Hello..!</h3>
  {profile ? (
    
    
    <table class="table table-bordered profile-table">
      <tbody>
        <tr>
          <th>Name</th>
          <td>{profile.name}</td>
        </tr>
        <tr>
          <th>Employee ID</th>
          <td>{profile.empId}</td>
        </tr>
        <tr>
          <th>Date of Birth</th>
          <td>{profile.dateOfBirth}</td>
        </tr>
        <tr>
          <th>Age</th>
          <td>{profile.age}</td>
        </tr>
        <tr>
          <th>Status</th>
          <td>{profile.user.status}</td>
        </tr>
        <tr>
          <th>Role</th>
          <td>{profile.user.role}</td>
        </tr>
        <tr>
          <th>Manager ID</th>
          <td>{profile.user.managerId}</td>
        </tr>
        <tr>
          <th>Address</th>
          <td>
            {profile.address}
            <div class="float-right">
              <button
                class="btn btn-sm btn-primary mt-2"
                onClick={handleButtonClick4}
              >
                Change
              </button>
            </div>
            {showInput4 && (
              <div class="form-group">
                <input
                  type="text"
                  class="form-control form-control-lg"
                  value={address.newAddress}
                  onChange={(event) => {
                    setAddress({
                      ...address,
                      newAddress: event.target.value,
                    });
                  }}
                />
                <button
                  class="btn btn-sm btn-success mt-2"
                  onClick={() => changeAddress()}
                >
                  Submit
                </button>
              </div>
            )}
          </td>
        </tr>
        <tr>
          <th>Passport No</th>
          <td>
            {profile.passportNumber}
            <div class="float-right">
              <button
                class="btn btn-sm btn-primary mt-2"
                onClick={handleButtonClick2}
              >
                Change
              </button>
            </div>
            {showInput2 && (
              <div class="form-group">
                <input
                  type="text"
                  class="form-control form-control-lg"
                  value={passNo.passportNo}
                  onChange={(event) => {
                    setPassNo({ ...passNo, passportNo: event.target.value });
                  }}
                />
                <button
                  class="btn btn-sm btn-success mt-2"
                  onClick={() => changePassNo()}
                >
                  Submit
                </button>
              </div>
            )}
          </td>
        </tr>
        <tr>
          <th>DL Number</th>
          <td>
            {profile.dlNumber}
            <div class="float-right">
              <button
                class="btn btn-sm btn-primary mt-2"
                onClick={handleButtonClick3}
              >
                Change
              </button>
            </div>
            {showInput3 && (
              <div class="form-group">
                <input
                  type="text"
                  class="form-control form-control-lg"
                  value={dlNumber.dlNo}
                  onChange={(event) => {
                    setdlNumber({ ...dlNumber, dlNo: event.target.value });
                  }}
                />
                <button
                  class="btn btn-sm btn-success mt-2"
                  onClick={() => changeDLNo()}
                >
                  Submit
                </button>
              </div>
            )}
          </td>
        </tr>
        <tr>
          <th>Phone Number</th>
          <td>
            {profile.phoneNumber}
            <div class="float-right">
              <button
                class="btn btn-sm btn-primary mt-2"
                onClick={handleButtonClick1}
              >
                Change
              </button>
            </div>
            {showInput1 && (
              <div class="form-group">
                <input
                  type="text"
                  class="form-control form-control-lg"
                  value={phoneNo.phoneNumber}
                  onChange={(event) => {
                    setPhoneNo({ ...phoneNo, phoneNumber: event.target.value });
                  }}
                />
                <button
                  class="btn btn-sm btn-success mt-2"
                  onClick={() => changePhoneNo()}
                >
                  Submit
                </button>
              </div>
            )}
          </td>
        </tr>
      </tbody>
    </table>
  ) : (
    <p>Loading...</p>
  )}
</div>
  
  );
}

export default Profile;
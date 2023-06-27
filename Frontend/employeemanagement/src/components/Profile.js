import React, { useState, useEffect } from 'react';
import './Profile.css';

function Profile() {
  const [showInput, setShowInput] = useState(false);
  const [profile, setProfile] = useState(null);

  const [phoneNo , setPhoneNo]=useState({
      "phoneNumber":""
  });

  useEffect(() => {
    fetchData();
  }, []);

  const handleButtonClick = () => {
    setShowInput(true);
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
    setShowInput(false);
    fetchData();
  };


  return (
    <div className="profile-container">
      <h3>Hello, this is the profile</h3>
      {profile ? (
        <table className="profile-table">
          <tbody>
            <tr>
              <th>Name</th>
              <td>{profile.name}</td>
            </tr>
            <tr>
              <th>Email</th>
              <td>{profile.email}</td>
            </tr>
            <tr>
              <th>Phone Number</th>
              <td>{profile.phoneNumber}</td>
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

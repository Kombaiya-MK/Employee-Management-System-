import React, { useState, useEffect } from 'react';
import './Profile.css';

function Profile() {
  const requestBody = {
    empID: "string"
  };
  const [profile, setProfile] = useState(null);

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    try {
      const response = await fetch("http://localhost:5166/api/Employee/GetProfile/Get Profile", {
        method: "POST",
        headers: {
          accept: "text/plain",
          "Content-Type": 'application/json'
        },
        body: JSON.stringify(requestBody),
      });
      const data = await response.json();
      setProfile(data);
      console.log(data);
    } catch (error) {
      console.error('Error fetching data:', error);
    }
  };

  const changePassportNo = async (passportNumber) => {
    const output = {
      empID: "string",
      updateData: passportNumber,
    };
    const response = await fetch("http://localhost:5166/api/Employee/UpdatePhoneNo/Update Phone Number", {
      method: "PUT",
      headers: {
        accept: "text/plain",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(output),
    });
    const data = await response.json();
  };

  return (
    <div className="profile-container">
      <h3>Hello, this is the profile</h3>
      {profile ? (
        <div>
          <h2>{profile.name}</h2>

          <div className="card">
            <div className="details-container">
              <div className="detail-item">
                <strong>Name:</strong> {profile.name}
              </div>
              <div className="detail-item">
                <strong>Employee ID:</strong> {profile.empId}
              </div>
              <div className="detail-item">
                <strong>Date of Birth:</strong> {profile.dateOfBirth}
              </div>
              <div className="detail-item">
                <strong>Age:</strong> {profile.age}
              </div>
              <div className="detail-item">
                <strong>Status:</strong> {profile.user.status}
              </div>
              <div className="detail-item">
                <strong>Role:</strong> {profile.user.role}
              </div>
              <div className="detail-item">
                <strong>Manager ID:</strong> {profile.user.managerId}
              </div>
              <div className="detail-item">
                <strong>Address:</strong> {profile.address}
                <button onClick={() => changePassportNo(profile.address)}>Change</button>
              </div>
              <div className="detail-item">
                <strong>Passport No:</strong> {profile.passportNumber}
                <button onClick={() => changePassportNo(profile.passportNumber)}>Change</button>
              </div>
              <div className="detail-item">
                <strong>DL Number:</strong> {profile.dlNumber}
                <button onClick={() => changePassportNo(profile.dlNumber)}>Change</button>
              </div>
              <div className="detail-item">
                <strong>Phone Number:</strong> {profile.phoneNumber}
                <button onClick={() => changePassportNo(profile.phoneNumber)}>Change</button>
              </div>
            </div>
          </div>
        </div>
      ) : (
        <p>Loading...</p>
      )}
    </div>
  );
}


import React, { useState } from 'react';

import './UpdateStatus.css';

function UpdateStatus() {
  const [EmpId, setEmpId] = useState('');
  const [Status, setStatus] = useState('');

  const handleStatusChange = (e) => {
    setStatus(e.target.value);
  };
  const handleUpdateStatus = async () => {
    try {
      const response = await fetch('http://localhost:5166/api/Employee/UpdateStatus/Update Status', {
        method: 'PUT',
        body: JSON.stringify({ EmpId, Status }),
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (response.ok) {
        const data = await response.json();
        console.log('Response:', data);
        window.alert('Status updated successfully'); // Display success alert
      } else {
        console.log('Error:', response.status);
      }
    } catch (error) {
      console.log('Error:', error);
    }
  };
  

  const isQuitClicked = Status === 'quit';
  const isDisabled = isQuitClicked ? true : false;

  return (
    <div>
      <form className='container'>
        <label>ID:</label>
        <input type="text" value={EmpId} onChange={(e) => setEmpId(e.target.value)} />

        <label>Status:</label>
        <div>
          <label>
            <input
              type="radio"
              value="active"
              checked={Status === 'active'}
              onChange={handleStatusChange}
              disabled={isDisabled}
            />
            Active
          </label>
        </div>
        <div>
          <label>
            <input
              type="radio"
              value="inactive"
              checked={Status === 'inactive'}
              onChange={handleStatusChange}
              disabled={isDisabled}
            />
            Inactive
          </label>
        </div>
        <div>
          <label>
            <input type="radio" value="quit" checked={Status === 'quit'} onChange={handleStatusChange} />
            Quit
          </label>
        </div>

        <button type="button" onClick={handleUpdateStatus}>
          Update Status
        </button>
      </form>
    </div>
  );
}

export default UpdateStatus;
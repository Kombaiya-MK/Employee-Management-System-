import React, { useState } from 'react';
import { Link } from 'react-router-dom'; // If using React Router
import './Navbar.css'; // Custom CSS for additional styles
import 'bootstrap/dist/css/bootstrap.min.css'; // Bootstrap CSS
import './Navbar.css';


const Navbar = () => {
  const [activeLink, setActiveLink] = useState('Home'); // State for active link

  // Function to handle active link change
  const handleLinkClick = (linkName) => {
    setActiveLink(linkName);
  };

  return (
    <nav className="navbar navbar-expand-lg navbar-light bg-light">
      <div className="container">
      {/* <img src={logo} alt="Logo" className="navbar-logo" />Employee Management System */}
      Employee Management System
        <button
          className="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarNav"
          aria-controls="navbarNav"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav ms-auto">
            <li className={`nav-item home ${activeLink === 'Home' ? 'active' : ''}`}>
              <Link
                className="nav-link"
                to="/"
                onClick={() => handleLinkClick('Home')}
              >
                Home
              </Link>
            </li>
            <li className={`nav-item home ${activeLink === 'Add Employees' ? 'active' : ''}`}>
              <Link
                className="nav-link"
                to="/about"
                onClick={() => handleLinkClick('Add Employees')}
              >
               Add Employees 
              </Link>
            </li>
            <li className={`nav-item home ${activeLink === 'profile' ? 'active' : ''}`}>
              <Link
                className="nav-link"
                to="/profile"
                onClick={() => handleLinkClick('profile')}
              >
               Profile 
              </Link>
            </li>
            <li className={`nav-item home ${activeLink === 'Update Employees' ? 'active' : ''}`}>
              <Link
                className="nav-link"
                to="/Update Employees"
                onClick={() => handleLinkClick('Update Employees')}
              >
              Update Employees
              </Link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;

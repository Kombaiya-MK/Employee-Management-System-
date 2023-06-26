import React, { useState } from 'react';
import { Link } from 'react-router-dom'; // If using React Router
import './Navbar.css'; // Custom CSS for additional styles
import 'bootstrap/dist/css/bootstrap.min.css'; // Bootstrap CSS

const Navbar = () => {
  const [activeLink, setActiveLink] = useState('Home'); // State for active link

  // Function to handle active link change
  const handleLinkClick = (linkName) => {
    setActiveLink(linkName);
  };

  return (
    <nav className="navbar navbar-expand-lg navbar-light bg-light">
      <div className="container">
        <Link className="navbar-brand" to="/">Employee Management System</Link>
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
            <li className={`nav-item ${activeLink === 'Home' ? 'active' : ''}`}>
              <Link
                className="nav-link"
                to="/"
                onClick={() => handleLinkClick('Home')}
              >
                Home
              </Link>
            </li>
            <li className={`nav-item ${activeLink === 'Add Employees' ? 'active' : ''}`}>
              <Link
                className="nav-link"
                to="/about"
                onClick={() => handleLinkClick('About')}
              >
                About
              </Link>
            </li>
            <li className={`nav-item ${activeLink === 'Services' ? 'active' : ''}`}>
              <Link
                className="nav-link"
                to="/services"
                onClick={() => handleLinkClick('Services')}
              >
                Services
              </Link>
            </li>
            <li className={`nav-item ${activeLink === 'Contact' ? 'active' : ''}`}>
              <Link
                className="nav-link"
                to="/contact"
                onClick={() => handleLinkClick('Contact')}
              >
                Contact
              </Link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;

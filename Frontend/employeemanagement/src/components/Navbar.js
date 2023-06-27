// Navbar.js
import React from 'react';
import { Link, NavLink } from 'react-router-dom';
import './Navbar.css'

function Navbar() {
  return (
    <nav className="navbar navbar-expand-lg navbar-light" style={{ backgroundColor: 'lightgray' }}>
      <h2>Employee Management System</h2>
      <div className="collapse navbar-collapse" id="navbarNav">
        <div className="container">
          <ul className="navbar-nav ml-auto">
            <li className="nav-item">
              <NavLink exact to="/" className="nav-link home">Home</NavLink>
            </li>
            <li className="nav-item">
              <NavLink to="/create" className="nav-link home">Add Employees</NavLink>
            </li>
            <li className="nav-item">
              <NavLink to="/list" className="nav-link home">Update Employees</NavLink>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
}

export default Navbar;

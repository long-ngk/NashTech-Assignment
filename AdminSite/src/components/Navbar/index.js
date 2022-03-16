import React, { Component } from "react";
import { Link } from "react-router-dom";
import { UserContext } from "../../index";
import "./Navbar.css";

export default class Navbar extends Component {
  state = {
    username: "Tuan",
  };

  render() {
    return (
      <UserContext.Consumer>
        {(value) => (
          <nav id="navbar">
            <ul>
              <Link to="/">
                <li>Home</li>
              </Link>
              <Link to="/contact">
                <li>Contact</li>
              </Link>
              <Link to="/about">
                <li>About</li>
              </Link>
              <Link to="/category">
                <li>Category</li>
              </Link>
            </ul>

            <input type="text" onChange={(e) => this.props.onSearchKey(e)} />

            <div className="nav-details">
              <p className="nav-username"> {value.username} </p>
            </div>
          </nav>
        )}
      </UserContext.Consumer>
    );
  }
}

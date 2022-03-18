import React from "react";
import { Nav, Navbar, Container } from "react-bootstrap";
import { Link } from "react-router-dom";
export default function Navigation() {
  return (
    <Navbar bg="primary" variant="dark">
      <Container>
        <Navbar.Brand className="fs-4" as={Link} to="/">
          Pook Shop
        </Navbar.Brand>
        <Nav className="me-auto">
          <Nav.Link className="fs-5" as={Link} to="/">
            Home
          </Nav.Link>
          <Nav.Link className="fs-5" as={Link} to="category">
            Category
          </Nav.Link>
          <Nav.Link className="fs-5" as={Link} to="product">
            Product
          </Nav.Link>
        </Nav>
      </Container>
    </Navbar>
  );
}

import React, { useState } from "react";
import { Nav, Navbar, Container } from "react-bootstrap";
import { Link } from "react-router-dom";
import { useEffect } from "react";
import { Modal, Button } from "react-bootstrap";
export default function Navigation() {
	const [email, setEmail] = useState("");
	const [show, setShow] = useState(false);
	const handleClose = () => setShow(false);
	const handleShow = () => setShow(true);
	const handleLogout = () => {
		setShow(false);
		sessionStorage.clear();
		window.location.href = "/login";
	};

	useEffect(() => {
		let mail = JSON.parse(sessionStorage.getItem("email"));
		if (mail != null) setEmail(mail);
	}, [email]);

	return (
		<>
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
						<Nav.Link className="fs-5">Hello {email}</Nav.Link>
						<Nav.Link className="fs-5" onClick={handleShow}>
							Logout
						</Nav.Link>
					</Nav>
				</Container>
			</Navbar>

			<Modal show={show} onHide={handleClose}>
				<Modal.Header closeButton>
					<Modal.Title>Log out</Modal.Title>
				</Modal.Header>
				<Modal.Body>Are you sure want to log out?</Modal.Body>
				<Modal.Footer>
					<Button variant="secondary" onClick={handleClose}>
						Cancel
					</Button>
					<Button variant="primary" onClick={handleLogout}>
						Yes
					</Button>
				</Modal.Footer>
			</Modal>
		</>
	);
}

import React from "react";
import { Modal, Button, Row, Col, Form } from "react-bootstrap";

export default function CreateProductModal(props) {
	const { REACT_APP_BACKEND_API } = process.env;

	const handleSubmit = (event) => {
		event.preventDefault();
		fetch(REACT_APP_BACKEND_API + "product", {
			method: "POST",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify({
				ProductName: event.target.ProductName.value,
				Description: event.target.Description.value,
			}),
		})
			.then((response) => response.json())
			.then(() => {
				alert("Created successfully!!");
			})
			.catch(() => alert("Failed to create product"));
	};

	return (
		<>
			<Modal {...props}>
				<Modal.Header>
					<Modal.Title>Add Product</Modal.Title>
				</Modal.Header>
				<Modal.Body>
					<Row>
						<Col sm={12}>
							<Form onSubmit={handleSubmit}>
								<Form.Group
									className="mb-3"
									controlId="ProductName"
								>
									<Form.Label>Product Name</Form.Label>
									<Form.Control
										type="text"
										name="ProductName"
										required
										placeholder="Product Name"
									></Form.Control>
								</Form.Group>
								<Form.Group
									className="mb-3"
									controlId="Description"
								>
									<Form.Label>Description</Form.Label>
									<Form.Control
										as="textarea"
										type="text"
										name="Description"
										required
										placeholder="Description"
									></Form.Control>
								</Form.Group>
								<Form.Group>
									<Button
										className="mt-2"
										variant="primary"
										type="submit"
										onClick={props.onHide}
									>
										Add Product
									</Button>
								</Form.Group>
							</Form>
						</Col>
					</Row>
				</Modal.Body>
				<Modal.Footer>
					<Button variant="danger" onClick={props.onHide}>
						Close
					</Button>
				</Modal.Footer>
			</Modal>
		</>
	);
}

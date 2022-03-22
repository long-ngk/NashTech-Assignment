import React from "react";
import { Modal, Button, Row, Col, Form } from "react-bootstrap";

export default function EditProductModal(props) {
	const { REACT_APP_BACKEND_API } = process.env;

	const handleSubmit = (event) => {
		event.preventDefault();

		const requestOptions = {
			method: "PUT",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify({
				ProductID: event.target.ProductID.value,
				ProductName: event.target.ProductName.value,
				Description: event.target.Description.value,
				CreatedDate: props.product.CreatedDate,
			}),
		};

		fetch(REACT_APP_BACKEND_API + "product", requestOptions)
			.then((response) => response.text())
			.then(() => alert("Edited successfully!!"))
			.catch((error) => {
				alert("Failed to edit product");
				console.error(error);
			});
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
									controlId="ProductID"
								>
									<Form.Label>Product ID</Form.Label>
									<Form.Control
										type="text"
										name="ProductID"
										disabled
										defaultValue={props.product.ProductID}
									></Form.Control>
								</Form.Group>
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
										defaultValue={props.product.ProductName}
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
										defaultValue={props.product.Description}
									></Form.Control>
								</Form.Group>
								<Form.Group>
									<Button
										className="mt-2"
										variant="primary"
										type="submit"
										onClick={props.onHide}
									>
										Update Product
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

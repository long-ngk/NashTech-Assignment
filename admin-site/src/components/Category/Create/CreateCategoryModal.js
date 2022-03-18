import React from "react";
import { Modal, Button, Row, Col, Form } from "react-bootstrap";

export default function CreateCategoryModal(props) {
	const { REACT_APP_BACKEND_API } = process.env;

	const handleSubmit = (event) => {
		event.preventDefault();
		fetch(REACT_APP_BACKEND_API + "category", {
			method: "POST",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify({
				CategoryName: event.target.CategoryName.value,
				Description: event.target.Description.value,
			}),
		})
			.then((response) => response.json())
			.then(() => {
				alert("Created successfully!!");
			})
			.catch(() => alert("Failed to create category"));
	};

	return (
		<>
			<Modal {...props}>
				<Modal.Header>
					<Modal.Title>Add Category</Modal.Title>
				</Modal.Header>
				<Modal.Body>
					<Row>
						<Col sm={12}>
							<Form onSubmit={handleSubmit}>
								<Form.Group
									className="mb-3"
									controlId="CategoryName"
								>
									<Form.Label>Category Name</Form.Label>
									<Form.Control
										type="text"
										name="CategoryName"
										required
										placeholder="Category Name"
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
										Add Category
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

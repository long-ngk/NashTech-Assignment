import React from "react";
import { Modal, Button, Row, Col, Form } from "react-bootstrap";

export default function EditCategoryModal(props) {
	const { REACT_APP_BACKEND_API } = process.env;

	const handleSubmit = (event) => {
		event.preventDefault();

		const requestOptions = {
			method: "PUT",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify({
				CategoryID: event.target.CategoryID.value,
				CategoryName: event.target.CategoryName.value,
				Description: event.target.Description.value,
				CreatedDate: props.category.CreatedDate,
			}),
		};

		fetch(REACT_APP_BACKEND_API + "category", requestOptions)
			.then((response) => response.text())
			.then(() => alert("Edited successfully!!"))
			.catch((error) => {
				alert("Failed to edit category");
				console.error(error);
			});
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
									controlId="CategoryID"
								>
									<Form.Label>Category ID</Form.Label>
									<Form.Control
										type="text"
										name="CategoryID"
										disabled
										defaultValue={props.category.CategoryID}
									></Form.Control>
								</Form.Group>
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
										defaultValue={
											props.category.CategoryName
										}
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
										defaultValue={
											props.category.Description
										}
									></Form.Control>
								</Form.Group>
								<Form.Group>
									<Button
										className="mt-2"
										variant="primary"
										type="submit"
										onClick={props.onHide}
									>
										Update Category
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

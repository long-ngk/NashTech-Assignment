import React, { useState, useEffect } from "react";
import { Table } from "react-bootstrap";
import { Button, ButtonToolbar } from "react-bootstrap";
import CreateCategoryModal from "./Create/CreateCategoryModal";
import EditCategoryModal from "./Edit/EditCategoryModal";
export default function Category(props) {
	const [categories, setCategories] = useState([]);
	const [createModalShow, setCreateModalShow] = useState(false);
	const [editModalShow, setEditModalShow] = useState(false);

	const [categoryObj, setCategoryObj] = useState({});

	const { REACT_APP_BACKEND_API } = process.env;
	let jwtToken = JSON.parse(sessionStorage.getItem("tokenInfo"));

	let config = {
		headers: {
			Authorization: "Bearer " + jwtToken.token,
		},
	};
	const refreshCategoryList = () => {
		fetch(REACT_APP_BACKEND_API + "category", config)
			.then((response) => response.json())
			.then((categories) => {
				setCategories(categories);
			});
	};

	useEffect(() => {
		refreshCategoryList();
	}, []);

	const setCreateModalClose = () => setCreateModalShow(false);
	const setEditModalClose = () => setEditModalShow(false);

	const deleteCategory = (categoryID, categoryName) => {
		if (
			window.confirm(`Are you sure you want to delete "${categoryName}"?`)
		) {
			const requestOptions = {
				method: "DELETE",
				headers: {
					"Content-Type": "application/json",
					Authorization: "Bearer " + jwtToken.token,
				},
			};
			fetch(
				REACT_APP_BACKEND_API + "category/" + categoryID,
				requestOptions
			)
				.then((res) => refreshCategoryList())
				.catch((e) => console.log(e));
			// alert("Deleted successfully!!");
			// refreshCategoryList();
		}
	};

	return (
		<React.Fragment>
			<Table className="mt-4" striped bordered hover size="sm">
				<thead>
					<tr>
						<th>Category ID</th>
						<th>Category Name</th>
						<th>Description</th>
						<th>Action</th>
					</tr>
				</thead>
				<tbody>
					{categories.map((category) => (
						<tr key={category.CategoryID}>
							<td>{category.CategoryID}</td>
							<td>{category.CategoryName}</td>
							<td>{category.Description}</td>
							<td>
								<ButtonToolbar>
									<Button
										className="me-2"
										variant="info"
										onClick={() => {
											setEditModalShow(true);
											setCategoryObj(category);
										}}
									>
										Edit
									</Button>
									<Button
										className="me-2"
										variant="danger"
										onClick={() =>
											deleteCategory(
												category.CategoryID,
												category.CategoryName
											)
										}
									>
										Delete
									</Button>
									<EditCategoryModal
										show={editModalShow}
										onHide={setEditModalClose}
										category={categoryObj}
										token={jwtToken.token}
									/>
								</ButtonToolbar>
							</td>
						</tr>
					))}
				</tbody>
			</Table>

			<ButtonToolbar>
				<Button
					variant="primary"
					onClick={() => setCreateModalShow(true)}
				>
					Add Category
				</Button>

				<CreateCategoryModal
					show={createModalShow}
					onHide={setCreateModalClose}
					token={jwtToken.token}
					refreshCategoryList={refreshCategoryList}
				/>
			</ButtonToolbar>
		</React.Fragment>
	);
}

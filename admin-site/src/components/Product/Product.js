import React, { useState, useEffect } from "react";
import { Table } from "react-bootstrap";
import { Button, ButtonToolbar } from "react-bootstrap";
import CreateProductModal from "./Create/CreateProductModal";
import EditProductModal from "./Edit/EditProductModal";

export default function Product(props) {
	const [products, setCategories] = useState([]);
	const [createModalShow, setCreateModalShow] = useState(false);
	const [editModalShow, setEditModalShow] = useState(false);

	const [productObj, setProductObj] = useState({});

	const { REACT_APP_BACKEND_API } = process.env;

	const refreshProductList = () => {
		fetch(REACT_APP_BACKEND_API + "product")
			.then((response) => response.json())
			.then((products) => {
				setCategories(products);
			});
	};

	useEffect(() => {
		refreshProductList();
	}, [products]);

	const setCreateModalClose = () => setCreateModalShow(false);
	const setEditModalClose = () => setEditModalShow(false);

	const deleteProduct = (productID, productName) => {
		if (
			window.confirm(`Are you sure you want to delete "${productName}"?`)
		) {
			const requestOptions = {
				method: "DELETE",
				header: { "Content-Type": "application/json" },
			};
			fetch(
				REACT_APP_BACKEND_API + "product/" + productID,
				requestOptions
			);
		}
	};
	return (
		<React.Fragment>
			<Table className="mt-4" striped bordered hover size="sm">
				<thead>
					<tr>
						<th>Product ID</th>
						<th>Product Name</th>
						<th>Description</th>
						<th>Action</th>
					</tr>
				</thead>
				<tbody>
					{products.map((product) => (
						<tr key={product.ProductID}>
							<td>{product.ProductID}</td>
							<td>{product.ProductName}</td>
							<td>{product.Description}</td>
							<td>
								<ButtonToolbar>
									<Button
										className="me-2"
										variant="info"
										onClick={() => {
											setEditModalShow(true);
											setProductObj(product);
										}}
									>
										Edit
									</Button>
									<Button
										className="me-2"
										variant="danger"
										onClick={() =>
											deleteProduct(
												product.ProductID,
												product.ProductName
											)
										}
									>
										Delete
									</Button>
									<EditProductModal
										show={editModalShow}
										onHide={setEditModalClose}
										product={productObj}
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
					Add Product
				</Button>

				<CreateProductModal
					show={createModalShow}
					onHide={setCreateModalClose}
				/>
			</ButtonToolbar>
		</React.Fragment>
	);
}

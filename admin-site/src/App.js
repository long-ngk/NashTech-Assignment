import "./App.css";
import Home from "./components/Home";
import Category from "./components/Category/Category";
import Product from "./components/Product/Product";
import Navigation from "./components/Navigation/Navigation";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import Login from "./components/Login";
import { useEffect } from "react";

function App() {
	const tokenInfo = JSON.parse(sessionStorage.getItem("tokenInfo"));
	useEffect(() => {});
	return (
		<BrowserRouter>
			<div className="container">
				{tokenInfo != null ? (
					<>
						<Navigation />
						<Routes>
							<Route exact path="/" element={<Home />} />
							<Route path="category" element={<Category />} />
							<Route path="product" element={<Product />} />
						</Routes>
					</>
				) : (
					<Routes>
						<Route path="login" element={<Login />} />
						<Route
							path="*"
							element={<Navigate to="/login" replace />}
						/>
					</Routes>
				)}
			</div>
		</BrowserRouter>
	);
}

export default App;

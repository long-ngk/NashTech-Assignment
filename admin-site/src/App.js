import "./App.css";
import Home from "./components/Home";
import Category from "./components/Category/Category";
import Product from "./components/Product/Product";
import Navigation from "./components/Navigation/Navigation";
import { BrowserRouter, Routes, Route } from "react-router-dom";

function App() {
    return (
        <BrowserRouter>
            <div className="container">
                <Navigation />
                <Routes>
                    <Route exact path="/" element={<Home />} />
                    <Route path="category" element={<Category />} />
                    <Route path="product" element={<Product />} />
                    <Route path="*" element={<h1>404 not found</h1>} />
                </Routes>
            </div>
        </BrowserRouter>
    );
}

export default App;

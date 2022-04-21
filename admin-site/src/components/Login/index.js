import { Form, Button } from "react-bootstrap";
import axios from "axios";
import { useState } from "react";
import { useEffect } from "react";

const { REACT_APP_BACKEND_API } = process.env;
export default function Login() {
	const [errorMessage, setErrorMessage] = useState("");
	const handleSubmit = (event) => {
		event.preventDefault();
		setErrorMessage(null);

		const model = {
			Email: event.target.Email.value,
			Password: event.target.Password.value,
		};

		axios
			.post(REACT_APP_BACKEND_API + "auth/login", model)
			.then((response) => {
				sessionStorage.setItem(
					"tokenInfo",
					JSON.stringify(response.data)
				);
				sessionStorage.setItem(
					"email",
					JSON.stringify(event.target.Email.value)
				);
				window.location.href = "/";
			})
			.catch(function (error) {
				if (error.response) {
					setErrorMessage(error.response.data);
				}
			});
	};

	return (
		<Form onSubmit={handleSubmit}>
			<Form.Group className="mb-3" controlId="formBasicEmail">
				<Form.Label>Email</Form.Label>
				<Form.Control
					name="Email"
					required
					type="email"
					placeholder="Enter email"
				/>
			</Form.Group>

			<Form.Group className="mb-3" controlId="formBasicPassword">
				<Form.Label>Password</Form.Label>
				<Form.Control
					name="Password"
					required
					type="password"
					placeholder="Enter password"
				/>
			</Form.Group>
			{errorMessage && (
				<div>
					<Form.Text className="text-danger">
						{errorMessage}
					</Form.Text>
				</div>
			)}
			<Button variant="primary" type="submit">
				Submit
			</Button>
		</Form>
	);
}

import React from "react";
import { withRouter } from "react-router";
import {
  Container,
  Row,
  Col,
  Button,
  Form,
  FormGroup,
  Label,
  Input,
} from "reactstrap";
import { get } from "./httpHelper";
import { UserContext } from "./index";

const user = {
  firstName: "Tuan",
  lastName: "Mai",
};

function concatName(user) {
  return `${user.firstName} ${user.lastName}`;
}

// if function ensure param => result => pure function
// if function cannot ensure param => result => side effect function

class HelloElement extends React.Component {
  state = {
    firstName: "abcasdf",
    email: "123xyz",
    listNumber: [1, 2, 3, 4, 5],
  };
  textInput = React.createRef();

  componentDidMount() {
    console.log("did mount");
    get("/users")
      .then((response) => console.log(response))
      .catch((error) => console.log(error));
  }

  componentWillUnmount() {
    console.log("will unmount");
  }

  handleFormSubmit(e) {
    e.preventDefault();

    // Cach 1
    console.log(e.target.firstName.value);
    console.log(e.target.email.value);
    console.log(e.target.phoneNumber.value);

    // Cach 2
    //   console.log(this.state.firstName);
    //   console.log(this.state.email);

    // Cach 3
    // console.log(this.textInput.current.value)
  }

  handleFieldChange(e, key) {
    console.log(e);
    this.setState({ [key]: e.target.value });
  }

  focusTextInput() {
    // Explicitly focus the text input using the raw DOM API
    // Note: we're accessing "current" to get the DOM node
    this.textInput.current.focus();
    console.log("phone number clicked");
  }

  render() {
    return (
      <UserContext.Consumer>
        {(value) => (
          <Container>
            <h1>Hello world, {value.username}</h1>

            <Form onSubmit={(e) => this.handleFormSubmit(e)}>
              <Row form>
                <Col md={4}>
                  <FormGroup className="mb-2 mr-sm-2">
                    <Label for="exampleEmail" className="mr-sm-2">
                      First name
                    </Label>
                    <Input
                      type="text"
                      name="firstName"
                      id="firstName"
                      placeholder="First name"
                    />
                  </FormGroup>
                </Col>
              </Row>
              <Row form>
                <Col md={4}>
                  <FormGroup className="mb-2 mr-sm-2">
                    <Label for="exampleEmail" className="mr-sm-2">
                      Email
                    </Label>
                    <Input
                      type="email"
                      name="email"
                      id="exampleEmail"
                      placeholder="something@idk.cool"
                    />
                  </FormGroup>
                </Col>
              </Row>
              <Row form>
                <Col md={4}>
                  <FormGroup className="mb-2 mr-sm-2">
                    <Label for="examplePassword" className="mr-sm-2">
                      Phone number
                    </Label>
                    <Input
                      type="number"
                      name="phoneNumber"
                      id="phoneNumber"
                      placeholder="Phone number"
                    />
                  </FormGroup>
                </Col>
              </Row>
              <Button type="submit">Submit</Button>
            </Form>
          </Container>
        )}
      </UserContext.Consumer>
    );
  }
}

export default withRouter(HelloElement);

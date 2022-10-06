import React, { useState, useEffect } from 'react';
import '../App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';

let api_url = '/React';
// App component 
const Edit = () => {
    // Initialize state first
    let [users, setUsers] = useState([]);
    let [isLoaded, setIsLoaded] = useState(false);
    let [err, setErr] = useState(null);
    const [personInfo, setpersonInfo] = useState({
        FirstName: "",
        SecondName: "",
        Age: "",
        Nationality: "",
        EmailAdress: ""
    });
    const [validated, setValidated] = useState();
    const handleSubmit = (event) => {
       const form = event.currentTarget
        if (form.checkValidity() === false) {
          //  event.preventDefault()
           // event.stopPropagation()
        }
        else {
            event.preventDefault();
            personInfo.FirstName = event.target[0].value;
            personInfo.SecondName = event.target[1].value;
            personInfo.Age = event.target[2].value;
            personInfo.Nationality = event.target[3].value;
            personInfo.EmailAdress = event.target[4].value;

            setpersonInfo({ ...personInfo });
           // addPerson(personInfo);
        }
       // setValidated(true)
        // setContactInfo({ FirstName: "", SecondName: "", Age: "", Nationality: "", EmailAdress: ""}); //reset form values after submit 
    };
    useEffect(() => {
        const getUsers = () => {
            fetch(api_url)
                .then(res => {
                    // Unfortunately, fetch doesn't send (404 error)
                    // into the cache itself
                    // You have to send it, as I have done below
                    if (res.status >= 400) {
                        throw new Error("Server responds with error!")
                    }
                    return res.json()
                })
                .then(users => {
                    setUsers(users)
                    setIsLoaded(true)
                },
                    // Note: it's important to handle errors here
                    // instead of a catch() block so that we don't swallow
                    // exceptions from actual bugs in components
                    err => {
                        setErr(err)
                        setIsLoaded(true)
                    })
        };
        getUsers()
    }, [])


    if (err) {
        return <div> {err.message} </div>
    } else if (!isLoaded) {
        return <div> Loading... </div>
    } else {
      console.log(  users[0].tel);
        return (
            <>
                <div className="container">
                <Form noValidate validated={validated} onSubmit={handleSubmit}>
                    <Row>
                        <Col></Col>
                        <Col>
                            <Form.Group as={Row} controlId="validationCustom01">
                                <Form.Label>First name</Form.Label>
                                    <Form.Control
                                        required
                                        type="text"
                                      
                                        placeholder={users[0].first_name}
                                    name="Firstname" />
                                <Form.Control.Feedback>Looks good!</Form.Control.Feedback>
                            </Form.Group>
                            <Form.Group as={Row} controlId="validationCustom02">
                                <Form.Label>Last name</Form.Label>
                                <Form.Control
                                    required
                                        type="text"
                                       
                                        placeholder={users[0].last_name}
                                    name="LastName" />
                                <Form.Control.Feedback>Looks good!</Form.Control.Feedback>
                            </Form.Group>
                            <Form.Group as={Row} controlId="validationCustomAge">
                                <Form.Label>Tel</Form.Label>


                                <Form.Control
                                    type="number"
                                        placeholder={users[0].tel}
                                        name="Tel"
                                       
                                    required />
                                <Form.Control.Feedback type="invalid">
                                        Please provide a valid Tel.
                                </Form.Control.Feedback>

                            </Form.Group>

                            <Form.Group as={Row} controlId="validationCustom03">
                                <Form.Label>Nationality</Form.Label>
                                    <Form.Control type="text"  placeholder={users[0].city.countryId} required name="Nationality" />
                                <Form.Control.Feedback type="invalid">
                                    Please provide a valid Nationality.
                                </Form.Control.Feedback>
                            </Form.Group>
                            <Form.Group as={Row} controlId="validationCustom04">
                                <Form.Label>City</Form.Label>
                                    <Form.Control type="text" placeholder={users[0].city.cityName}  required name="EmailAdress" />
                                <Form.Control.Feedback type="invalid">
                                        Please provide a valid City.
                                </Form.Control.Feedback>

                            </Form.Group>


                            <Button type="submit">Submit form</Button>
                        </Col>
                        <Col></Col>
                    </Row>
                </Form>
            </div>
            </>

        )
    }
}
export default Edit;





import React, { useState, useEffect } from 'react';
import '../App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import data from './Data';
import { useNavigate } from "react-router-dom";
let api_url = '/React/';
let api_url2 = '/React/Delete/';
let api_url3 = '/React/Cityname/';

// App component 
const Delete = () => {
    const navigate = useNavigate();
    // Initialize state first
    let [users, setUsers] = useState([]);
    let [isLoaded, setIsLoaded] = useState(false);
    let [Lanuage, setLanuage] = useState();
    let [cities, setCities] = useState();
    let [err, setErr] = useState(null);
    const params = useParams();
    const [personInfo, setpersonInfo] = useState({
        id: params.id,
        FirstName: "",
        SecondName: "",
        Age: "",
        Nationality: "",
        EmailAdress: ""
    });

  
    const [validated, setValidated] = useState();
    const handleChange = (event) => {
        console.log(event.target.value);
    }
    const handleSubmit = (event) => {
        const form = event.currentTarget
        const ss = "aa"

        
        event.target.value = event.target.placeholder;
        if (form.checkValidity() === false) {
           event.preventDefault()
            event.stopPropagation()
        }
        else {
           
            event.preventDefault();
            personInfo.FirstName = event.target[0].value;
            personInfo.SecondName = event.target[1].value;
            personInfo.Age = event.target[2].value;
            personInfo.Nationality = event.target[3].value;
            personInfo.EmailAdress = event.target[4].value;

            setpersonInfo({ ...personInfo });
            const response =  axios({
                method: 'post',
                url: api_url2,
                data: form,
                headers: {
                    'Content-Type': `multipart/form-data; boundary=${form._boundary}`,
                },
            });
            return navigate("/ListEF/");
           // addPerson(personInfo);
        }
        setValidated(true)
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
    } else if (!isLoaded ) {
        return <div> Loading... </div>
    } else {
  
        
        

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
                                        onChange={handleChange}
                                        value={users[0].first_name}
                                        name="First_name" />
                                <Form.Control.Feedback>Looks good!</Form.Control.Feedback>
                                </Form.Group>
                                <Form.Group as={Row} controlId="validationCustom01">
                                  
                                    <Form.Control
                                        required
                                        type="hidden"
                                        value={users[0].id}
                                      
                                        name="id" />
                                    
                                </Form.Group>
                            <Form.Group as={Row} controlId="validationCustom02">
                                <Form.Label>Last name</Form.Label>
                                <Form.Control
                                    required
                                        type="text"
                                       
                                        value={users[0].last_name}
                                        name="Last_name" />
                                <Form.Control.Feedback>Looks good!</Form.Control.Feedback>
                            </Form.Group>
                            <Form.Group as={Row} controlId="validationCustomAge">
                                <Form.Label>Tel</Form.Label>


                                <Form.Control
                                    type="number"
                                        value={users[0].tel}
                                        name="Tel"
                                       
                                    required />
                                <Form.Control.Feedback type="invalid">
                                        Please provide a valid Tel.
                                </Form.Control.Feedback>

                            </Form.Group>
                            <Form.Group as={Row} controlId="validationCustom04">
                                <Form.Label>City</Form.Label>
                                    <Form.Select type="text" required name="IdCity">
                        
                                        <option value={users[0].city.idCity}>{users[0].city.cityName}</option>
                                      
                                           
                                       
                                    </Form.Select>
                                    
                                        
                                    
                                <Form.Control.Feedback type="invalid">
                                        Please provide a valid City.
                                </Form.Control.Feedback>

                            </Form.Group>
                       


                                <Button type="submit" className="btn btn-danger">Delete</Button>
                        </Col>
                        <Col></Col>
                    </Row>
                </Form>
            </div>
            </>

        )
    }
}
export default Delete;




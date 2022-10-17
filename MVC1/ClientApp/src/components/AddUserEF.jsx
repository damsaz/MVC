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
let api_url = '/React/';
let api_url2 = '/React/Create/';
let api_url3 = '/React/Cityname/';
// App component 
const AddUserEF = () => {
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
            const response = axios({
                method: 'post',
                url: api_url2,
                data: form,
                headers: {
                    'Content-Type': `multipart/form-data; boundary=${form._boundary}`,
                },
            });
            // addPerson(personInfo);
        }
        setValidated(true)
        // setContactInfo({ FirstName: "", SecondName: "", Age: "", Nationality: "", EmailAdress: ""}); //reset form values after submit 
    };
    useEffect(() => {

        axios.get("/React/Cityname/").then((response) => {
            setCities(response.data);

        });
        axios.get("/React/LList/").then((response) => {
            setLanuage(response.data);

        });
    }, [])
    if (!cities || !Lanuage) {
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
                                        placeholder={"First name"}
                                        name="First_name" />
                                    <Form.Control.Feedback>Looks good!</Form.Control.Feedback>
                                </Form.Group>

                                <Form.Group as={Row} controlId="validationCustom02">
                                    <Form.Label>Last name</Form.Label>
                                    <Form.Control
                                        required
                                        type="text"

                                        placeholder={"Last name"}
                                        name="Last_name" />
                                    <Form.Control.Feedback>Looks good!</Form.Control.Feedback>
                                </Form.Group>
                                <Form.Group as={Row} controlId="validationCustomAge">
                                    <Form.Label>Tel</Form.Label>


                                    <Form.Control
                                        type="number"
                                        placeholder={"Tel"}
                                        name="Tel"

                                        required />
                                    <Form.Control.Feedback type="invalid">
                                        Please provide a valid Tel.
                                    </Form.Control.Feedback>

                                </Form.Group>
                                <Form.Group as={Row} controlId="validationCustom04">
                                    <Form.Label>City</Form.Label>
                                    <Form.Select type="text" required name="IdCity">


                                        {cities.map((data) => {
                                            return (
                                                <option value={data.idCity} >{data.cityName}</option>

                                            );

                                        })}


                                    </Form.Select>



                                    <Form.Control.Feedback type="invalid">
                                        Please provide a valid City.
                                    </Form.Control.Feedback>

                                </Form.Group>
                                <Form.Group as={Row} controlId="validationCustom04">
                                    <Form.Label>Lanuage</Form.Label>
                                    <Form.Select type="text" required name="Languages">


                                        {Lanuage.map((data) => {
                                            return (
                                                <option value={data.idLanguage} >{data.name}</option>

                                            );

                                        })}


                                    </Form.Select>



                                    <Form.Control.Feedback type="invalid">
                                        Please provide a valid Lanuage.
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
export default AddUserEF;




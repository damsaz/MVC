import React, { useContext, useState, useEffect } from 'react';

import 'bootstrap/dist/css/bootstrap.min.css';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import "../../App.css";
import UserInfoP from "../UserContext";
import { useNavigate } from "react-router-dom";
//import { useCookies } from 'react-cookie';
export default function Login(props) {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const UserI = useContext(UserInfoP)
    const navigate = useNavigate();
    console.log(UserI.UserName);
    useEffect(() => {
        if (UserI.UserName!=="") {
       
          return navigate("/");
        }
      });
    function performValidation() {
    return username.length > 0 && password.length > 0;
    }
   
    
    //const [cookies, setCookie, removeCookie] = useCookies(['username']);
    
   
    function handleSubmit(event) {
        console.log(UserI.Username)
        UserI.UserName = username;

       // setCookie( "username",username,{ path: '/' });
    
      //     <navigate to="/" />
      
        event.preventDefault();
        if (UserI.UserName !== "") {

            return navigate("/");
        }
    }
    return (
    <div className="w-100 p-4 d-flex justify-content-center pb-4">
    <Form onSubmit={handleSubmit}>
    <Form.Group controlId="username" >
    <Form.Label>Username</Form.Label>
    <Form.Control
    autoFocus
    type="text"
    value={username}
    onChange={e => setUsername(e.target.value)}
    />
    </Form.Group>
    <Form.Group controlId="password">
    <Form.Label>Password</Form.Label>
    <Form.Control
    value={password}
    onChange={e => setPassword(e.target.value)}
    type="password"
    />
    </Form.Group>
    <Button disabled={!performValidation()} type="submit" className="btnconfig" >
    Login
    </Button>
    </Form>
    </div>
    );
    }
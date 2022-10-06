import React, { useState, useEffect } from 'react';
import User from './User';
import Users from './Users';
import '../App.css';
import Table from 'react-bootstrap/Table';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Link } from 'react-router-dom';
import { useParams } from 'react-router-dom';

// App component 
const ListEF = () => {
    // Initialize state first
    const params = useParams();
    console.log(params);
    let api_url = '/React/Details/' + params.id;
    console.log(api_url);
    let [users, setUsers] = useState([]);
    let [isLoaded, setIsLoaded] = useState(false);
    let [err, setErr] = useState(null);
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
        return (
            <>
                <div className="stock-container">
                    <HomePageHeader />
                    <Table striped bordered hover variant="dark">
                        <Header />

                        <tbody>

                            {users.map((data, key) => {
                                return (
                                    <Tbody
                                        key={key}
                                        FirstName={data.first_name}
                                        SecondName={data.last_name}
                                        City={data.city.cityName}
                                        Country={data.city.countryId}
                                        Tel={data.tel}

                                        LinkEdit={"/Edit/" + data.id}
                                       
                                    /> 
                                );

                             

                            })}
                           
                        </tbody>
                    </Table>
                </div>
            </>

        )
    }
}
export default ListEF;


const HomePageHeader = () => {
    return (
        <header className="header">
            <h2>people List</h2>
        </header>
    );
};
const Header = () => {
    return (
        <thead>
            <tr>
                <th>First Name</th>
                <th>Second Name</th>
                <th>City</th>
                <th>Nationality</th>
                <th>Tel</th>
                <th>Edit</th>
                

            </tr>
        </thead>
    );
};
const Tbody = ({ FirstName, SecondName, City, Country, Tel, LinkEdit, LinkDelete }) => {
    if (!FirstName) return <div />;
    return (

        <tr>
            <td>
                {FirstName}
            </td>
            <td>
                {SecondName}
            </td>
            <td>
                {City}
            </td>
            <td>
                {Country}
            </td>
            <td>
                {Tel}
            </td>
            <td>
                <Link to={LinkEdit}>Edit</Link>
            </td>
         

        </tr>

    );
};
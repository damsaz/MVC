import React from 'react';
import User from './User';
import '../App.css';
import Table from 'react-bootstrap/Table';
import 'bootstrap/dist/css/bootstrap.min.css';

const List=({people})=>{
    return(
        <>
<div className="stock-container">
<HomePageHeader />
          <Table striped bordered hover variant="dark">
          <Header />
          <tbody>
            <User people={people} />
            </tbody>
            </Table>
            </div>
        </>
    )
}

export default List;
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
            <th>Age</th>
            <th>Nationality</th>
            <th>EmailAdress</th>
            <th>View</th>
            
      </tr>
      </thead>
    );
  };

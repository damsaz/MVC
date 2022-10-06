import React, { useState } from 'react';
import '../App.css';
import List from './List';
import AddUser from './AddUser';
function UserVeiw() {



  const [Users, updateUser] = useState([]);
  const addPerson = (person) => {
    updateUser(Users => [...Users, person]);
  
    console.log(person);
    console.log(Users);
  };

  return (
 

   
 
      
    <><AddUser addPerson={addPerson}></AddUser><List people={Users}></List></>

  );

}

export default UserVeiw;

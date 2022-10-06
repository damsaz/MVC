

import React from 'react';
import { Link } from 'react-router-dom';

export default function USer({people}) {
  if(!people)
  return(null);
    return(
       
        <>
                
                 
            {people.map((data,key) => {
                return (
                  <Tbody
                    key={key}

                    FirstName={data.FirstName}
                    SecondName={data.SecondName}
                    Age={data.Age}
                    Nationality={data.Nationality}
                    EmailAdress={data.EmailAdress}
                    Linkp={"/Details/"+data.FirstName+"_"+data.SecondName}
                    Data={data} />
                    
                );
                
            })}
          
            
        </>


    );
  }


  const Tbody = ({  FirstName, SecondName, Age , Nationality,EmailAdress,Linkp,Data}) => {
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
              {Age}
            </td>
            <td>
              {Nationality}
            </td>
            <td>
            {EmailAdress}
            </td>
            <td>
            <Link to={Linkp} state={Data}>View</Link>
            </td>
         
          </tr>

    );
  };
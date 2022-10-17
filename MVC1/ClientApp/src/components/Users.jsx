

import React from 'react';
import { Link } from 'react-router-dom';

export default function USer({people}) {
  if(!people)
  return(null);
    return(
       
        <>
                
                 
            {people.table.map((data, key) => {
                return (
                  <Tbody
                    
                        key={key}
                    FirstName={data.first_name}
                    SecondName={data.last_name}
                        City={data.city.cityName}
                        Country={data.city.countryId}
                        Tel={data.tel}
                    
                    Linkp={"/DetailsEF/"+data.id}
                     />
                    
                );
                
            })}
          
            
        </>


    );
  }


const Tbody = ({ FirstName, SecondName, City, Country,Tel,Linkp}) => {
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
            <Link to={Linkp}>View</Link>
            </td>
         
          </tr>

    );
  };
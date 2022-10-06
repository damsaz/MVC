

import Table from 'react-bootstrap/Table';
import 'bootstrap/dist/css/bootstrap.min.css';

//import {useParams} from 'react-router-dom';
import { useLocation } from 'react-router-dom';
const Details = () => {
 // const params = useParams();
  const location = useLocation();
  const data2 = location.state;
//console.log(data2.Age);
  
return (
  
<div className="stock-container">

          <Table striped bordered hover variant="dark">
          <Header  />
          <tbody>
          <tr>
          <td>
              {data2.FirstName}
            </td>
            <td>
              {data2.SecondName}
            </td>
            <td>
              {data2.Age}
            </td>
            <td>
              {data2.Nationality}
            </td>
            <td>
            {data2.EmailAdress}
            </td>
          </tr>
            </tbody>
            </Table>
            </div>
      

  );
};
export default Details;
const Header = () => {
  return (
      <thead>
    <tr>
          <th>First Name</th>
          <th>Second Name</th>
          <th>Age</th>
          <th>Nationality</th>
          <th>EmailAdress</th>
        
          
    </tr>
    </thead>
  );
};

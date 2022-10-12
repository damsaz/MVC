import { useEffect, useState } from "react";
import axios from 'axios';
var data;


 function Data(Ccode) {

    const [cities, setCities] = useState([]);
 

    useEffect(() => {
        axios.get("/React/CountryList/").then((response) => {
            data=response.data;
        });
    }, []);



     return (data )
} 
export default data;
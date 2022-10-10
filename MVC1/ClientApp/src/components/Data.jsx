import { useEffect, useState } from "react";
let api_url = '/React/Cityname/';
export type City = { cityId: number, name: string, countryId: number }




 function Data() {

    const [cities, setCities] = useState([]);
 

    useEffect(() => {
         function getData() {
            const responce = fetch(
                api_url,
                { method: "GET" }
            );
            //console.log(responce)
            const data =  responce.json()
            //get cities
            const cities = data.cities.$values
            setCities(cities)

        }
        getData();
    }, []);



    return { cities }
} 
export default Data
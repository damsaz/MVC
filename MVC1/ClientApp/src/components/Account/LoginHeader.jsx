import {  useContext } from "react";



import UserInfoP from "../UserContext";
import { Link } from 'react-router-dom';
function LoginHeader() {
  const UserI = useContext(UserInfoP)
 // const [cookies, setCookie, removeCookie] = useCookies(['cookie-name']);
  
  function Logout() {
   // removeCookie("username");
   UserI.username="";
    window.location.reload();
    }
if(UserI.UserName!=="")
  return (
 

   
<ul className="navbar-nav">



    <li className="nav-item">

        <a className=" nav-link text-white" >Welcome {UserI.UserName}</a>
    </li>
    <li className="nav-item">
        <a className="btn text-white" id="login"  onClick={Logout}>Logout</a>
    </li>

</ul>

  

  );
  else
  return (
 

   
    <ul className="navbar-nav">
    
    
    
        <li className="nav-item">
        <Link to="/Account/Register" className="nav-link text-white">Register</Link>
       
        </li>
        <li className="nav-item">
        <Link to="/Account/Login" className="nav-link text-white">Login</Link>
           
        </li>
    
    </ul>
    
      
    
      );

}

export default LoginHeader;

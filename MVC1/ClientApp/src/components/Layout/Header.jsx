
import LoginHeader from "../Account/LoginHeader"
import React, { useContext } from 'react';
import { Link } from 'react-router-dom';
import UserInfoP from "../UserContext";
function Header() {
    const UserI = useContext(UserInfoP)
    if(UserI.UserName!=="")
    return(
<header>
        <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-black border-bottom box-shadow mb-3 edit">
            <div className="container-fluid">
              
                
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                    <ul className="navbar-nav flex-grow-1">
                        <li className="nav-item">
                            <Link to="/" className="nav-link text-white">Home</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="AddUser" className="nav-link text-white">AddUser</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="List" className="nav-link text-white">User list</Link>
                            </li>
                            <li className="nav-item">
                                <Link to="ListEF" className="nav-link text-white">User list EF</Link>
                            </li>
                        <LoginHeader />
                    </ul>
                </div>
            </div>
        </nav>
    </header>
    )
    else
    return(
        <header>
        <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-black border-bottom box-shadow mb-3 edit">
            <div className="container-fluid">
             
                
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                    <ul className="navbar-nav flex-grow-1">
                        <LoginHeader />
                    </ul>
                </div>
            </div>
        </nav>
    </header>


    );
  
}
export default Header;
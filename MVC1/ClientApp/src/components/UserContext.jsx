import { createContext } from "react";
import UsersList from './UsersList';
export const UserInfo = {
   
        UserName: '',
        Password: '',
    }
    export const Users = UsersList;
    const UserInfoP = createContext('UserInfo')
  
    export default UserInfoP
    
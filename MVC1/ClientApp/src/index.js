import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import { BrowserRouter } from 'react-router-dom';
import UserContext,{UserInfo} from './components/UserContext';
import App from './App';
import * as serviceWorkerRegistration from './serviceWorkerRegistration';
import reportWebVitals from './reportWebVitals';



const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  
    <BrowserRouter >
    <UserContext.Provider value={UserInfo} >
    
  
      <App />
     
      </UserContext.Provider>
    </BrowserRouter>

);


serviceWorkerRegistration.unregister();


reportWebVitals();

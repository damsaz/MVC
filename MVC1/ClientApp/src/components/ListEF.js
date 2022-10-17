import React, { useState, useEffect, useReducer } from 'react';
import User from './User';
import Users from './Users';
import '../App.css';
import Table from 'react-bootstrap/Table';
import 'bootstrap/dist/css/bootstrap.min.css';
import { ascend, descend, prop, sort } from "ramda";
import data from './Data';


let api_url = '/React';
// App component 
const ListEF = () => {
    // Initialize state first
    let [users, setUsers] = useState([]);
    
    let [isLoaded, setIsLoaded] = useState(false);
    let [err, setErr] = useState(null);
   
    useEffect(() => {
        const getUsers = () => {
            fetch(api_url)
                .then(res => {
                    // Unfortunately, fetch doesn't send (404 error)
                    // into the cache itself
                    // You have to send it, as I have done below
                    if (res.status >= 400) {
                        throw new Error("Server responds with error!")
                    }
                    return res.json()
                })
                .then(users => {
                    setUsers(users)
                    setIsLoaded(true)
                },
                    // Note: it's important to handle errors here
                    // instead of a catch() block so that we don't swallow
                    // exceptions from actual bugs in components
                    err => {
                        setErr(err)
                        setIsLoaded(true)
                    })
        };
        getUsers()
    }, [])

    const [sorted, sortDispatch] = useSortedTable(users, "first_name");
    if (sorted.table.length == 0)
        sorted.table=users
    if (err) {
        return <div> {err.message} </div>
    } else if (!isLoaded || !sorted) {
        return <div> Loading... </div>
    } else {
        console.log(sorted);
        return (
            <>
                
      <div className="stock-container">

                    <HomePageHeader  />
                <Table striped bordered hover variant="dark">
                     
                        <thead>
                            <tr>
                                
                                <SortTh
                                    data={sorted}
                                    sortKey="first_name"
                                    label="First Name"
                                    dispatch={sortDispatch}
                                />
                                <th>Second Name</th>
                                <th>City</th>
                                <th>Nationality</th>
                                <th>Tel</th>
                                <th>View</th>

                            </tr>
                        </thead>
                      
                        <tbody>
                            <Users people={sorted} />
                        </tbody>
                    </Table>
                   
                  </div>
              </>
       
        )
    }
}
export default ListEF;


const HomePageHeader = () => {
    return (
        <header className="header">
            <h2>people List</h2>
        </header>
    );
};

function sortedTableReducer(oldState, newState) {
    const { isDescending, key, table } = { ...oldState, ...newState };
    const direction = (isDescending) ? descend : ascend;
    const sortFunc = sort(direction(prop(key)));
    return { isDescending, key, table: sortFunc(table) };
}

function useSortedTable(table, key, isDescending = true) {
    const initialState = { isDescending, key, table };
    const [state, dispatch] = useReducer(sortedTableReducer, initialState);
    useEffect(
        function callDispatchOnceToTriggerInitialSort() {
            dispatch({});
        },
        []
    );
    return [state, dispatch];
}


function SortTh({ label, sortKey, data, dispatch }) {
    function toggleDirAndSetKey() {
        dispatch({ key: sortKey });
        dispatch({ isDescending: !data.isDescending });
    }
    function setKeyOrToggleDir() {
        if (data.key === sortKey) {
            dispatch({ isDescending: !data.isDescending });
        } else {
            dispatch({ key: sortKey });
        }
    }
    return (
        <th>
            <a onClick={setKeyOrToggleDir}>
                {label}
            </a>
            <button
                onClick={toggleDirAndSetKey}
                style={{ opacity: (data.key === sortKey) ? "1" : "0" }}
            >
                {(data.isDescending)
                    ? (
                        <span role="img" aria-label="descending">
                            ↓
                        </span>
                    ) : (
                        <span role="img" aria-label="ascending">
                            ↑
                        </span>
                    )
                }
            </button>
        </th>
    );
}

const { format: dateFormat } = new Intl.DateTimeFormat(
    "en-US",
    { day: "2-digit", month: "short", year: "numeric" }
);

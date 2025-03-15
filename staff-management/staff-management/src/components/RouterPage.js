import React from "react";
import {BrowserRouter as Router,Routes,Route} from 'react-router-dom';
import Login from './Login';
import Registration from './Registration';
import Dashboard from './users/Dashboard';
import Payroll from './users/Payroll';
import Profile from './users/Profile';
import AdminDashboard from './admin/AdminDashboard';
import AdminPayroll from './admin/AdminPayroll';
import Department from './admin/Department';
import Position from './admin/Position';
import StaffList from './admin/StaffList';



 function RouterPage(){
    return(
        <Router>
            <Routes>
                <Route path='/' element={<Login/>}  /> 
                <Route path='/registration' element={<Registration/>}  />
                <Route path='/dashboard' element={<Dashboard/>}  />
                <Route path='/mysalary' element={<Payroll/>}  />
                <Route path='/profile' element={<Profile/>}  />
               
                <Route path='/admindashboard' element={<AdminDashboard/>}  />
                <Route path='/adminpayroll' element={<AdminPayroll/>}  />
                <Route path='/department' element={<Department/>}  />
                <Route path='/position' element={<Position/>}  />
                <Route path='/staff' element={<StaffList/>}  />

            </Routes>
        </Router>
    )
}
export default RouterPage;

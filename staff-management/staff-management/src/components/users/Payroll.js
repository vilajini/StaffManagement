import React, { useEffect, useState } from "react";
import axios from 'axios';
export default function Payroll(){
   const[data,setData]=useState([]);

   useEffect(()=>{
    getData();
   }, []);

   const getData = () =>{
        Email: localStorage.getItem("username")
   };
}
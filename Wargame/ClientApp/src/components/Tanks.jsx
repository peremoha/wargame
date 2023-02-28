import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

function Tanks(){
    const [tanks, setTanks] = useState([]);

    useEffect(()=>{
        getAllTanks();
    }, []);

    const navigate = useNavigate();

    function handleOnCreate(){
        navigate('/menuTank/createTank');
    }

    function handleOnUpdate(tankId){
        navigate(`/menuTank/updateTank/${tankId}`);
    }

    async function getAllTanks(){
        const response = await fetch('tanks/getTanks');
        const data = await response.json();
        setTanks(data);
    }

    async function deleteTank(id){
        await fetch(`tanks/deleteTanks/${id}`, {
            method: "DELETE"
        });
        await getAllTanks();
    }

    return(
        <div>
            <table>
                <tbody>
                    {tanks.map(tank =>
                        <tr key={tank.id}>
                            <td>{tank.name}</td>
                            <td>{tank.price}</td>
                            <td>{tank.strenght}</td>
                            <td>{tank.size}</td>
                            <td>{tank.optics}</td>
                            <td>{tank.speed}</td>
                            <td>{tank.roadspeed}</td>
                            <td>{tank.stealth}</td>
                            <td>{tank.fuel}</td>
                            <td>{tank.range}</td>
                            <td>{tank.isprototype}</td>
                            <td>{tank.year}</td>
                            <td>{tank.frontarmor}</td>
                            <td>{tank.backarmor}</td>
                            <td>{tank.sidearmor}</td>
                            <td>{tank.upperarmor}</td>
                            <td>{tank.country.name}</td>
                            <td>{tank.movement.name}</td>
                            <td>{tank.role.name}</td>
                            {tank.armaments.map(armament =>
                                <td key={armament.id}>{armament.name}</td>)}
                            {tank.types.map(type =>
                                <td key={type.id}>{type.name}</td>)}
                            <td><img src={`data:image/png;base64,${tank.image}`}/></td>
                            <td><button onClick={()=>deleteTank(tank.id)}>Delete</button></td>
                            <td><button onClick={()=>handleOnUpdate(tank.id)}>Update</button></td>
                        </tr>)}
                </tbody>
            </table>
            <button onClick={handleOnCreate}>Create</button>
        </div>
    )
}

export default Tanks;
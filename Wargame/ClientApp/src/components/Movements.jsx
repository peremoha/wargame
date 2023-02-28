import React, { useEffect, useState } from "react";

function Movements(){
    const [movements, setMovements] = useState([]);
    const [movement, setMovement] = useState("");
    const [showUpdateView, setShowUpdateView] = useState(false);
    const [currentMovementId, setCurrentMovementId] = useState("");
    const [updatedMovement, setUpdatedMovement] = useState("");

    useEffect(()=>{
        getAllMovements();
    },[])

    function handleSetMovement(e){
        setMovement(e.target.value);
    }

    function handleOnUpdate(currentMovementId){
        setShowUpdateView(true);
        setCurrentMovementId(currentMovementId.id);
        setUpdatedMovement(currentMovementId.name)
    }

    function handleUpdatedMovement(e){
        setUpdatedMovement(e.target.value);
    }

    async function getAllMovements(){
        const response = await fetch("movements/GetMovements");
        const data = await response.json();
        setMovements(data);
    }

    async function createMovement(){
        await fetch("movements/CreateMovements",
        {
            method: "POST",
            headers: {'Content-Type' : 'application/json'},
            body: JSON.stringify({name: movement})
        });
        setMovement("");
        getAllMovements();
    }

    async function deleteMovement(id){
        await fetch(`movements/DeleteMovements/${id}`,{
            method: "DELETE"
        })
        getAllMovements();
    }

    async function updateMovement(id){
        await fetch(`movements/UpdateMovements/${id}`,{
            method: "PUT",
            headers: {'Content-Type' : 'application/json'},
            body: JSON.stringify({name: updatedMovement})
        });
        setShowUpdateView(false);
        setUpdatedMovement("");
        getAllMovements();
    }

    return(
        <div>
            <table>
                <tbody>
                    {movements.map(movementItem =>
                        <tr key={movementItem.id}>
                            <td>{movementItem.name}</td>
                            <td><button onClick={()=>deleteMovement(movementItem.id)}>Delete</button></td>
                            <td><button onClick={()=>handleOnUpdate(movementItem)}>Update</button></td>
                            {showUpdateView && currentMovementId === movementItem.id &&
                            <>
                                <td><input type='text' value={updatedMovement} onChange={handleUpdatedMovement} placeholder='new name...'/></td>
                                <td><button onClick={()=>updateMovement(movementItem.id)}>Confirm</button></td>
                            </>}
                        </tr>
                    )}
                </tbody>
            </table>
            <input type='text' value={movement} onChange={handleSetMovement} placeholder='name'/>
            <button onClick={createMovement}>Create</button>
        </div>
    )
}

export default Movements;
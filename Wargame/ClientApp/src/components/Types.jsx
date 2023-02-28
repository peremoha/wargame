import React, { useEffect, useState } from 'react';

function Types(){
    const [types, setTypes] = useState([]);
    const [value, setValue] = useState("");
    const [showInput, setShowInput] = useState(false);
    const [newValue, setNewValue] = useState("");
    const [currentUpdateId, setCurrentUpdateId] = useState("");

    useEffect(()=>{
        getAllTypes();
    },[])

    function handleSetTypes(types){
        setTypes(types);
    }

    function handleSetValue(e){
        setValue(e.target.value);
    }

    async function getAllTypes(){
        const response = await fetch('types/getTypes');

        const data = await response.json();


        handleSetTypes(data);
    }

    async function CreateType(){
            await fetch("types/addTypes",{
                method: "POST",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    name: value
                })
            })
            await getAllTypes();
            setValue("");
        }
    
    async function DeleteType(id){
        await fetch(`types/deleteTypes/${id}`, {method: "DELETE"})
        await getAllTypes();
    }




    async function UpdateType(id){
        await fetch(`types/updateTypes/${id}`, {method: "PUT",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            name: newValue
        })})
        await getAllTypes();
        setValue("");
        setShowInput(false);
    }

    function handleOnUpdate(id){
        setShowInput(true);
        setCurrentUpdateId(id.id);
        setNewValue(id.name);
    }
    

    return(
        <div>
        <table>
            <tbody>
            {types.map(type=>
                <tr key={type.id}>
                    <td>{type.name}</td>
                    <td><button onClick={()=>DeleteType(type.id)}>Delete</button></td>
                    <td><button onClick={()=> handleOnUpdate(type)}>Update</button></td>
                    {showInput && currentUpdateId===type.id && <><td><input type='text' value={newValue} onChange={(e) => setNewValue(e.target.value)} placeholder='new value'/></td>
                    <td><button onClick={()=>UpdateType(type.id)}>Confirm</button></td></>}
                </tr>)}
                </tbody>
        </table>

        <input type='text' value={value} onChange={handleSetValue} placeholder='name'/>

        <button onClick={CreateType}>Create</button>


        </div>
    )
}

export default Types;
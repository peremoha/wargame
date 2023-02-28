import React, { useEffect, useState } from "react";

function Properties(){
    const [properties, setProperties] = useState([]);
    const [newProperty, setNewProperty] = useState("");
    const [showView, setShowView] = useState(false);
    const [currentProperty, setcurrentProperty] = useState("");
    const [updatedProperty, setUpdateProperty] = useState("");

    useEffect(()=>{
        getAllProperties();
    },[])

    function handleSetProperties(properties){
        setProperties(properties);
    }

    function handleSetNewProperty(e){
        setNewProperty(e.target.value);
    }

    function handleOnUpdate(currentProperty){
        setShowView(true);
        setcurrentProperty(currentProperty.id);
        setUpdateProperty(currentProperty.name);
    }

    function handleSetUpdateProperty(e){
        setUpdateProperty(e.target.value);
    }

    async function getAllProperties(){
        const response = await fetch("properties/GetProperties");
        const data = await response.json();
        handleSetProperties(data);
    }

    async function createProperty(){
        await fetch("properties/CreateProperties", {
            method: "POST",
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({
                name: newProperty
            })
        });
        setNewProperty("");
        getAllProperties();
    }

    async function deleteProperty(id){
        await fetch(`properties/DeleteProperties/${id}`,{
            method: "DELETE"
        });
        getAllProperties();
    }

    async function updateProperty(id){
        await fetch(`properties/UpdateProperties/${id}`,{
            method: "PUT",
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({name: updatedProperty})
        })
        setShowView(false);
        setUpdateProperty("");
        getAllProperties();
    }

    return(
        <div>
        <table>
            <tbody>
                {properties.map(property=>
                    <tr key={property.id}>
                        <td>{property.name}</td>
                        <td><button onClick={()=>deleteProperty(property.id)}>Delete</button></td>
                        <td><button onClick={()=>handleOnUpdate(property)}>Update</button></td>
                        {showView && currentProperty===property.id && <>
                        <td><input value={updatedProperty} onChange={handleSetUpdateProperty} placeholder="new name..."/></td>
                        <td><button onClick={()=>updateProperty(property.id)}>Confirm</button></td></>}
                    </tr>)}
            </tbody>
        </table>
        <input value={newProperty} onChange={handleSetNewProperty} placeholder="name..."/>
        <button onClick={createProperty}>Create</button>
        </div>
    )
}

export default Properties;
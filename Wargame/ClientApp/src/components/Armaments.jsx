import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getAll, deleteItem, PROPERTIES_URLS, ARMAMENTS_URLS } from './../helper';

function Armaments() {
    const [armaments, setArmaments] = useState([]);
    const [properties, setProperties] = useState([]);

    const navigate = useNavigate();

    useEffect(() => {
        (async () => {
            const armaments = await getAll(ARMAMENTS_URLS.GET_ARMAMENTS);
            const properties = await getAll(PROPERTIES_URLS.GET_PROPERTIES)
            setArmaments(armaments);
            setProperties(properties);
        })();
    }, [])

    function handleOnCreate() {
        navigate('/menuArmament/createArmament');
    }

    function handleOnUpdate(armament) {
        navigate(`/menuArmament/updateArmament/${armament}`);
    }

    async function deleteArmament(id) {
        await deleteItem(ARMAMENTS_URLS.DELETE_ARMAMENTS, id);
        setArmaments(await getAll(ARMAMENTS_URLS.GET_ARMAMENTS));
    }


    return (
        <div>
            <table>
                <tbody>
                    {armaments.map(armament =>
                        <tr key={armament.id}>
                            <td>{armament.name}</td>
                            <td>{armament.caliber}</td>
                            <td>{armament.range}</td>
                            <td>{armament.rangeAircraft}</td>
                            <td>{armament.rangeHelicopter}</td>
                            <td>{armament.accuracy}</td>
                            <td>{armament.stability}</td>
                            <td>{armament.armorPenetration}</td>
                            <td>{armament.landmine}</td>
                            <td>{armament.suppression}</td>
                            <td>{armament.rateOfFire}</td>
                            {armament.properties.map(prop => <td key={prop.id}>{prop.name}</td>)}
                            <td><img alt={armament.image} width={"250px"} src={`data:image/jpeg;base64,${armament.image}`} /></td>
                            <td><button onClick={() => deleteArmament(armament.id)}>Delete</button></td>
                            <td><button onClick={() => handleOnUpdate(armament.id)}>Update</button></td>
                        </tr>)}
                </tbody>
            </table>
            <button onClick={handleOnCreate}>Create</button>
        </div>
    )
}

export default Armaments;
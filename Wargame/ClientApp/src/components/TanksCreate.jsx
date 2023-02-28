import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getAll, ARMAMENTS_URLS, TYPES_URLS } from "../helper";

function TanksCreate(){
    const [name, setName] = useState('');
    const [price, setPrice] = useState('');
    const [strenght, setStrenght] = useState('');
    const [size, setSize] = useState('');
    const [optics, setOptics] = useState('');
    const [speed, setSpeed] = useState('');
    const [roadspeed, setRoadspeed] = useState('');
    const [stealth, setStealth] = useState('');
    const [fuel, setFuel] = useState('');
    const [range, setRange] = useState('');
    const [isprototype, setIsprototype] = useState(false);
    const [year, setYear] = useState('');
    const [frontarmor, setFrontarmor] = useState('');
    const [backarmor, setBackarmor] = useState('');
    const [sidearmor, setSidearmor] = useState('');
    const [upperarmor, setUpperarmor] = useState('');
    const [countryId, setCountryId] = useState('');
    const [movementId, setMovementId] = useState('');
    const [roleId, setRoleId] = useState('');
    const [armamentsId, setArmamentsId] = useState([]);
    const [typesId, setTypesId] = useState([]);
    const [image, setImage] = useState(null);

    const [currentImage, setCurrentImage] = useState('');
    const [armaments, setArmaments] = useState([]);
    const [types, setTypes] = useState([]);    

    const navigate = useNavigate();

    const {tankId} = useParams();

    useEffect(()=>{
        (async () => {
            const armaments = await getAll(ARMAMENTS_URLS.GET_ARMAMENTS);
            setArmaments(armaments);
            const types = await getAll(TYPES_URLS.GET_TYPES);
            setTypes(types);
        })();
        if(tankId){
            getTank();
        }
    }, [tankId])

    function handleSetName(e) {setName(e.target.value)}
    function handleSetPrice(e) {setPrice(e.target.value)}
    function handleSetStrenght(e) {setStrenght(e.target.value)}
    function handleSetSize(e) {setSize(e.target.value)}
    function handleSetOptics(e) {setOptics(e.target.value)}
    function handleSetSpeed(e) {setSpeed(e.target.value)}
    function handleSetRoadspeed(e) {setRoadspeed(e.target.value)}
    function handleSetStealth(e) {setStealth(e.target.value)}
    function handleSetFuel(e) {setFuel(e.target.value)}
    function handleSetRange(e) {setRange(e.target.value)}
    function handleSetIsprototype(e) {setIsprototype(e.target.checked)}
    function handleSetYear(e) {setYear(e.target.value)}
    function handleSetFrontarmor(e) {setFrontarmor(e.target.value)}
    function handleSetBackarmor(e) {setBackarmor(e.target.value)}
    function handleSetSidearmor(e) {setSidearmor(e.target.value)}
    function handleSetUpperarmor(e) {setUpperarmor(e.target.value)}
    function handleSetCountryId(e) {setCountryId(e.target.value)}
    function handleSetMovementId(e) {setMovementId(e.target.value)}
    function handleSetRoleId(e) {setRoleId(e.target.value)}
    function handleSetImage(e) {setImage(e.target.files[0])}
    console.log(isprototype);
    function handleSetArmamentsId(e){
        if(armamentsId.includes(e.target.id)){
            setArmamentsId(old => [...old.filter(item => item !== e.target.id)]);
        }
        else{
            setArmamentsId(old => [...old, e.target.id]);
        }
    }

    function handleSetTypesId(e){
        if(typesId.includes(e.target.id)){
            setTypesId(old => [...old.filter(item => item !== e.target.id)]);
        }
        else{
            setTypesId(old => [...old, e.target.id]);
        }
    }

    function handleOnClick(){
        tankId ? updateTank() : createTank();
    }

    async function createTank(){
        const reader = new FileReader();

        reader.onloadend = async () => {
            let imageString = reader.result
                .replace('base:', '')
                .replace(/^.*,/, '');

            await fetch('tanks/createTanks', {
                method: "POST",
                headers: {'Content-Type': 'application/json'},
                body: JSON.stringify({
                    name: name,
                    price: price,
                    strenght: strenght,
                    size: size,
                    optics: optics,
                    speed: speed,
                    roadspeed: roadspeed,
                    stealth: stealth,
                    fuel: fuel,
                    range: range,
                    isprototype: isprototype,
                    year: year,
                    frontarmor: frontarmor,
                    backarmor: backarmor,
                    sidearmor: sidearmor,
                    upperarmor: upperarmor,
                    countryId: countryId,
                    movementId: movementId,
                    roleId: roleId,
                    armamentsId: armamentsId,
                    typesId: typesId,
                    image: imageString
                })
            });    
            navigate('/menuTank');
        }
        reader.readAsDataURL(image);
    }

    async function getTank(){
        const response = await fetch(`tanks/getTanks/${tankId}`);
        const data = await response.json();
        setName(data.name);
        setPrice(data.price);
        setStrenght(data.strenght);
        setSize(data.size);
        setOptics(data.optics);
        setSpeed(data.speed);
        setRoadspeed(data.roadspeed);
        setStealth(data.stealth);
        setFuel(data.fuel);
        setRange(data.range);
        setIsprototype(data.isprototype);
        setYear(data.year);
        setFrontarmor(data.frontarmor);
        setBackarmor(data.backarmor);
        setSidearmor(data.sidearmor);
        setUpperarmor(data.upperarmor);
        setCurrentImage(data.image);
    }

    async function updateTankHelper(image){
        await fetch(`tanks/updateTanks/${tankId}`, {
            method: "PUT",
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({
                name: name,
                price: price,
                strenght: strenght,
                size: size,
                optics: optics,
                speed: speed,
                roadspeed: roadspeed,
                stealth: stealth,
                fuel: fuel,
                range: range,
                isprototype: isprototype,
                year: year,
                frontarmor: frontarmor,
                backarmor: backarmor,
                sidearmor: sidearmor,
                upperarmor: upperarmor,
                countryId: countryId,
                movementId: movementId,
                roleId: roleId,
                image: image
            })
        })
        navigate('/menuTank');
    }

    function updateTank(){
        const reader = new FileReader();

        reader.onloadend = () => {
            let imageString = reader.result
                .replace('data:', '')
                .replace(/^.*,/, '');

            updateTankHelper(imageString);
        }

        if(image) reader.readAsDataURL(image);
        else updateTankHelper(currentImage);
    } 

    return(
        <>
            <input type='text' placeholder="Name (word)" value={name} onChange={handleSetName}/>
            <input type='text' placeholder="Price (number)" value={price} onChange={handleSetPrice}/>
            <input type='text' placeholder="Strenght (number)" value={strenght} onChange={handleSetStrenght}/>
            <input type='text' placeholder="Size (word)" value={size} onChange={handleSetSize}/>
            <input type='text' placeholder="Optics (word)" value={optics} onChange={handleSetOptics}/>
            <input type='text' placeholder="Speed (number)" value={speed} onChange={handleSetSpeed}/>
            <input type='text' placeholder="RoadSpeed (number)" value={roadspeed} onChange={handleSetRoadspeed}/>
            <input type='text' placeholder="Stealth (word)" value={stealth} onChange={handleSetStealth}/>
            <input type='text' placeholder="Fuel (number)" value={fuel} onChange={handleSetFuel}/>
            <input type='text' placeholder="Range (number)" value={range} onChange={handleSetRange}/>
            <label>
            <input type='checkbox' name="Prototype" value={isprototype} onChange={handleSetIsprototype}/>
            Prototype
            </label>
            <input type='text' placeholder="Year (number)" value={year} onChange={handleSetYear}/>
            <input type='text' placeholder="FrontArmor (number)" value={frontarmor} onChange={handleSetFrontarmor}/>
            <input type='text' placeholder="BackArmor (number)" value={backarmor} onChange={handleSetBackarmor}/>
            <input type='text' placeholder="SideArmor (number)" value={sidearmor} onChange={handleSetSidearmor}/>
            <input type='text' placeholder="UpperArmor (number)" value={upperarmor} onChange={handleSetUpperarmor}/>
            <input type='text' placeholder="CountryId (number)" value={countryId} onChange={handleSetCountryId}/>
            <input type='text' placeholder="MovementId (number)" value={movementId} onChange={handleSetMovementId}/>
            <input type='text' placeholder="RoleId (number)" value={roleId} onChange={handleSetRoleId}/>
            <div style={{display: 'flex', flexDirection:"column"}}>
            {armaments.map(armament => 
                <label key={armament.id}>
                <input type="checkbox" id={armament.id} onChange={handleSetArmamentsId}/>
                {armament.name}
                </label>)}
            </div>
            <div style={{display: 'flex', flexDirection:"column"}}>
            {types.map(type =>
                <label key={type.id}>
                    <input type="checkbox" id={type.id} onChange={handleSetTypesId}/>
                    {type.name}
                </label>)}
            </div>
            <input type='file' onChange={handleSetImage}/>
            {!image && <img alt={name} src={`data:image/png;base64,${currentImage}`}/>}
            <button onClick={handleOnClick}>Confirm</button>
        </>
    )
}

export default TanksCreate;
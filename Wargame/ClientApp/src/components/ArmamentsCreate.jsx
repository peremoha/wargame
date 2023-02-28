import React, { Fragment, useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getAll, PROPERTIES_URLS } from "../helper";

function ArmamentsCreate() {
    const [armamentName, setArmamentsName] = useState("");
    const [armamentCaliber, setArmamentsCaliber] = useState("");
    const [armamentRange, setArmamentsRange] = useState("");
    const [armamentRangeAircraft, setArmamentsRangeAircraft] = useState("");
    const [armamentRangeHelicopter, setArmamentsRangeHelicopter] = useState("");
    const [armamentAccuracy, setArmamentsAccuracy] = useState("");
    const [armamentStability, setArmamentsStability] = useState("");
    const [armamentArmorPenetration, setArmamentsArmorPenetration] = useState("");
    const [armamentLandmine, setArmamentsLandmine] = useState("");
    const [armamentSuppresion, setArmamentsSuppresion] = useState("");
    const [armamentRateOfFire, setArmamentsRateOfFire] = useState("");
    const [armamentImage, setArmamentsImage] = useState(null);
    const [armamentProp, setArmamentsProp] = useState([]);

    const [armamentCurrentImage, setArmamentsCurrentImage] = useState(null);
    const [properties, setProperties] = useState([]);

    const { armamentId } = useParams();

    const navigate = useNavigate();

    async function getArmament() {
        const response = await fetch(`armaments/GetArmaments/${armamentId}`);
        const data = await response.json();
        setArmamentsName(data.name);
        setArmamentsCaliber(data.caliber);
        setArmamentsRange(data.range);
        setArmamentsRangeAircraft(data.rangeAircraft);
        setArmamentsRangeHelicopter(data.rangeHelicopter);
        setArmamentsAccuracy(data.accuracy);
        setArmamentsStability(data.stability);
        setArmamentsArmorPenetration(data.armorPenetration);
        setArmamentsLandmine(data.landmine);
        setArmamentsSuppresion(data.suppression);
        setArmamentsRateOfFire(data.rateOfFire);
        setArmamentsCurrentImage(data.image);
    }

    useEffect(() => {
        (async () => {
            const properties = await getAll(PROPERTIES_URLS.GET_PROPERTIES);
            setProperties(properties);
        })();
        if (armamentId) {
            getArmament();
        }
    }, [armamentId])

    function handleSetArmamentsName(e) { setArmamentsName(e.target.value) }
    function handleSetArmamentsCaliber(e) { setArmamentsCaliber(e.target.value) }
    function handleSetArmamentsRange(e) { setArmamentsRange(e.target.value) }
    function handleSetArmamentsRangeAircraft(e) { setArmamentsRangeAircraft(e.target.value) }
    function handleSetArmamentsRangeHelicopter(e) { setArmamentsRangeHelicopter(e.target.value) }
    function handleSetArmamentsAccuracy(e) { setArmamentsAccuracy(e.target.value) }
    function handleSetArmamentsStability(e) { setArmamentsStability(e.target.value) }
    function handleSetArmamentsArmorPenetration(e) { setArmamentsArmorPenetration(e.target.value) }
    function handleSetArmamentsLandmine(e) { setArmamentsLandmine(e.target.value) }
    function handleSetArmamentsSuppresion(e) { setArmamentsSuppresion(e.target.value) }
    function handleSetArmamentsRateOfFire(e) { setArmamentsRateOfFire(e.target.value) }
    function handleSetArmamentsImage(e) { setArmamentsImage(e.target.files[0]) }

    function handleSetArmamentsProp(e) {
        if(armamentProp.includes(e.target.id)){
            setArmamentsProp((old) => [...old.filter(item => item !== e.target.id)])
        }
        else{
            setArmamentsProp((old) => [...old, e.target.id])
        }
    };

    console.log(armamentProp);

    const handleOnClick = () => armamentId ? updateArmament() : createArmament();

    async function createArmament() {
        const reader = new FileReader();

        reader.onloadend = async () => {
            let imageString = reader.result
                .replace("base:", "")
                .replace(/^.+,/, "");

            await fetch("armaments/CreateArmaments", {
                method: "POST",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    name: armamentName,
                    caliber: armamentCaliber,
                    range: armamentRange,
                    rangeaircraft: armamentRangeAircraft,
                    rangehelicopter: armamentRangeHelicopter,
                    accuracy: armamentAccuracy,
                    stability: armamentStability,
                    armorPenetration: armamentArmorPenetration,
                    landmine: armamentLandmine,
                    suppression: armamentSuppresion,
                    rateOfFire: armamentRateOfFire,
                    image: imageString,
                    propsId: armamentProp
                })
            })

            navigate("/menuArmament");
        }
        reader.readAsDataURL(armamentImage);
    }

    async function updateArmamentHelper(image) {
        await fetch(`armaments/updateArmaments/${armamentId}`, {
            method: "PUT",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                name: armamentName,
                caliber: armamentCaliber,
                range: armamentRange,
                rangeaircraft: armamentRangeAircraft,
                rangehelicopter: armamentRangeHelicopter,
                accuracy: armamentAccuracy,
                stability: armamentStability,
                armorPenetration: armamentArmorPenetration,
                landmine: armamentLandmine,
                suppression: armamentSuppresion,
                rateOfFire: armamentRateOfFire,
                image: image
            })
        })
        navigate('/menuArmament');
    }

    function updateArmament() {
        const reader = new FileReader();

        reader.onloadend = () => {
            let imageString = reader.result
                .replace("data:", "")
                .replace(/^.+,/, "")

            updateArmamentHelper(imageString);
        }

        if (armamentImage) reader.readAsDataURL(armamentImage);
        else updateArmamentHelper(armamentCurrentImage);
    }

    return (
        <div>
            <input type='text' placeholder='name (word)' value={armamentName} onChange={handleSetArmamentsName} />
            <input type='text' placeholder='caliber (word)' value={armamentCaliber} onChange={handleSetArmamentsCaliber} />
            <input type='text' placeholder='range (number)' value={armamentRange} onChange={handleSetArmamentsRange} />
            <input type='text' placeholder='range aircraft (number)' value={armamentRangeAircraft} onChange={handleSetArmamentsRangeAircraft} />
            <input type='text' placeholder='range helicopter (number)' value={armamentRangeHelicopter} onChange={handleSetArmamentsRangeHelicopter} />
            <input type='text' placeholder='accuracy (number)' value={armamentAccuracy} onChange={handleSetArmamentsAccuracy} />
            <input type='text' placeholder='stability (number)' value={armamentStability} onChange={handleSetArmamentsStability} />
            <input type='text' placeholder='armor penetration (number)' value={armamentArmorPenetration} onChange={handleSetArmamentsArmorPenetration} />
            <input type='text' placeholder='landmine (number)' value={armamentLandmine} onChange={handleSetArmamentsLandmine} />
            <input type='text' placeholder='suppression (number)' value={armamentSuppresion} onChange={handleSetArmamentsSuppresion} />
            <input type='text' placeholder='rate of fire (number)' value={armamentRateOfFire} onChange={handleSetArmamentsRateOfFire} />

            <div style={{display: 'flex', flexDirection: 'column'}}>
                {properties.map(property =>
                    <div key={property.id}>
                    <input type="checkbox" onChange={handleSetArmamentsProp} id={property.id} />
                    <label htmlFor={property.id}>{property.name}</label>
                    </div>
                )}
            </div>


            <input type='file' onChange={handleSetArmamentsImage} />
            {!armamentImage && <img alt={armamentName} src={`data:image/png;base64,${armamentCurrentImage}`} />}
            <button onClick={handleOnClick}>Confirm</button>
        </div>
    )
}

export default ArmamentsCreate;
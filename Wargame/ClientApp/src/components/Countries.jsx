import React, { useEffect, useState } from 'react';

function Countries(){
  const [countries, setCountries] = useState([]);
  const [countryName, setCountryName] = useState("");
  const [countryFlag, setCountryFlag] = useState(null);
  const [showUpdateView, setShowUpdateView] = useState(false);
  const [currentCountry, setCurrentCountry] = useState("");
  const [currentFlag, setCurrentFlag] = useState(null);
  const [updatedName, setUpdatedName] = useState("");
  const [updatedFlag, setUpdatedFlag] = useState(null);

  useEffect(()=>{
    getAllCountries();
  },[])

  function handleSetCountryName(e){
    setCountryName(e.target.value);
  }

  function handleSetCountryFlag(e){

    setCountryFlag(e.target.files[0]);
  }

  function handleSetUpdatedName(e){
    setUpdatedName(e.target.value);
  }

  function handleSetUpdatedFlag(e){
    setUpdatedFlag(e.target.files[0]);
  }

  function handleOnUpdate(country){
    setShowUpdateView(true);
    setCurrentCountry(country.id);
    setCurrentFlag(country.flag);
    setUpdatedName(country.name);
  }

  async function getAllCountries(){
    const response = await fetch("countries/GetCountries");
    const data = await response.json();
    setCountries(data);
  }

  async function createCountry(){
    const reader = new FileReader();

    let base64String;

    reader.onloadend = async () => {
         base64String = reader.result
             .replace('data:', '')
             .replace(/^.+,/, '');
        
        await fetch("countries/PostCountries",{
          method: "POST",
          headers: {'Content-Type': 'application/json'}, 
          body: JSON.stringify({name: countryName, flag: base64String})
        })
        await getAllCountries();

    };
    reader.readAsDataURL(countryFlag);

    setCountryFlag(null);
    setCountryName("");
  }

  async function deleteCountry(id){
    await fetch(`countries/DeleteCountries/${id}`,{
      method: "DELETE"
    });
    getAllCountries();
  }

  async function updateCountry(id){
    const reader = new FileReader();

    let base64String;

    reader.onloadend = (async ()=>{
      base64String = reader.result
        .replace("data:","")
        .replace(/^.+,/,"");
      await fetch(`countries/ChangeCountries/${id}`,{
        method: "PUT",
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({
          name: updatedName,
          flag: base64String
        })
      });
      await getAllCountries();
      setUpdatedFlag(null);
    })
    if(updatedFlag) reader.readAsDataURL(updatedFlag);
    else {
      await fetch(`countries/ChangeCountries/${id}`,{
        method: "PUT",
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({
          name: updatedName,
          flag: currentFlag
        })
      })
      await getAllCountries();
    }

    setShowUpdateView(false);
    setUpdatedName("");
  }

  return(
    <div>
      <table>
        <tbody>
          {countries.map(country=>
            <tr key={country.id}>
              <td>{country.name}</td>
              <td><img alt="not fount" width={"250px"} src={`data:image/jpeg;base64,${country.flag}`} /></td>
              <td><button onClick={()=>deleteCountry(country.id)}>Delete</button></td>
              <td><button onClick={()=>handleOnUpdate(country)}>Update</button></td>
              {showUpdateView && currentCountry === country.id &&
              <>
                <td><input type='text' value={updatedName} onChange={handleSetUpdatedName}/></td>
                <td><input type='file' onChange={handleSetUpdatedFlag}/></td>
                <td><button onClick={()=>updateCountry(country.id)}>Confirm</button></td>
              </>}
            </tr>)}
        </tbody>
      </table>
      <input type='text' placeholder='name...' value={countryName} onChange={handleSetCountryName}/>

      <input type='file' name='uploads' id='img' onChange={handleSetCountryFlag}/>
      {countryFlag && (
        <div>
        <img alt="not fount" width={"250px"} src={URL.createObjectURL(countryFlag)} />
        <br />
        <button onClick={()=>setCountryFlag(null)}>Remove</button>
        </div>
      )}
      <br />

      <button onClick={createCountry}>Create</button>
    </div>
  )
}

export default Countries;

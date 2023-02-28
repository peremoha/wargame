export const PROPERTIES_URLS = {
    GET_PROPERTIES: "properties/GetProperties",
    CREATE_PROPERTIES: "properties/CreateProperties",
    DELETE_PROPERTIES: "properties/DeleteProperties",
    UPDATE_PROPERTIES: "properties/UpdateProperties",
}

export const ARMAMENTS_URLS = {
    GET_ARMAMENTS: "armaments/GetArmaments",
    CREATE_ARMAMENTS: "armaments/CreateArmaments",
    DELETE_ARMAMENTS: "armaments/DeleteArmaments",
    UPDATE_ARMAMENTS: "armaments/UpdateArmaments",
}

export const TANKS_URLS = {
    GET_TANKS: "tanks/GetTanks",
    CREATE_TANKS: "tanks/CreateTanks",
    DELETE_TANKS: "tanks/DeleteTanks",
    UPDATE_TANKS: "tanks/UpdateTanks",
}

export const TYPES_URLS = {
    GET_TYPES: "types/GetTypes",
    CREATE_TYPES: "types/AddTypes",
    DELETE_TYPES: "types/deleteTypes",
    UPDATE_TYPES: "types/updateTypes",
}

export const ROLES_URLS = {
    GET_ROLES: "roles/GetRoles",
    CREATE_ROLES: "roles/CreateRoles",
    DELETE_ROLES: "roles/DeleteRoles",
    UPDATE_ROLES: "roles/UpdateRoles",
}

export const MOVEMENTS_URLS = {
    GET_MOVEMENTS: "movements/GetMovements",
    CREATE_MOVEMENTS: "movements/CreateMovements",
    DELETE_MOVEMENTS: "movements/DeleteMovements",
    UPDATE_MOVEMENTS: "movements/UpdateMovements",
}

export const COUNTRIES_URLS = {
    GET_COUNTRIES: "countries/GetCountries",
    CREATE_COUNTRIES: "countries/PostCountries",
    DELETE_COUNTRIES: "countries/DeleteCountries",
    UPDATE_COUNTRIES: "countries/ChangeCountries",
}

export async function getAll(url){
    const response = await fetch(url);
    const data = await response.json();
    return data;
}

export async function deleteItem(url, id){
    await fetch(`${url}/${id}`, {
        method: "DELETE"
    })
}
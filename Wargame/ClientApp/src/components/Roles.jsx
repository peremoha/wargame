import React, { useEffect, useState } from "react";

function Roles() {
    const [roles, setRoles] = useState([]);
    const [role, setRole] = useState("");
    const [showUpdateView, setShowUpdateView] = useState(false);
    const [currentRole, setCurrentRole] = useState("");
    const [updatedRole, setUpdatedRole] = useState("");

    useEffect(() => { getAllRoles() }, [])

    function handleSetRole(e) {
        setRole(e.target.value);
    }

    function handleUpdatedRole(e) {
        setUpdatedRole(e.target.value);
    }

    function handleOnUpdate(currentRole) {
        setShowUpdateView(true);
        setCurrentRole(currentRole.id);
        setUpdatedRole(currentRole.name)
    }

    async function getAllRoles() {
        const response = await fetch('roles/getRoles');
        const data = await response.json();
        setRoles(data);
    }

    async function createRole() {
        await fetch('roles/createRoles', {
            method: "POST",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ name: role })
        });
        setRole("");
        getAllRoles();
    }

    async function deleteRole(id) {
        await fetch(`roles/deleteRoles/${id}`, {
            method: "DELETE"
        });
        getAllRoles();
    }

    async function updateRole(id) {
        await fetch(`roles/updateRoles/${id}`, {
            method: "PUT",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ name: updatedRole })
        });
        setUpdatedRole("");
        setShowUpdateView(false);
        getAllRoles();
    }

    return (
        <div>
            <table>
                <tbody>
                    {roles.map(roleItem =>
                        <tr key={roleItem.id}>
                            <td>{roleItem.name}</td>
                            <td><button onClick={() => deleteRole(roleItem.id)}>Delete</button></td>
                            <td><button onClick={() => handleOnUpdate(roleItem)}>Update</button></td>
                            {showUpdateView && currentRole === roleItem.id &&
                                <><td><input type='text' placeholder="new name..." value={updatedRole} onChange={handleUpdatedRole} /></td>
                                    <td><button onClick={() => updateRole(roleItem.id)}>Confirm</button></td></>}
                        </tr>)}
                </tbody>
            </table>
            <input type='text' placeholder='name...' value={role} onChange={handleSetRole} />
            <button onClick={createRole}>Create</button>
        </div>
    )
}

export default Roles;
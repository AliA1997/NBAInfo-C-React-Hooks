import React from 'react';

export const booleanFields = [
    "wonMVP",
    "wonChampionship"
]

const Form = ({fields, objState, submit, type, kind, handleChange, toggled=true, abilityToUpdate=false}) => {
    const buttonText = type === "Create" ? `Create ${kind[0].toUpperCase() + kind.slice(1)}` : `Update ${kind[0].toUpperCase() + kind.slice(1)}`; 
    return (
        <div className="form" style={{display: toggled ? "block" : "none"}}>
            {fields.map(field => booleanFields.includes(field) ?  <select onChange={e => handleChange(field, e.target.value)}>
                                                                    <option></option>
                                                                    <option value={true}>Yes I have {field}</option>
                                                                    <option value={false}>No I have not {field}</option>
                                                                    </select>
                                                                 : <input type="text" onChange={e => handleChange(field, e.target.value)}
                                                                     placeholder={abilityToUpdate ? objState[field] : `${field[0].toUpperCase()}${field.slice(1)}`} />)}
            <button onClick={e => !abilityToUpdate ? submit(e, kind) : submit(e)} className="submit-btn">{buttonText}</button>
        </div>
    );
}; 

export default Form;
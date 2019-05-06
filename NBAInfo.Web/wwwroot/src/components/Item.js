import React, { PureComponent } from 'react';
import Form from './Form';
import { playerFields, teamFields, coachFields } from './App';
import { booleanFields } from './Form';

const updateAjaxCall = (type, form) => {
    console.log("type--------", type);
    fetch(new Request(
            `https://localhost:44335/api/${type}`,
            {
                method: "PUT",
                mode: 'cors',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(form)
            }
        )
    )
    .then(res => console.log("Update Response----------", res))
    .catch((err) => {
        console.log("Update Error-----------", err);
    });
}

const deleteAjaxCall = (type, id) => {
    console.log("type--------", type);
    fetch(new Request(
            `https://localhost:44335/api/${type}/${id}`,
            {
                method: "DELETE",
                mode: 'cors',
                headers: {
                    'Content-Type': 'application/json'
                },
            }
        )
    )
    .then(res => console.log("Update Response----------", res))
    .catch((err) => {
        console.log("Update Error-----------", err);
    });
}


class Item extends PureComponent {
    constructor() {
        super();
        this.state = {
            updateForm: {},
            toggleForm: false
        }
    }

    handleChange = (key, value) => {
        const { updateForm } = this.state;
        const form = Object.assign({}, updateForm);
        if(booleanFields.includes(key)) form[key] = form[key] === "false" ? false : true;
        form[key] = value;
        console.log("form---------------", form);
        console.log("value-------------", typeof value);
        this.setState({updateForm: form});
    }

    update = (e) => {
        const { kind, properties } = this.props;
        const { updateForm } = this.state;
        e.preventDefault();
        console.log("Form-----------", updateForm);
        for(var key in properties) {
            if(updateForm[key] == null) updateForm[key] = properties[key];
        }
        console.log("updateForm-----------", JSON.stringify(updateForm));
        updateAjaxCall(kind, updateForm);
        window.location.reload();
    }

    delete = e => {
        const { kind, properties } = this.props;
        e.preventDefault();
        deleteAjaxCall(kind, properties.id);
        window.location.reload();
    }

    render() {
        const { properties, kind } = this.props;
        let fields;
        if(kind == "teams") fields = teamFields;
        if(kind == "players") fields = playerFields;
        if(kind == "coaches") fields = coachFields;
        const objectKeys = Object.keys(properties);
        const objectValues = Object.values(properties);
        return (
            <div className="item-div">
                {objectKeys.map((objKey, i) => !(typeof objectValues[i] == "boolean") ? <p key={i} className="item-text">{objKey}: {objectValues[i]}</p>
                                                                                    : <p key={i} className="item-text">{objKey}: {objectValues[i] ? "Yes" : "No"}</p>)}
                <Form toggled={this.state.toggleForm} submit={this.update} kind={kind} fields={fields} type="Update" objState={properties} abilityToUpdate={true} handleChange={this.handleChange}/>
                <button className='btn' 
                 onClick={() => this.setState({toggleForm: !this.state.toggleForm})}>{!this.state.toggleForm ? 'Update' : 'Close'}</button>
                 <button className='btn' display={{display: this.state.toggleForm ? 'inline-block' : 'none'}} onClick={e => this.delete(e)}>Delete</button>
            </div>
        );
    }
}

export default Item;
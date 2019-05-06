import React, { Component } from 'react';
import List from './List';
import Form from './Form';
//improt styles for your component
import '../styles/App.css';
//import your constant.
import { server } from '../config/config'; 

const createAjaxCall = (type, body) => {
    console.log('body----------', body)
    return fetch(new Request('https://localhost:44335/api/' + type + 's', {
        method: "POST",
        headers: {
            'Content-Type': "application/json",
        },
        mode: 'cors',
        body: JSON.stringify(body)
    }))
    .then(res => res.json())
    .then(resJSON => console.log(resJSON))
    .catch(err => console.log("Get Data Error-----------", err));
}


export const playerFields = [
    "name",
    "age",
    "teamId",
    "lastAllStarAppearance",
    "wonMVP",
    "wonChampionship"
];

export const teamFields = [
    "name",
    "city",
    "bestPlayerId",
    "bestPlayerOfAllTime",
    "lastPlayoffAppearance",
    "championships",
    "lastChampionship"
];

export const coachFields = [
    "name",
    "teamId",
    "lastPlayoffAppearance",
    "lastChampionship",
    "championships"
];

export default class App extends Component {
    constructor() {
        super();
        this.state = {
            playerForm: {},
            teamForm: {},
            coachForm: {}
        }
    }
    playerChange = (key, value) => {
        const { playerForm } = this.state;
        const form = Object.assign({}, playerForm);
        form[key] = value;
        this.setState({playerForm: form});
    }

    teamChange = (key, value) => {
        const { teamForm } = this.state;
        const form = Object.assign({}, teamForm);
        form[key] = value;
        this.setState({teamForm: form});
    }

    coachChange = (key, value) => {
        const { coachForm } = this.state;
        const form = Object.assign({}, coachForm);
        form[key] = value;
        this.setState({coachForm: form});
    }

    submit = (e, kind) => {
        e.preventDefault();
        let form;
        if(kind == 'team') {
            const { teamForm } = this.state;
            form = teamForm;
        } else if(kind == 'player') {
            const { playerForm } = this.state;
            form = playerForm;
        } else {
            const { coachForm } = this.state;
            form = coachForm;
        }
        for(var key in form) {
            if(form[key] == null) return;
        }
        console.log(form);
        createAjaxCall(kind, form);
        window.location.reload();
    }

    render() {
        return (
            <div>
                App
                <Form kind="player" handleChange={this.playerChange} fields={playerFields} submit={this.submit} type="Create"/>
                <Form kind="team" handleChange={this.teamChange} fields={teamFields} submit={this.submit} type="Create"/>
                <Form kind="coach" handleChange={this.coachChange} fields={coachFields} submit={this.submit} type="Create"/>
                <List type="players" />
                <List type="coaches" />
                <List type="teams" />

            </div>
        );
    }
}
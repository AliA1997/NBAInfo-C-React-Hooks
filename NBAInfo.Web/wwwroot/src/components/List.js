import React, { Component } from 'react';
import Item from './Item';


export default class List extends Component {
    constructor() {
        super();
        this.state = {
            list: []
        }
    }
    componentDidMount() {
        const { type } = this.props;
        fetch(new Request('https://localhost:44335/api/' + type, {
            method: "GET",
            type: "application/json",
            mode: 'cors'
        }))
        .then(res => res.json())
        .then(resJSON => this.setState({list: resJSON}))
        .catch(err => console.log("Get Data Error-----------", err));
    }

    render() {
        const { type } = this.props;
        const { list } = this.state;
        console.log('list-----------', list)
        return (
            <div>
                <h1>{type[0].toUpperCase() + type.slice(1)}</h1>
                {list.length ? list.map(listItem => <Item key={listItem.id} properties={listItem} update={this.update} kind={type}/>) : null}
            </div>
        );
    }
}
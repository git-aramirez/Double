import React, { Component } from 'react';
import { Input, InputNumber, Select, Space } from 'antd';
import '../css/styles.css';

export class RegisterPerson extends Component {

  constructor(props) {
    super(props);
      this.state = { names: "", lastnames: "", numberIdentification: "", typeIdentification: "CC", email: "" };
    }

    render() {

        const { names, lastnames, numberIdentification, typeIdentification, email } = this.state;


        const register = async () => {
            const data = {
                names: names, lastNames: lastnames, numberIdentification: numberIdentification.toString(), email: email,
                typeIdentification: typeIdentification, typeAndNumberIdentification: "", fullName: ""
            };
            const response = await fetch('api/person', {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(data),
            });

            

            this.setState({ names: "", lastnames: "", numberIdentification: "", typeIdentification: "CC", email: "" })
        }

        const getAllPeople = async () => {
           
            const response = await fetch('api/person', {
                method: "GET",
            });

            if (response.ok) {
                response.json().then(data => {
                    let people = new Array();
                    data.map(person => {
                        people.push([
                            person.personId, person.names, person.lastNames, person.numberIdentification,
                            person.Email, person.typeIdentification, person.typeAndNumberIdentification,
                            person.fullName, person.dateCreation])
                    })
                    alert(people);
                })
            }

            this.setState({ names: "", lastnames: "", numberIdentification: "", typeIdentification: "CC", email: "" })
        }

        const changeTypeIdentification = (value: string) => {
            this.setState({ typeIdentification: value });
        };

        const onChangeInputNumber = (value: number) => {
            this.setState({ numberIdentification: value });
        };

    return (
        <Space direction="vertical">
            <h2>Register Person</h2><br />
            <Input value={names} placeholder="Names" onChange={(e) => this.setState({ names: e.target.value })} className="input-form" />
            <Input value={lastnames} placeholder="Lastnames" onChange={(e) => this.setState({ lastnames: e.target.value })} className="input-form" />
            <InputNumber value={numberIdentification} placeholder="Number identification" min={1} onChange={onChangeInputNumber} className="input-form" />
            <Input value={email} placeholder="Email" onChange={(e) => this.setState({ email: e.target.value })} className="input-form" />
            <Select 
                defaultValue="CC"
                value={typeIdentification}
                style={{ width: 120 }}
                onChange={changeTypeIdentification}
                options={[
                    { value: 'CC', label: 'CC' },
                    { value: 'TI', label: 'TI' },
                ]}
            />
            <button className="btn btn-primary" onClick={register}>Register</button>

            <button className="btn btn-success" onClick={getAllPeople}>Get Everyone</button>

        </Space>
    );
  }
}

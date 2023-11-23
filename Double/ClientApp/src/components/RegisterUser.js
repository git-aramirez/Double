import React, { Component, useState } from 'react';
import { UserOutlined, EyeInvisibleOutlined, EyeTwoTone } from '@ant-design/icons';
import { Input, Space, Alert } from 'antd';

export class RegisterUser extends Component {

    constructor(props) {
        super(props);
        this.state = { username: "", password: "",isVisibleError: false, isVisibleSuccess: false };
    }

    render() {
        const { username, password, isVisibleError, isVisibleSuccess } = this.state;

        const register = async () => {

            const data = { username: username, password: password };
            const response = await fetch('api/user', {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(data),
            });

            if (response.ok) {
                this.setState({ isVisibleSuccess: true });
            } else {
                this.setState({ isVisibleError: true });
            }
          
            this.setState({ username: "", password:"" })
        }

        const handleCloseError = () => {
            this.setState({ isVisibleError: false })
        };

        const handleCloseSuccess = () => {
            this.setState({ isVisibleSuccess: false })
        };

        function AlertError() {
            if (isVisibleError) {
                return (<Alert message="The User couldn't register success!" type="error" showIcon closable
                    afterClose={handleCloseError} />);
            }

            return (<></>);
        }
        function AlertSuccess() {
            if (isVisibleSuccess) {
                return (<Alert message="!User registered success!" type="success" showIcon closable
                    afterClose={handleCloseSuccess} />);
            }

            return (<></>);
        }

        return (
            <Space direction="vertical">
                <AlertError />
                <AlertSuccess />
                <h2>Register User</h2><br />

                <Input placeholder="username" value={this.state.username} prefix={<UserOutlined />} onChange={(e) => this.setState({ username: e.target.value })} />

                <Input.Password placeholder="password" value={this.state.password} iconRender={(visible) => (visible ? <EyeTwoTone /> : <EyeInvisibleOutlined />)} onChange={(e) => this.setState({ password: e.target.value })} />

                <button className="btn btn-primary" onClick={register}>Register</button>

            </Space>
        );
    }
}


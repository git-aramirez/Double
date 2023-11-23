import React, { Component } from 'react';
import { UserOutlined, EyeInvisibleOutlined, EyeTwoTone } from '@ant-design/icons';
import { Input, Space, Alert } from 'antd';

export class Login extends Component {

    constructor(props) {
        super(props);
        this.state = { username: "", password: "", isVisibleError: false, isVisibleSuccess: false };
    }

    render() {
        const { username, password, isVisibleError, isVisibleSuccess } = this.state;

        const handleCloseError = () => {
            this.setState({ isVisibleError:false })
        };

        const handleCloseSuccess = () => {
            this.setState({ isVisibleSuccess: false })
        };

        function AlertError() {
            if (isVisibleError) {
                return (<Alert message="User no found!" type="error" showIcon closable
                    afterClose={handleCloseError} />);
            }

            return (<></>);
        }
        function AlertSuccess() {
            if (isVisibleSuccess) {
                return (<Alert message="!User found success!" type="success" showIcon closable
                    afterClose={handleCloseSuccess} />);
            }

            return (<></>);
        }

        const doLogin = async () => {

            const response = await fetch('api/user/' + username + '/' + password, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                },
            });

            if (response.ok) {
                response.json().then(data => {
                    if (data === false) {
                        this.setState({ isVisibleError: true });
                    } else {
                        this.setState({ isVisibleSuccess: true });
                    }
                })
            }

            this.setState({ username: "", password: "" })
        }

    return (
        <Space direction="vertical">
            <AlertError />
            <AlertSuccess />
            <h2>Login</h2><br />

            <Input placeholder="username" value={this.state.username} onChange={(e) => this.setState({ username: e.target.value })} prefix={<UserOutlined />} />

            <Input.Password placeholder="password" value={this.state.password} onChange={(e) => this.setState({ password: e.target.value })} iconRender={(visible) => (visible ? <EyeTwoTone /> : <EyeInvisibleOutlined />)} />

            <button className="btn btn-success" onClick={doLogin} >Log in</button>
        </Space>
    );
  }
}

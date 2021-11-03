import { Component } from "react";
import axios from 'axios'
import '../../assets/css/login.css';
import logo from '../../assets/img/logo.png'
import { parseJwt, usuarioAutenticado } from "../../services/auth";

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: '',
            erroMensagem: '',
            isLoading: false
        }
    }

    efetuarLogin = (event) => {
        event.preventDefault();

        this.setState({
            erroMensagem: '',
            isLoading: true
        })

        axios.post('http://localhost:5000/api/login', {
            email: this.state.email,
            senha: this.state.senha
        })

            .then(resposta => {
                if (resposta.status === 200) {
                    console.log(resposta)
                    localStorage.setItem('usuario-login', resposta.data.token)
                    this.setState({
                        isLoading: false
                    })

                    let base64 = localStorage.getItem('usuario-login').split('.')[1]
                    console.log(base64)
                    console.log(window.atob(base64))
                    console.log(JSON.parse(window.atob(base64)))
                    console.log(parseJwt().role)

                    if (parseJwt().role === '1') {
                        this.props.history.push('/tiposEventos')
                        
                    } else {
                        this.props.history.push('/')
                    }
                }
            })


            .catch(() => {
                this.setState({
                    erroMensagem: 'E-mail e/ou senha inválidos.',
                    isLoading: false
                })
            })

        this.limparCampos()
    }

    atualizaStateCampo = (campo) => {
        this.setState({
            [campo.target.name]: campo.target.value
        })
    }

    limparCampos = () => {
        this.setState({
            email: '',
            senha: ''
        })
    }



    render() {
        return (
            <div>
                <main>
                    <section className="container-login flex">
                        <div className="img__login"><div className="img__overlay"></div></div>

                        <div className="item__login">
                            <div className="row">
                                <div className="item">
                                    <img src={logo} className="icone__login" alt="logo da Gufi" />
                                </div>
                                <div className="item" id="item__title">
                                    <p className="text__login" id="item__description">
                                        Bem-vindo! Faça login para acessar sua conta.
                                    </p>
                                </div>
                                <form onSubmit={this.efetuarLogin}>
                                    <div className="item">
                                        <input
                                            className="input__login"
                                            type="text"
                                            name="email"
                                            value={this.state.email}
                                            onChange={this.atualizaStateCampo}
                                            placeholder="username"
                                        />
                                    </div>
                                    <div className="item">
                                        <input
                                            className="input__login"
                                            type="password"
                                            name="senha"
                                            value={this.state.senha}
                                            onChange={this.atualizaStateCampo}
                                            placeholder="password"
                                        />
                                    </div>
                                    <div className="item">
                                        <p style={{ color: "red" }}>{this.state.erroMensagem}</p>

                                        {
                                            this.state.isLoading === true ?
                                                <button className="btn btn__login" id="btn__login" disabled type="submit">Loading</button>
                                                :
                                                <button className="btn btn__login" id="btn__login" disabled={this.state.email === '' || this.state.senha === '' ? 'none' : ''} type="submit">Login</button>
                                        }
                                    </div>
                                </form>
                            </div>
                        </div>
                    </section>
                </main>
            </div>
        )
    }

}
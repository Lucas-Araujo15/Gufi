import { Component } from "react";
import axios from 'axios'

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
                    <section>
                        <p>Bem vindo(a)! <br /> Faça login para acessar a sua conta.</p>

                        <form onSubmit={this.efetuarLogin}>
                            <input
                                type="text"
                                name="email"
                                value={this.state.email}
                                onChange={this.atualizaStateCampo}
                                placeholder="username"
                            />
                            <input
                                type="password"
                                name="senha"
                                value={this.state.senha}
                                onChange={this.atualizaStateCampo}
                                placeholder="password"
                            />

                            <p style={{ color: "red" }}>{this.state.erroMensagem}</p>

                            {
                                this.state.isLoading === true ?
                                    <button disabled type="submit">Loading</button>
                                    :
                                    <button disabled={this.state.email === '' || this.state.senha === '' ? 'none' : ''}  type="submit">Login</button>
                            }

                        </form>
                    </section>
                </main>
            </div>
        )
    }

}
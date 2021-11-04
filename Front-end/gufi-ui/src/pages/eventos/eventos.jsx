import { React, Component } from 'react';
import axios from 'axios';

export default class Eventos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            titulo: '',
            descricao: '',
            dataEvento: new Date(),
            listaEventos: [],
            listaTiposEvento: [],
            listaInstituicao: [],
            acessoLivre: 0,
            idTipoEvento: 0,
            idInstituicao: 0,
            isLoading: false

        }
    };

    atualizaStateCampo = (campo) => {
        this.setState({
            [campo.target.name]: campo.target.value
        })
    }

    buscaTiposEventos = () => {
        axios('http://localhost:5000/api/tiposevento', {
            headers: {
                'Authorization': 'Bearer' + localStorage.getItem('usuario-login')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                this.setState({
                    listaTiposEvento: resposta.data
                })
            }
        }).catch(erro => console.log(erro))
    }

    buscaEventos = () => {
        axios('http://localhost:5000/api/eventos'
        ).then(resposta => {
            if (resposta.status === 200) {
                this.setState({
                    listaEventos: resposta.data
                })
            }
        }).catch(erro => console.log(erro))
    }

    buscaInstituicoes = () => {
        axios('http://localhost:5000/api/instituicoes', {
            headers: {
                'Authorization': 'Bearer' + localStorage.getItem('usuario-login')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                this.setState({
                    listaInstituicao: resposta.data
                })
            }
        }).catch(erro => console.log(erro))
    }

    componentDidMount() {
        this.buscaTiposEventos()
        this.buscaInstituicoes()
        this.buscaEventos()
    }

    cadastrarEvento = (event) => {
        event.preventDefault()
        this.setState({
            isLoading: true
        })

        let evento = {
            nomeEvento: this.state.titulo,
            descricao: this.state.descricao,
            dataEvento: new Date(this.state.dataEvento),
            acessoLivre: parseInt(this.state.acessoLivre),
            idTipoEvento: this.state.idTipoEvento,
            idInstituicao: this.state.idInstituicao
        }

        axios.post('http://localhost:5000/api/eventos', evento, {
            headers: {
                'Authorization': 'Bearer' + localStorage.getItem('usuario-login')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                console.log("Evento cadastrado")
                this.setState({
                    isLoading: false
                })
            }
        }).catch(erro => console.log(erro))
            .then(this.buscaEventos)
    }

    render() {

        return (
            <>
                <main>
                    <section>
                        {/* Lista de Eventos */}
                        <h2>Lista de Eventos</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Evento</th>
                                    <th>Descrição</th>
                                    <th>Data</th>
                                    <th>Acesso Livre</th>
                                    <th>Tipo de Evento</th>
                                    <th>Localização</th>
                                </tr>
                            </thead>

                            <tbody>
                                {
                                    this.state.listaEventos.map(evento => {
                                        return (
                                            <tr key={evento.idEvento}>
                                                <td>{evento.idEvento}</td>
                                                <td>{evento.nomeEvento}</td>
                                                <td>{evento.descricao}</td>
                                                <td>{evento.dataEvento}</td>
                                                <td>{evento.acessoLivre ? 'Livre' : 'Restrito'}</td>
                                                <td>{evento.idTipoEventoNavigation.tituloTipoEvento}</td>
                                                <td>{evento.idInstituicaoNavigation.endereco}</td>
                                            </tr>
                                        )
                                    })
                                }

                            </tbody>
                        </table>
                    </section>

                    <section>
                        {/* Cadastro de Eventos */}
                        <h2>Cadastro de Eventos</h2>
                        <form onSubmit={this.cadastrarEvento}>
                            <div style={{ display: 'flex', flexDirection: 'column', width: '20vw' }}>

                                <input required
                                    type="text"
                                    name="titulo"
                                    value={this.state.titulo}
                                    onChange={this.atualizaStateCampo}
                                    placeholder="Título do Evento"
                                />

                                <input required
                                    type="text"
                                    name="descricao"
                                    value={this.state.descricao}
                                    onChange={this.atualizaStateCampo}
                                    placeholder="Descrição do evento"
                                />

                                <input required
                                    type="date"
                                    name="dataEvento"
                                    value={this.state.dataEvento}
                                    onChange={this.atualizaStateCampo}
                                    placeholder="Data do evento"
                                />

                                <select
                                    name="idTipoEvento"
                                    value={this.state.idTipoEvento}
                                    onChange={this.atualizaStateCampo}>

                                    <option value="0" selected disabled>Selecione o tema do evento</option>

                                    {
                                        this.state.listaTiposEvento.map((tema) => {
                                            return (
                                                <option value={tema.idTipoEvento}>{tema.tituloTipoEvento}</option>
                                            )
                                        })
                                    }
                                </select>

                                <select
                                    name="acessoLivre"
                                    value={this.state.acessoLivre}
                                    onChange={this.atualizaStateCampo}
                                >
                                    <option value="" selected>Selecione o acesso</option>
                                    <option value="1">Livre</option>
                                    <option value="0">Restrito</option>
                                </select>


                            </div>
                        </form>
                    </section>
                </main>
            </>
        );
    };
};
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

                    </section>
                </main>
            </>
        );
    };
};
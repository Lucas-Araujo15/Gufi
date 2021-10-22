import { Component } from "react";

class TiposEventos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaTiposEventos: [],
            titulo: '',
            idTipoEventoAlterado: 0
        }
    };

    buscarTipoEventos = () => {
        console.log("Está funcionando!")

        fetch('http://localhost:5000/api/tiposevento')

            .then(resposta => resposta.json())

            .then(dados => this.setState({ listaTiposEventos: dados }))

            .catch(erro => console.log(erro))
    }

    atualizaEstadoTitulo = async (event) => {
        console.log("acionou a função.")
        await this.setState({
            titulo: event.target.value
        })

        console.log(this.state.titulo)
    }

    cadastrarTipoEvento = (event) => {
        event.preventDefault();

        if (this.state.idTipoEventoAlterado !== 0) {
            fetch('http://localhost:5000/api/tiposevento/' + this.state.idTipoEventoAlterado, {
                method: 'PUT',
                body: JSON.stringify({ tituloTipoEvento: this.state.titulo }),
                headers: {
                    "Content-Type": "application/json"
                }
            })

                .then(resposta => {
                    if (resposta.status === 204) {
                        console.log('O tipo de evento ' + this.state.idTipoEventoAlterado + ' foi atualizado!',
                            'Seu novo título agora é: ' + this.state.titulo)
                    }
                })

                .then(this.limparCampos)

                .then(this.buscarTipoEventos)
        }
        else {
            fetch('http://localhost:5000/api/tiposevento', {
                method: 'POST',

                body: JSON.stringify({ tituloTipoEvento: this.state.titulo }),

                headers: {
                    "Content-Type": "application/json"
                }
            })

                .then(console.log("Cadastrando"))

                .then(this.limparCampos)

                .then(this.buscarTipoEventos)

                .catch(erro => console.log(erro))
        }
    }

    componentDidMount() {
        this.buscarTipoEventos()
    }

    buscarTipoEventoPorId = (tipoEvento) => {
        this.setState({
            idTipoEventoAlterado: tipoEvento.idTipoEvento,
            titulo: tipoEvento.tituloTipoEvento
        }, () => {
            console.log(
                'O tipo de evento ' + tipoEvento.idTipoEvento + ' foi selecionado, ',
                'agora o valor do state idTipoEventoAlterado é: ' + this.state.idTipoEventoAlterado + ', ',
                'E o título é ' + tipoEvento.tituloTipoEvento
            )
        })
    }

    limparCampos = () => {
        this.setState({
            titulo: "",
            idTipoEventoAlterado: 0
        })
    }

    render() {
        return (
            <div>
                <main>
                    <section>
                        <h2>Lista de tipos de eventos</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Título</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.listaTiposEventos.map((tipoEvento) => {
                                        return (
                                            <tr key={tipoEvento.idTipoEvento}>
                                                <td>{tipoEvento.idTipoEvento}</td>
                                                <td>{tipoEvento.tituloTipoEvento}</td>

                                                <td><button onClick={() => this.buscarTipoEventoPorId(tipoEvento)}>Editar</button></td>
                                            </tr>
                                        )
                                    })
                                }
                            </tbody>
                        </table>
                    </section>
                    <section>
                        <h2>Cadastro de tipo de evento</h2>
                        <form onSubmit={this.cadastrarTipoEvento}>
                            <div>
                                <input type="text"
                                    value={this.state.titulo}
                                    placeholder="Título do tipo de evento"
                                    onChange={this.atualizaEstadoTitulo}
                                />

                                {
                                    <button type="submit" disabled={this.state.titulo === '' ? 'none' : ''}>
                                        {this.state.idTipoEventoAlterado === 0 ? 'Cadastrar' : 'Atualizar'}
                                    </button>
                                }

                                <button type="button" onClick={this.limparCampos} style={this.state.titulo === '' ? { display: 'none' } : { display: '' }}>
                                    Cancelar
                                </button>

                                {
                                    this.state.idTipoEventoAlterado !== 0 &&
                                    <div>
                                        <p>
                                            O tipo de evento {this.state.idTipoEventoAlterado} está sendo editado.
                                        </p>
                                        <p>
                                            Clique em cancelar caso queira interromper a operação!
                                        </p>
                                    </div>
                                }
                            </div>
                        </form>
                    </section>
                </main>
            </div>
        )
    }
}

export default TiposEventos;
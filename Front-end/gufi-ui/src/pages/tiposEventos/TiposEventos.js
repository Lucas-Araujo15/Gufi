import { Component } from "react";

class TiposEventos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaTiposEventos: [],
            titulo: ''
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

        fetch('http://localhost:5000/api/tiposevento', {
            method: 'POST',

            body: JSON.stringify({tituloTipoEvento : this.state.titulo}),

            headers: {
                "Content-Type": "application/json"
            }
        })

        .then(console.log("Cadastrando"))

        .then(this.buscarTipoEventos)

        .then(this.state.titulo = "")

        .catch(erro => console.log(erro))
    }

    componentDidMount() {
        this.buscarTipoEventos()
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
                                <input type="text" value={this.state.titulo}
                                    placeholder="Título do tipo de evento"
                                    onChange={this.atualizaEstadoTitulo}
                                />
                                <button type="submit">Cadastrar</button>
                            </div>
                        </form>
                    </section>
                </main>
            </div>
        )
    }
}

export default TiposEventos;
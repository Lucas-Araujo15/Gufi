import '../../assets/css/login.css';
import '../../assets/css/style.css';
import '../../assets/css/reset.css';
import '../../assets/css/flexbox.css';
import {Link} from 'react-router-dom';
import logo from '../../assets/img/logo.png'


function App() {
  return (
    <div>
      <header className="cabecalhoPrincipal">
        <div className="container">
          <Link to="/"><img src={logo} alt="Logo da Gufi" /></Link>
          <nav className="cabecalhoPrincipal-nav">
            <Link to="/">Home</Link>
            <Link to="/eventos">Eventos</Link>
            <a href="#conteudoPrincipal-contato">Contato</a>
            <Link className="cabecalhoPrincipal-nav-login" to="/login">Login</Link>
           
          </nav>
        </div>
      </header>

      <section className="conteudoImagem">
        <div>
          <h1>Gufi</h1>
          <h2>Área de eventos da Escola SENAI de Informática.</h2>
        </div>
      </section>

      <main className="conteudoPrincipal">
        <section id="conteudoPrincipal-eventos">
          <h1 id="conteudoPrincipal-eventos-titulo">Próximos Eventos</h1>
          <div className="container">
            <nav>
              <ul className="conteudoPrincipal-dados">
                <li className="conteudoPrincipal-dados-link eventos">
                  <h2>Título do Evento</h2>
                  <p>
                    Breve descrição sobre o evento. Lorem ipsum lorem ipsum
                    lorem ipsum.
                  </p>
                  <button>conectar</button>
                </li>

                <li className="conteudoPrincipal-dados-link eventos">
                  <h2>Título do Evento</h2>
                  <p>
                    Breve descrição sobre o evento. Lorem ipsum lorem ipsum
                    lorem ipsum.
                  </p>
                  <button>conectar</button>
                </li>

                <li className="conteudoPrincipal-dados-link eventos">
                  <h2>Título do Evento</h2>
                  <p>
                    Breve descrição sobre o evento. Lorem ipsum lorem ipsum
                    lorem ipsum.
                  </p>
                  <button>conectar</button>
                </li>

                <li className="conteudoPrincipal-dados-link eventos">
                  <h2>Título do Evento</h2>
                  <p>
                    Breve descrição sobre o evento. Lorem ipsum lorem ipsum
                    lorem ipsum.
                  </p>
                  <button>conectar</button>
                </li>
              </ul>
            </nav>
          </div>
        </section>

        <section id="conteudoPrincipal-visao">
          <h1 id="conteudoPrincipal-visao-titulo">Por Quê Participar?</h1>
          <div className="container">
            <p className="visao-texto">
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. <br />
              Nullam auctor suscipit eros sed blandit. <br />
              Fusce euismod neque sed dapibus sollicitudin. <br />Duis vel lacus
              vestibulum, molestie dui eu, bibendum nunc.
            </p>
          </div>
        </section>

        <section id="conteudoPrincipal-contato">
          <h1 id="conteudoPrincipal-contato-titulo">Contato</h1>
          <div
            className="container conteudo-contato-titulo"
          >
            <div
              className="contato-mapa conteudo-contato-mapa"
            ></div>
            <div
              className="contato-endereco conteudo-contato-endereco"
            >
              Alameda Barão de Limeira, 539 <br />
              São Paulo - SP
            </div>
          </div>
        </section>
      </main>

      <footer className="rodapePrincipal">
        <section className="rodapePrincipal-patrocinadores">
          <div className="container">
            <p>Escola SENAI de Informática - 2021</p>
          </div>
        </section>
      </footer>
    </div>
  );
}

export default App;

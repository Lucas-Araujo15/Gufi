import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';
import Home from './pages/home/App'
import NotFound from './pages/notFound/NotFound'
import TiposEventos from './pages/tiposEventos/TiposEventos.jsx'
import Login from './pages/login/login.jsx'
import Eventos from './pages/eventos/eventos.jsx'
import './index.css';
import reportWebVitals from './reportWebVitals';
import { parseJwt } from './services/auth';
import { usuarioAutenticado } from './services/auth';

const PermissaoAdm = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '1' ? (
        // operador spread
        <Component {...props} />
      ) : (
        <Redirect to="/login" />
      )
    }
  />
);

const PermissaoComum = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '2' ? (
        // operador spread
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} /> {/* Home */}
        <PermissaoComum path="/eventos" component={Eventos}/>
        <PermissaoAdm path="/tiposEventos" component={TiposEventos} /> {/* TiposEventos */}
        <Route path="/notFound" component={NotFound} /> {/*NotFound*/}
        <Route path="/login" component={Login} />
        <Redirect to="/notFound" /> {/*Redireciona para Not Found caso não encontre nenhuma rota*/}
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();

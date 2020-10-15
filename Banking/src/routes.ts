import React from 'react';
import $ from 'jquery';

// window.jQuery: = $;
// window.$ = $;
// global.jQuery = $;

const Main = React.lazy(() => import('./pages/Main/Main'));
const Cuenta = React.lazy(() => import('./pages/Main/Cuenta'));
const TransferenciaExpreso = React.lazy(() => import('./pages/Transferencias/Expreso'));

const routes = [
    { path: '/cuentas', exact: true, name: 'Cuentas', component: Main },
    { path: '/cuentas/:id', exact: true, name: 'Cuenta', component: Cuenta },
    { path: '/cuentas/:id/expreso', exact: true, name: 'Transferencia Expreso', component: TransferenciaExpreso }
];

export default routes;
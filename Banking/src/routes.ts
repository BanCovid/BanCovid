import React from 'react';
import $ from 'jquery';

// window.jQuery: = $;
// window.$ = $;
// global.jQuery = $;

const Main = React.lazy(() => import('./pages/Main/Main'));
const Cuenta = React.lazy(() => import('./pages/Main/Cuenta'));
const TransferenciaExpreso = React.lazy(() => import('./pages/Transferencias/Expreso'));
const Beneficiarios = React.lazy(() => import('./pages/Beneficiarios/Beneficiarios'));
const TBeneficiario = React.lazy(() => import('./pages/Transferencias/Beneficiario'));
const TMisCuentas = React.lazy(() => import('./pages/Transferencias/MisCuentas'));
const TMisCuentas2 = React.lazy(() => import('./pages/Transferencias/MisCuentas2'));

const routes = [
    { path: '/cuentas', exact: true, name: 'Cuentas', component: Main },
    { path: '/cuentas/:id', exact: true, name: 'Cuenta', component: Cuenta },
    { path: '/cuentas/:id/expreso', exact: true, name: 'Transferencia Expreso', component: TransferenciaExpreso },
    { path: '/cuentas/:id/beneficiarios', exact: true, name: 'Beneficiarios', component: TBeneficiario },
    { path: '/cuentas/:id/miscuentas', exact: true, name: 'Transferencia entre mis cuentas', component: TMisCuentas },
    { path: '/beneficiarios', exact: true, name: 'Beneficiarios', component: Beneficiarios },
    { path: '/transaccion_mis_cuentas', exact: true, name: 'Beneficiarios', component: TMisCuentas2 }
];

export default routes;
import React, { useEffect, useState } from 'react';
import { Button, Card, Col, Row, Table } from 'react-bootstrap';
import { useHistory, useRouteMatch } from 'react-router-dom';
import Breadcrumb from '../../App/components/Breadcrumb';
import Aux from '../../hoc/_Aux';
import DEMO from '../../store/constant';

import { dateLongFormat, dateShortFormat, moneyFormat } from '../../utils';
import transferenciaService from '../../services/transferenciaService';
import { TransferenciaModelo } from '../../models/TransferenciaModel';
import { CuentaEstadisticasModel } from '../../models/CuentaEstadisticasModel';
import cuentasService from '../../services/cuentasService';


const Cuenta: React.FC = () => {
    const history = useHistory();
    const match = useRouteMatch();
    const { id }: any = match.params;

    const [estadisticas, setEstadisticas] = useState<CuentaEstadisticasModel>({} as CuentaEstadisticasModel);
    const [transacciones, setTransacciones] = useState<TransferenciaModelo[]>([]);

    useEffect(() => {
        transferenciaService
            .obtenerTodos(id)
            .then((data) => {
                setTransacciones(data)
            })
            .catch(() => {

            });
        cuentasService
            .estadisticas(id)
            .then((data) => {
                setEstadisticas(data)
            })
            .catch(() => {

            });
    }, []);

    return (
        <>
            <Breadcrumb
                title={`Cuenta No. ${id}`}
                items={[{
                    name: 'Cuentas',
                    path: '/cuentas',
                    isActive: false
                }, {
                    name: `Cuenta No. ${id}`,
                    path: `/cuentas/${id}`,
                    isActive: true
                }]}
            />
            <Aux>
                <Row>
                    <Col md={6} xl={4}>
                        <Card>
                            <Card.Body>
                                <h6 className='mb-4'>Balance actual</h6>
                                <div className="row d-flex align-items-center">
                                    <div className="col-9">
                                        <h3 className="f-w-300 d-flex align-items-center m-b-0"><i className="feather icon-credit-card f-30 m-r-5" /> {moneyFormat(estadisticas.BalanceActual)}</h3>
                                    </div>
                                </div>
                                <div className="m-t-30" style={{ height: '7px' }}>
                                    <p className="m-0">No se consideran transacciones en proceso</p>
                                </div>
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col xl={4}>
                        <Card>
                            <Card.Body>
                                <h6 className='mb-4'>Balance disponible</h6>
                                <div className="row d-flex align-items-center">
                                    <div className="col-9">
                                        <h3 className="f-w-300 d-flex align-items-center m-b-0"><i className="feather icon-arrow-up text-c-green f-30 m-r-5" /> {moneyFormat(estadisticas.BalanceDisponible)}</h3>
                                    </div>

                                    <div className="col-3 text-right">
                                        <p className="m-b-0">{estadisticas.BalanceDisponiblePorcent}%</p>
                                    </div>
                                </div>
                                <div className="progress m-t-30" style={{ height: '7px' }}>
                                    <div className="progress-bar progress-c-theme" role="progressbar" style={{ width: estadisticas.BalanceDisponiblePorcent + '%' }} aria-valuenow={estadisticas.BalanceDisponiblePorcent} aria-valuemin={0} aria-valuemax={100} />
                                </div>
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col md={6} xl={4}>
                        <Card>
                            <Card.Body>
                                <h6 className='mb-4'>Balance en el último corte</h6>
                                <div className="row d-flex align-items-center">
                                    <div className="col-9">
                                        <h3 className="f-w-300 d-flex align-items-center m-b-0"><i className="feather icon-arrow-down text-c-red f-30 m-r-5" /> {moneyFormat(estadisticas.BalanceUltimoCorte)}</h3>
                                    </div>

                                    <div className="col-3 text-right">
                                        <p className="m-b-0">{estadisticas.BalanceUltimoCortePorcent}%</p>
                                    </div>
                                </div>
                                <div className="progress m-t-30" style={{ height: '7px' }}>
                                    <div className="progress-bar progress-c-theme2" role="progressbar" style={{ width: estadisticas.BalanceUltimoCortePorcent + '%' }} aria-valuenow={estadisticas.BalanceUltimoCortePorcent} aria-valuemin={0} aria-valuemax={100} />
                                </div>
                            </Card.Body>
                        </Card>
                    </Col>

                    <Col md={6} xl={8}>
                        <Card className='Recent-Users'>
                            <Card.Header>
                                <Card.Title as='h5'>Transacciones</Card.Title>
                            </Card.Header>
                            <Card.Body className='px-0 py-2'>
                                <Table responsive hover>
                                    <tbody>
                                        {transacciones.map((item, index) => (
                                            <tr className="unread" key={index}>
                                                <td>
                                                    <h6 className="mb-1">{item.Concepto}</h6>
                                                    <p className="m-0">{(item.TitularDestino) ? item.TitularDestino : item.Titular}</p>
                                                </td>
                                                <td>{item.CuentaDestino ? `Cuenta No.${(item.Cuenta === id) ? item.CuentaDestino : item.Cuenta}` : 'Cajero'}</td>
                                                <td>
                                                    {item.TipoTransaccion === 1 && (
                                                        moneyFormat(item.Monto)
                                                    )}
                                                    {item.TipoTransaccion === 2 && (
                                                        <label className="text-c-red">{moneyFormat(item.Monto)}</label>
                                                    )}
                                                    {item.TipoTransaccion === 3 && (
                                                        <>
                                                            {item.Cuenta === id ? (
                                                                <label className="text-c-red">{moneyFormat(item.Monto)}</label>
                                                            ) : (
                                                                    moneyFormat(item.Monto)
                                                                )}
                                                        </>
                                                    )}

                                                </td>
                                                <td>
                                                    <h6 className="text-muted">
                                                        {item.Estado === 0 && (
                                                            <i className="fa fa-circle text-c-red f-10 m-r-15" />
                                                        )}
                                                        {item.Estado === 1 && (
                                                            <i className="fa fa-circle text-c-blue f-10 m-r-15" />
                                                        )}
                                                        {item.Estado === 2 && (
                                                            <i className="fa fa-circle text-c-green f-10 m-r-15" />
                                                        )}
                                                        {dateLongFormat(new Date(item.Fecha!))}
                                                    </h6>
                                                </td>
                                                <td>
                                                    {item.Estado === 0 && (
                                                        <label className="label theme-bg2 text-white f-12">Cancelada</label>
                                                    )}
                                                    {item.Estado === 1 && (
                                                        <label className="label theme-bg2 text-white f-12">En proceso</label>
                                                    )}
                                                    {item.Estado === 2 && (
                                                        <label className="label theme-bg2 text-white f-12">Realizada</label>
                                                    )}
                                                    {item.TipoTransaccion === 1 && (
                                                        <label className="label theme-bg text-white f-12">Deposito</label>
                                                    )}
                                                    {item.TipoTransaccion === 2 && (
                                                        <label className="label theme-bg1 text-white f-12" style={{ minWidth: '70px', textAlign: 'center' }}>Retiro</label>
                                                    )}
                                                    {item.TipoTransaccion === 3 && (
                                                        <>
                                                            {item.Cuenta === id ? (
                                                                <label className="label theme-bg1 text-white f-12" style={{ minWidth: '70px', textAlign: 'center' }}>Retiro</label>
                                                            ) : (
                                                                    <label className="label theme-bg text-white f-12">Deposito</label>
                                                                )}
                                                        </>
                                                    )}
                                                </td>
                                            </tr>
                                        ))}
                                    </tbody>
                                </Table>
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col md={6} xl={4}>
                        <Card>
                            <Card.Header>
                                <Card.Title as='h5'>Transferencias</Card.Title>
                            </Card.Header>
                            <Card.Body className='px-0 py-2'>
                                <Button variant="link" onClick={() => history.push(`/cuentas/${id}/expreso`)} ><i className="feather icon-zap" />Expreso</Button>
                                <br />
                                <Button variant="link" onClick={() => history.push(`/cuentas/${id}/beneficiarios`)}><i className="feather icon-users" />Cuenta de beneficiario</Button>
                                <br />
                                <Button variant="link" onClick={() => history.push(`/cuentas/${id}/miscuentas`)}><i className="feather icon-credit-card" />Entre mis cuentas</Button>
                                <br />
                                <Button variant="link"><i className="feather icon-home" />Otros bancos</Button>
                            </Card.Body>
                        </Card>
                    </Col>
                </Row>
            </Aux>
        </>
    );
}

export default Cuenta;
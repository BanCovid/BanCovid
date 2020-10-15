import React from 'react';
import { Button, Card, Col, Row } from 'react-bootstrap';
import { isDate } from 'util';
import UcFirst from '../../App/components/UcFirst';
import { CuentaModel } from '../../models/CuentaModel';
import { dateShortFormat, moneyFormat } from '../../utils';

interface IComprobanteProps {
    miCuenta: CuentaModel;
    cuentaDestino: CuentaModel;
    monto: number;
    onCancel: () => void;
}

const Comprobante: React.FC<IComprobanteProps> = ({ miCuenta, cuentaDestino, monto, onCancel }) => {
    return (
        <Row style={{ justifyContent: 'center', marginTop: '50px' }}>
            <Col md={4}>
                <Card>
                    <Card.Header>
                        <Card.Title as="h5">COMPROBANTE</Card.Title>
                    </Card.Header>
                    <Card.Body className='border-bottom'>
                        <div className="row d-flex align-items-center">
                            <div className="col-auto">
                                <i className="feather icon-users f-30 text-c-blue" />
                            </div>
                            <div className="col">
                                <span className="d-block text-uppercase">Mi Cuenta (NO.)</span>
                                <h4 className="f-w-300">{miCuenta.NoCuenta}</h4>
                                <h6 className="f-w-300 text-uppercase" style={{ marginTop: '12px' }}>{miCuenta.Titular}</h6>
                            </div>
                            <div className="col">
                                <span className="d-block text-uppercase">Cuenta Destino (NO.)</span>
                                <h4 className="f-w-300">{cuentaDestino.NoCuenta}</h4>
                                <h6 className="f-w-300 text-uppercase" style={{ marginTop: '12px' }}>{cuentaDestino.Titular}</h6>
                            </div>
                        </div>
                    </Card.Body>
                    <Card.Body className='border-bottom'>
                        <div className="row d-flex align-items-center">
                            <div className="col-auto">
                                <i className="feather icon-credit-card f-30 text-c-green" />
                            </div>
                            <div className="col">
                                <span className="d-block text-uppercase">Monto a transferir</span>
                                <h3 className="f-w-300">{moneyFormat(monto)}</h3>
                            </div>
                            <div className="col">
                                <span className="d-block text-uppercase">Impuestos generados</span>
                                <h3 className="f-w-300">{moneyFormat(monto * 0.015)}</h3>
                            </div>
                        </div>
                    </Card.Body>

                    <Card.Body className='border-bottom'>
                        <div className="row d-flex">
                            <div className="col" style={{ textAlign: 'right' }}>
                                <span className="d-block text-uppercase">Fecha de transferencia</span>
                                <h4 className="f-w-300">{dateShortFormat(new Date())}</h4>
                            </div>
                        </div>
                    </Card.Body>
                </Card>
                <div style={{ textAlign: 'right' }}>
                    <Button variant="dark" onClick={onCancel} ><UcFirst text={"Cancelar"} /></Button>
                    <Button variant="primary"><UcFirst text={"Confirmar transferencia"} /></Button>
                </div>
            </Col>
        </Row>
    );
}

export default Comprobante;
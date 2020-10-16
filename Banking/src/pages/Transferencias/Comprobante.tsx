import React, { useState } from 'react';
import { Button, Card, Col, Row, Spinner, Toast } from 'react-bootstrap';
import { useHistory } from 'react-router-dom';
import { isDate } from 'util';
import UcFirst from '../../App/components/UcFirst';
import Images from '../../assets/images';
import { CuentaModel } from '../../models/CuentaModel';
import transferenciaService from '../../services/transferenciaService';
import { dateShortFormat, moneyFormat } from '../../utils';

interface IComprobanteProps {
    miCuenta: CuentaModel;
    cuentaDestino: CuentaModel;
    monto: number;
    onCancel: () => void;
}

const Comprobante: React.FC<IComprobanteProps> = ({ miCuenta, cuentaDestino, monto, onCancel }) => {
    const history = useHistory();
    const [show, setShow] = useState<boolean>(false);
    const [showError, setShowError] = useState<boolean>(false);
    const [loading, setLoading] = useState<boolean>(false);
    const [loadingText, setLoadingText] = useState<string>(' Transfiriendo..');
    const [errorMessage, setErrorMessage] = useState<string>('');

    const onConfirm = () => {
        setLoading(true);
        transferenciaService.interna({
            Cuenta: miCuenta.NoCuenta,
            CuentaDestino: cuentaDestino.NoCuenta,
            Monto: monto
        }).then(() => {
            setLoadingText(' Redireccionando..');
            setShow(true);
            setTimeout(() => {
                history.push('/cuentas');
            }, 3000);
        }).catch((err) => {
            console.error(err);
            setShowError(true);
            setLoadingText(' Error producido..');
            setErrorMessage(err.Message);
        });
    };

    return (
        <div aria-live="polite"
            aria-atomic="true"
            style={{
                position: 'relative',
                minHeight: '200px',
            }}>
            <Row style={{ justifyContent: 'center', marginTop: '50px' }}>
                <Col md={5}>
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
                                <div className="col">
                                    <span className="d-block text-uppercase">Total</span>
                                    <h4 className="f-w-300">{moneyFormat(monto + (monto * 0.015))}</h4>
                                </div>
                                <div className="col" style={{ textAlign: 'right' }}>
                                    <span className="d-block text-uppercase">Fecha de transferencia</span>
                                    <h4 className="f-w-300">{dateShortFormat(new Date())}</h4>
                                </div>
                            </div>
                        </Card.Body>
                    </Card>
                    <div style={{ textAlign: 'right' }}>
                        <Button variant="dark" onClick={onCancel} ><UcFirst text={"Cancelar"} /></Button>
                        <Button variant="primary" onClick={onConfirm} disabled={loading}>
                            <Spinner
                                as="span"
                                animation="border"
                                size="sm"
                                role="status"
                                aria-hidden="true"
                                style={{ display: (loading) ? 'inline-block' : 'none' }}
                            />
                            <UcFirst text={(loading) ? loadingText : "Confirmar transferencia"} />
                        </Button>
                    </div>
                </Col>
            </Row>
            <div
                style={{
                    position: 'absolute',
                    top: 0,
                    right: 0,
                    width: '300px'
                }}
            >
                <Toast onClose={() => setShow(false)} show={show}>
                    <Toast.Header closeButton={false} style={{ backgroundColor: 'rgb(63 77 103)', color: 'white' }}>
                        <img src={Images.LogoCircular} height={50} className="rounded mr-2" alt="" />
                        <strong className="mr-auto">BanCovid</strong>
                        <small>justo ahora</small>
                    </Toast.Header>
                    <Toast.Body>La transacción se realizo correctamente (redireccionando).</Toast.Body>
                </Toast>
                <Toast onClose={() => setShowError(false)} show={showError}>
                    <Toast.Header style={{ backgroundColor: 'rgb(203, 67, 53)', color: 'white' }}>
                        <img src={Images.LogoCircular} height={50} className="rounded mr-2" alt="" />
                        <strong className="mr-auto">Se ha producido un error</strong>
                        <small>justo ahora</small>
                    </Toast.Header>
                    <Toast.Body>{errorMessage}</Toast.Body>
                </Toast>
            </div>
        </div>
    );
}

export default Comprobante;
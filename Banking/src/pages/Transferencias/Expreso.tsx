import React, { useEffect, useState } from 'react';
import { Button, Card, Col, Form, Row, Spinner } from 'react-bootstrap';
import { useHistory, useRouteMatch } from 'react-router-dom';
import Breadcrumb from '../../App/components/Breadcrumb';
import ErrorSection from '../../App/components/ErrorSection';
import UcFirst from '../../App/components/UcFirst';
import Aux from '../../hoc/_Aux';
import { CuentaModel } from '../../models/CuentaModel';
import { TransferenciaModelo } from '../../models/TransferenciaModel';
import cuentasService from '../../services/cuentasService';
import { moneyFormat } from '../../utils';
import Comprobante from './Comprobante';

const Expreso = () => {
    const history = useHistory();
    const match = useRouteMatch();
    const { id }: any = match.params;

    const [agree, setAgree] = useState<boolean>(false);
    const [errors, setErrors] = useState<string[]>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const [comprobanteActivado, setComprobanteActivado] = useState<boolean>(false);
    const [miCuenta, setMiCuenta] = useState<CuentaModel>({} as CuentaModel);
    const [cuentaDestino, setCuentaDestino] = useState<CuentaModel>({} as CuentaModel);

    const [formModel, setFormModel] = useState<TransferenciaModelo>({
        Monto: 0,
        CuentaDestino: '',
        Cuenta: id
    } as TransferenciaModelo);


    useEffect(() => {
        cuentasService.obtener(id)
            .then((data) => {
                setMiCuenta(data);
            })
            .catch((data) => {
                history.push('/cuentas');
            });
    }, []);

    const handleInputChange = ({ target }: any) => {
        setFormModel(prev => ({ ...prev, [target.id]: target.value }));
    };

    const onSubmit = async (e: any) => {
        e.preventDefault();
        setLoading(true);
        let errorsList: string[] = [];

        if (!formModel.CuentaDestino)
            errorsList.push('Debe seleccionar una cuenta a la cual transferir');
        else {

            if (miCuenta.NoCuenta === formModel.CuentaDestino)
                errorsList.push('No puedes transferir a tu misma cuenta');
            else {
                await cuentasService.obtener(formModel.CuentaDestino)
                    .then((data) => {
                        setCuentaDestino(data);
                    })
                    .catch((data) => {
                        errorsList.push('La cuenta a la que desea transferir no existe');
                    });
            }
        }
        if (!formModel.Monto)
            errorsList.push('Debe seleccionar un monto a transferir');

        if (miCuenta.Monto < formModel.Monto)
            errorsList.push(`El monto que desea transferir no esta disponible (${moneyFormat(parseFloat(formModel.Monto.toString()))})`);

        setErrors(errorsList);

        setTimeout(() => {
            setLoading(false)
            if (errorsList.length === 0) {
                setComprobanteActivado(true);
            }
        }, 1000);
    };

    return (
        <>
            <Breadcrumb
                title={`Transferencia expreso`}
                items={[{
                    name: 'Cuentas',
                    path: '/cuentas',
                    isActive: false
                }, {
                    name: `Cuenta No. ${id}`,
                    path: `/cuentas/${id}`,
                    isActive: false
                }, {
                    name: `Transferencia expreso`,
                    path: `/cuentas/${id}/expreso`,
                    isActive: true
                }]}
            />
            <Aux>
                {!comprobanteActivado ? (
                    <Row>
                        <Card style={{ width: '100%' }}>
                            <Form onSubmit={onSubmit}>
                                <Card.Header>
                                    <Card.Title as="h5">Datos de transferencia</Card.Title>
                                </Card.Header>
                                <Card.Body>
                                    <Row>
                                        <Col md={6}>
                                            <h5>Información de mi cuenta</h5>
                                            <hr />
                                            <Form.Group controlId="NoCuenta">
                                                <Form.Label>Mi Cuenta</Form.Label>
                                                <Form.Control value={`Cuenta No. ${miCuenta.NoCuenta}`} disabled />
                                                <Form.Text className="text-muted">
                                                    <b>Atención:</b> La información de la cuenta no debe ser compartida.
                                                </Form.Text>
                                            </Form.Group>
                                            <Form.Group controlId="Balance">
                                                <Form.Label>Balance Actual</Form.Label>
                                                <Form.Control value={`${moneyFormat(miCuenta.Monto)}`} disabled />
                                            </Form.Group>
                                        </Col>
                                        <Col md={6}>
                                            <h5>Información de cuenta destino</h5>
                                            <hr />
                                            <Form.Group controlId="CuentaDestino" style={{ marginBottom: '2.2rem' }}>
                                                <Form.Label>Cuenta a Transferir</Form.Label>
                                                <Form.Control type="number" onChange={handleInputChange} value={formModel.CuentaDestino} />
                                            </Form.Group>
                                            <Form.Group controlId="Monto">
                                                <Form.Label>Monto a transferir</Form.Label>
                                                <Form.Control lang="en" type="number" onChange={handleInputChange} value={formModel.Monto.toString()} />
                                            </Form.Group>
                                            <Form.Group>
                                                <Form.Check
                                                    custom
                                                    type="checkbox"
                                                    id="agree"
                                                    label="(Si, estoy de acuerdo) La transferencia se efectuara por un costo de 0.15%"
                                                    checked={agree}
                                                    onChange={() => setAgree(prev => !prev)}
                                                />
                                            </Form.Group>
                                            <Form.Group style={{ textAlign: 'right' }}>
                                                <Button type="submit" variant="secondary" disabled={!agree || loading}>
                                                    <Spinner
                                                        as="span"
                                                        animation="border"
                                                        size="sm"
                                                        role="status"
                                                        aria-hidden="true"
                                                        style={{display: (loading)? 'inline-block' : 'none'}}
                                                    />
                                                    <UcFirst text={(loading) ? " Validando.. " : "Realizar transferencia"} />
                                                </Button>
                                            </Form.Group>
                                        </Col>
                                    </Row>
                                    <Row>
                                        <Col md={12}>
                                            <ErrorSection errors={errors} />
                                        </Col>
                                    </Row>
                                </Card.Body>
                            </Form>
                        </Card>

                    </Row>
                ) : (
                        <Comprobante
                            miCuenta={miCuenta}
                            cuentaDestino={cuentaDestino}
                            monto={parseFloat(formModel.Monto.toString())}
                            onCancel={() => setComprobanteActivado(false)}
                        />
                    )}
            </Aux>
        </>
    );
}

export default Expreso;
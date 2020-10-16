import React, { useEffect, useState } from 'react';
import { Button, Card, Col, Form, Row, Spinner, Table, Toast } from 'react-bootstrap';
import Breadcrumb from '../../App/components/Breadcrumb';
import ErrorSection from '../../App/components/ErrorSection';
import UcFirst from '../../App/components/UcFirst';
import Images from '../../assets/images';
import Aux from '../../hoc/_Aux';
import { BeneficiarioModel } from '../../models/BeneficiarioModel';
import beneficiariosService from '../../services/beneficioService';
import cuentasService from '../../services/cuentasService';
import { dateLongFormat } from '../../utils';


import avatar1 from '../../assets/images/user/avatar-2.jpg';
import DEMO from '../../store/constant';

const Beneficiarios = () => {

    const [show, setShow] = useState<boolean>(false);
    const [edit, setEdit] = useState<boolean>(false);
    const [errors, setErrors] = useState<string[]>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const [formModel, setFormModel] = useState<BeneficiarioModel>({
        CuentaDestino: '',
        Alias: '',
        Titular: '',
        Aprobado: false
    } as BeneficiarioModel);

    const [beneficiarios, setBeneficiarios] = useState<BeneficiarioModel[]>([]);

    const cargarBeneficiarios = () => {
        beneficiariosService.obtenerTodos()
            .then(data => {
                setBeneficiarios(data);
            })
            .catch();
    }

    useEffect(() => {
        cargarBeneficiarios();
    }, [])

    const onChangeCuenta = ({ target }: any) => {
        if (target.value) {
            cuentasService.obtener(target.value)
                .then((data) => {
                    setFormModel(prev => ({ ...prev, Titular: data.Titular, Aprobado: true }));
                    setErrors([]);
                })
                .catch((data) => {
                    setErrors(['La cuenta de beneficiario no existe']);
                });
        }
    }

    const onFocusCuenta = () => {
        setFormModel(prev => ({ ...prev, Aprobado: false }));
    }

    const handleInputChange = ({ target }: any) => {
        setFormModel(prev => ({ ...prev, [target.id]: target.value }));
    };

    const onSubmit = (e: any) => {
        e.preventDefault();

        if (edit) {
            beneficiariosService.editar(formModel)
                .then(() => {
                    setShow(true);
                    setTimeout(() => {
                        setFormModel({
                            CuentaDestino: '',
                            Alias: '',
                            Titular: '',
                            Aprobado: false
                        } as BeneficiarioModel);
                        cargarBeneficiarios();
                        setEdit(false);
                    }, 1000);
                })
                .catch(res => {
                    if (res.response.data && res.response.data.Message)
                        setErrors([res.response.data.Message]);
                })
                .finally(() => setTimeout(() => {
                    setLoading(false)
                }, 2000));
            return;
        }

        if (!formModel.CuentaDestino)
            setErrors(['Debe seleccionar una cuenta para agregar']);

        if (!formModel.Aprobado)
            setErrors(['Se requiere una cuenta valida']);
        else {
            setLoading(true);
            beneficiariosService.crear(formModel)
                .then(() => {
                    setShow(true);
                    setTimeout(() => {
                        setFormModel({
                            CuentaDestino: '',
                            Alias: '',
                            Titular: '',
                            Aprobado: false
                        } as BeneficiarioModel);
                        cargarBeneficiarios();
                    }, 1000);
                })
                .catch(res => {
                    if (res.response.data && res.response.data.Message)
                        setErrors([res.response.data.Message]);
                })
                .finally(() => setTimeout(() => {
                    setLoading(false)
                }, 2000));
        }
    }
    return (
        <>
            <Breadcrumb
                title={`Gestionar Beneficiarios`}
                items={[{
                    name: 'Beneficiarios',
                    path: '/beneficiarios',
                    isActive: true
                }]}
            />
            <Aux>
                <Row>
                    <Col md={8}>
                        <Card className='Recent-Users'>
                            <Card.Header>
                                <Card.Title as='h5'>Mis Beneficiarios</Card.Title>
                            </Card.Header>
                            <Card.Body className='px-0 py-2'>
                                <Table responsive hover>
                                    <tbody>
                                        {beneficiarios.map((item, index) => (
                                            <tr className="unread" key={index}>
                                                <td><img className="rounded-circle" style={{ width: '40px' }} src={avatar1} alt="activity-user" /></td>
                                                <td>
                                                    <h6 className="mb-1">{item.Titular}</h6>
                                                    <p className="m-0">{item.Alias}</p>
                                                </td>
                                                <td>Cuenta No.{item.CuentaDestino}</td>
                                                <td>
                                                    <h6 className="text-muted">
                                                        {item.Estado === 0 && (
                                                            <i className="fa fa-circle text-c-red f-10 m-r-15" />
                                                        )}
                                                        {item.Estado === 1 && (
                                                            <i className="fa fa-circle text-c-blue f-10 m-r-15" />
                                                        )}
                                                        {dateLongFormat(new Date(item.FechaCreacion!))}
                                                    </h6>
                                                </td>
                                                <td>
                                                    {item.Estado === 0 && (
                                                        <label className="label theme-bg1 text-white f-12">Inactivo</label>
                                                    )}
                                                    {item.Estado === 1 && (
                                                        <label className="label theme-bg2 text-white f-12">Activo</label>
                                                    )}
                                                </td>
                                                <td>
                                                    <a
                                                        onClick={(e) => {
                                                            e.preventDefault();
                                                            setFormModel({
                                                                CuentaDestino: item.CuentaDestino,
                                                                Alias: item.Alias,
                                                                Titular: item.Titular,
                                                                Aprobado: true
                                                            } as BeneficiarioModel);
                                                            setEdit(true);
                                                        }}
                                                        href={DEMO.BLANK_LINK}
                                                        className="label theme-bg text-white f-12"
                                                    >
                                                        <i className="feather icon-edit-2" />
                                                    </a>
                                                    <a href={DEMO.BLANK_LINK} className="label theme-bg1 text-white f-12">
                                                        <i className="feather icon-trash-2" />
                                                    </a>
                                                </td>
                                            </tr>
                                        ))}
                                    </tbody>
                                </Table>
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col md={4}>
                        <Card style={{ width: '100%' }}>
                            <Form onSubmit={onSubmit}>
                                <Card.Header>
                                    <Card.Title as="h5">Formulario de beneficiario</Card.Title>
                                </Card.Header>
                                <Card.Body>
                                    <Row>
                                        <Col md={12}>
                                            <Form.Group controlId="CuentaDestino">
                                                <Form.Label>No. Cuenta</Form.Label>
                                                <Form.Control onChange={handleInputChange} value={formModel.CuentaDestino} type="number" onFocus={onFocusCuenta} onBlur={onChangeCuenta} disabled={edit} />
                                            </Form.Group>
                                            <Form.Group controlId="Titular">
                                                <Form.Label>Titular de la cuenta</Form.Label>
                                                <Form.Control onChange={handleInputChange} value={formModel.Titular} disabled />
                                            </Form.Group>
                                            <Form.Group controlId="Alias">
                                                <Form.Label>Alias</Form.Label>
                                                <Form.Control onChange={handleInputChange} value={formModel.Alias} />
                                            </Form.Group>
                                            <Form.Group style={{ textAlign: 'right' }}>
                                                {(edit && (
                                                    <Button
                                                        variant="light"
                                                        disabled={loading}
                                                        onClick={() => {
                                                            setFormModel({
                                                                CuentaDestino: '',
                                                                Alias: '',
                                                                Titular: '',
                                                                Aprobado: false
                                                            } as BeneficiarioModel);
                                                            setEdit(false);
                                                        }}
                                                    >
                                                        <UcFirst text={"Cancel"} />
                                                    </Button>
                                                ))}
                                                <Button type="submit" variant="secondary" disabled={loading}>
                                                    <Spinner
                                                        as="span"
                                                        animation="border"
                                                        size="sm"
                                                        role="status"
                                                        aria-hidden="true"
                                                        style={{ display: (loading) ? 'inline-block' : 'none' }}
                                                    />
                                                    <UcFirst text={(loading) ? " Validando.. " : "Guardar"} />
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

                    </Col>

                </Row>
                <div aria-live="polite"
                    aria-atomic="true"
                    style={{
                        position: 'relative',
                        minHeight: '200px',
                    }}>
                    <div
                        style={{
                            position: 'absolute',
                            top: 0,
                            right: 0,
                            width: '400px'
                        }}
                    >
                        <Toast onClose={() => setShow(false)} show={show} delay={5000} autohide>
                            <Toast.Header style={{ backgroundColor: 'rgb(63 77 103)', color: 'white' }}>
                                <img src={Images.LogoCircular} height={50} className="rounded mr-2" alt="" />
                                <strong className="mr-auto">BanCovid</strong>
                                <small>justo ahora</small>
                            </Toast.Header>
                            <Toast.Body>
                                {edit ?
                                    "El beneficiario se ha editado correctamente." :
                                    "El beneficiario se ha creado correctamente."
                                }
                            </Toast.Body>
                        </Toast>
                    </div>
                </div>
            </Aux>

        </>
    );
}

export default Beneficiarios;
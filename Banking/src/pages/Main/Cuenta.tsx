import React from 'react';
import { Button, Card, Col, Row, Table } from 'react-bootstrap';
import { useHistory, useRouteMatch } from 'react-router-dom';
import Breadcrumb from '../../App/components/Breadcrumb';
import Aux from '../../hoc/_Aux';
import DEMO from '../../store/constant';


import avatar1 from '../../assets/images/user/avatar-1.jpg';
import avatar2 from '../../assets/images/user/avatar-2.jpg';
import avatar3 from '../../assets/images/user/avatar-3.jpg';
import { moneyFormat } from '../../utils';


const Cuenta: React.FC = () => {
    const history = useHistory();
    const match = useRouteMatch();
    const { id }: any = match.params;

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
                                        <h3 className="f-w-300 d-flex align-items-center m-b-0"><i className="feather icon-credit-card f-30 m-r-5" /> {moneyFormat(249.95)}</h3>
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
                                        <h3 className="f-w-300 d-flex align-items-center m-b-0"><i className="feather icon-arrow-up text-c-green f-30 m-r-5" /> $8.638.32</h3>
                                    </div>

                                    <div className="col-3 text-right">
                                        <p className="m-b-0">70%</p>
                                    </div>
                                </div>
                                <div className="progress m-t-30" style={{ height: '7px' }}>
                                    <div className="progress-bar progress-c-theme" role="progressbar" style={{ width: '70%' }} aria-valuenow={70} aria-valuemin={0} aria-valuemax={100} />
                                </div>
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col md={6} xl={4}>
                        <Card>
                            <Card.Body>
                                <h6 className='mb-4'>Diferencia desde último corte</h6>
                                <div className="row d-flex align-items-center">
                                    <div className="col-9">
                                        <h3 className="f-w-300 d-flex align-items-center m-b-0"><i className="feather icon-arrow-down text-c-red f-30 m-r-5" /> {moneyFormat(2149.95)}</h3>
                                    </div>

                                    <div className="col-3 text-right">
                                        <p className="m-b-0">-12%</p>
                                    </div>
                                </div>
                                <div className="progress m-t-30" style={{ height: '7px' }}>
                                    <div className="progress-bar progress-c-theme2" role="progressbar" style={{ width: '35%' }} aria-valuenow={35} aria-valuemin={0} aria-valuemax={100} />
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
                                        <tr className="unread">
                                            <td><img className="rounded-circle" style={{ width: '40px' }} src={avatar1} alt="activity-user" /></td>
                                            <td>
                                                <h6 className="mb-1">Isabella Christensen</h6>
                                                <p className="m-0">Transferencia a cuenta no. 1098333123</p>
                                            </td>
                                            <td>
                                                <h6 className="text-muted"><i className="fa fa-circle text-c-green f-10 m-r-15" />11 MAY 12:56</h6>
                                            </td>
                                            <td><a href={DEMO.BLANK_LINK} className="label theme-bg2 text-white f-12">Reject</a><a href={DEMO.BLANK_LINK} className="label theme-bg text-white f-12">Approve</a></td>
                                        </tr>
                                        <tr className="unread">
                                            <td><img className="rounded-circle" style={{ width: '40px' }} src={avatar2} alt="activity-user" /></td>
                                            <td>
                                                <h6 className="mb-1">Mathilde Andersen</h6>
                                                <p className="m-0">Lorem Ipsum is simply dummy text of…</p>
                                            </td>
                                            <td>
                                                <h6 className="text-muted"><i className="fa fa-circle text-c-red f-10 m-r-15" />11 MAY 10:35</h6>
                                            </td>
                                            <td><a href={DEMO.BLANK_LINK} className="label theme-bg2 text-white f-12">Reject</a><a href={DEMO.BLANK_LINK} className="label theme-bg text-white f-12">Approve</a></td>
                                        </tr>
                                        <tr className="unread">
                                            <td><img className="rounded-circle" style={{ width: '40px' }} src={avatar3} alt="activity-user" /></td>
                                            <td>
                                                <h6 className="mb-1">Karla Sorensen</h6>
                                                <p className="m-0">Lorem Ipsum is simply dummy text of…</p>
                                            </td>
                                            <td>
                                                <h6 className="text-muted"><i className="fa fa-circle text-c-green f-10 m-r-15" />9 MAY 17:38</h6>
                                            </td>
                                            <td><a href={DEMO.BLANK_LINK} className="label theme-bg2 text-white f-12">Reject</a><a href={DEMO.BLANK_LINK} className="label theme-bg text-white f-12">Approve</a></td>
                                        </tr>
                                        <tr className="unread">
                                            <td><img className="rounded-circle" style={{ width: '40px' }} src={avatar1} alt="activity-user" /></td>
                                            <td>
                                                <h6 className="mb-1">Ida Jorgensen</h6>
                                                <p className="m-0">Lorem Ipsum is simply dummy text of…</p>
                                            </td>
                                            <td>
                                                <h6 className="text-muted f-w-300"><i className="fa fa-circle text-c-red f-10 m-r-15" />19 MAY 12:56</h6>
                                            </td>
                                            <td><a href={DEMO.BLANK_LINK} className="label theme-bg2 text-white f-12">Reject</a><a href={DEMO.BLANK_LINK} className="label theme-bg text-white f-12">Approve</a></td>
                                        </tr>
                                        <tr className="unread">
                                            <td><img className="rounded-circle" style={{ width: '40px' }} src={avatar2} alt="activity-user" /></td>
                                            <td>
                                                <h6 className="mb-1">Albert Andersen</h6>
                                                <p className="m-0">Lorem Ipsum is simply dummy text of…</p>
                                            </td>
                                            <td>
                                                <h6 className="text-muted"><i className="fa fa-circle text-c-green f-10 m-r-15" />21 July 12:56</h6>
                                            </td>
                                            <td><a href={DEMO.BLANK_LINK} className="label theme-bg2 text-white f-12">Reject</a><a href={DEMO.BLANK_LINK} className="label theme-bg text-white f-12">Approve</a></td>
                                        </tr>
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
                                <Button variant="link"><i className="feather icon-users" />Cuenta de tercero</Button>
                                <br />
                                <Button variant="link"><i className="feather icon-credit-card" />Entre mis cuentas</Button>
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
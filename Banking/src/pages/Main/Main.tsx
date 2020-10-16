import React, { useEffect, useState } from 'react';
import Aux from '../../hoc/_Aux';
import DEMO from '../../store/constant';
import { Card, Col, Row, Table } from 'react-bootstrap';
import cuentasService from '../../services/cuentasService';
import { CuentaModel } from '../../models/CuentaModel';
import { useHistory } from 'react-router-dom';
import Breadcrumb from '../../App/components/Breadcrumb';
import { dateShortFormat, moneyFormat } from '../../utils';

const Main: React.FC = () => {
    const [cuentas, setCuentas] = useState<CuentaModel[]>([]);
    const history = useHistory();

    useEffect(() => {
        cuentasService.obtenerTodas()
            .then((cuentas) => {
                setCuentas(cuentas);
            })
    }, []);


    return (
        <>
            <Breadcrumb
                title="Cuentas"
                items={[{
                    name: 'Cuentas',
                    path: '/cuentas',
                    isActive: true
                }]}
            />
            <Aux>
                <Row>
                    {cuentas.map(item => (
                        <Col md={6} xl={4} key={item.NoCuenta}>
                            <Card className='card-account'>
                                <Card.Body>
                                    <div className="row align-items-center justify-content-center">
                                        <div className="col">
                                            <h4 className="m-0">No. cuenta</h4>
                                        </div>
                                        <div className="col-auto">
                                            <h5 className="m-0">{item.NoCuenta}</h5>
                                        </div>
                                    </div>
                                    <div className="row align-items-center available-money">
                                        <div className="col">
                                            <h3 className="mt-2 f-w-300">{moneyFormat(item.Monto)}
                                                <sub className="text-muted f-14">Balance Disponible</sub>
                                            </h3>
                                        </div>
                                    </div>
                                    <h6 className="text-muted mt-3 mb-0">Creada: {dateShortFormat(new Date(item.FechaCreacion))}</h6>
                                    <a
                                        onClick={(e) => {
                                            e.preventDefault();
                                            history.push(`/cuentas/${item.NoCuenta}`)
                                        }}
                                        href={DEMO.BLANK_LINK}
                                        className="label theme-bg2 text-white f-12">
                                        Elegir <b>&gt;</b>
                                    </a>
                                </Card.Body>
                            </Card>
                        </Col>
                    ))}

                </Row>
            </Aux>

        </>
    );
}

export default Main;
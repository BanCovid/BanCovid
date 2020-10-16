import React from 'react';
import { Link } from 'react-router-dom';
import Aux from '../../hoc/_Aux';
import DEMO from '../../store/constant';

interface IBreadcumbProps {
    title: string;
    items: {
        name: string;
        path: string;
        isActive: boolean;
    }[];
}

const Breadcrumb: React.FC<IBreadcumbProps> = ({ title, items }) => {
    var item = (
        <li className="breadcrumb-item">
            <a href={DEMO.BLANK_LINK}>{title}</a>
        </li>
    );

    document.title = title + ' | BanCovid';
    return (
        <Aux>
            <div className="page-header">
                <div className="page-block">
                    <div className="row align-items-center">
                        <div className="col-md-12">
                            <div className="page-header-title">
                                <h3 className="m-b-10">{title}</h3>
                            </div>

                            <ul className="breadcrumb">
                                <li className="breadcrumb-item">
                                    <Link to="/cuentas"><i className="feather icon-home" /></Link>
                                </li>
                                {items.map(item => (
                                    <li key={item.name} className={`breadcrumb-item` + (item.isActive ? ' active' : '')}>
                                        <Link to={item.path}>{item.name}</Link>
                                    </li>
                                ))}
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </Aux>
    );
}

export default Breadcrumb;
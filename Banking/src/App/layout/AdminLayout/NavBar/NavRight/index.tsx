import React, { Component, useState } from 'react';
import { Dropdown } from 'react-bootstrap';

import ChatList from './ChatList';
import Aux from "../../../../../hoc/_Aux";
import DEMO from "../../../../../store/constant";

import Avatar1 from '../../../../../assets/images/user/avatar-1.jpg';
import Avatar2 from '../../../../../assets/images/user/avatar-2.jpg';
import Avatar3 from '../../../../../assets/images/user/avatar-3.jpg';
import authService from '../../../../../services/authService';
import { useHistory } from 'react-router-dom';

const NavRight: React.FC<any> = ({rtlLayout}) => {
    const [listOpen, setListOpen] = useState<Boolean>(false)
    const history = useHistory();
    
    return (
        <Aux>
            <ul className="navbar-nav ml-auto">
                <li>
                    <Dropdown alignRight={rtlLayout} className="drp-user">
                        <Dropdown.Toggle variant={'link'} id="dropdown-basic">
                            <i className="icon feather icon-settings" />
                        </Dropdown.Toggle>
                        <Dropdown.Menu alignRight className="profile-notification">
                            <div className="pro-head">
                                <img src={Avatar2} className="img-radius" alt="User Profile" />
                                <span>{authService.userData.Nombre + ' ' + authService.userData.Apellido}</span>
                                <a href={DEMO.BLANK_LINK} className="dud-logout" title="Cerrar sesión" onClick={() => {
                                    authService.signOut();
                                    history.push('/auth/sign_in');
                                }}>
                                    <i className="feather icon-log-out" />
                                </a>
                            </div>
                            <ul className="pro-body">
                                <li><a href={DEMO.BLANK_LINK} className="dropdown-item"><i className="feather icon-user" /> Perfil</a></li>
                                <li><a href={DEMO.BLANK_LINK} className="dropdown-item"><i className="feather icon-settings" /> Configuración</a></li>
                            </ul>
                        </Dropdown.Menu>
                    </Dropdown>
                </li>
            </ul>
            <ChatList listOpen={listOpen} closed={() => { setListOpen(false); }} />
        </Aux>
    );
}

export default NavRight;

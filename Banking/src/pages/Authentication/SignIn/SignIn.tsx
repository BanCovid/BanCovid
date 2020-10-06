import React, { useState } from 'react';
import { NavLink, useHistory } from 'react-router-dom';

import '../../../assets/scss/style.scss';
import Aux from "../../../hoc/_Aux";
import Breadcrumb from "../../../App/layout/AdminLayout/Breadcrumb";
import Images from '../../../assets/images';
import { UserModel } from '../../../models/UserModel';
import authService from '../../../services/authService';

const ErrorSection: React.FC<{ errors: string[] | undefined }> = ({ errors }) => {
    if (!errors || !errors.length)
        return null;

    return (
        <div className="form-errors-section">
            <div className="icon-section">
                <i className="feather icon-alert-circle" />
            </div>
            <div className="errors-section">
                <label>Errores producidos</label>
                <ul>
                    {errors.map((item, index) => (
                        <li key={index}>{item}</li>
                    ))}
                </ul>
            </div>
        </div>
    );
}

const SignIn: React.FC = () => {
    const history = useHistory();
    const [model, setModel] = useState<UserModel>({} as UserModel);
    const [errors, setErrors] = useState<string[]>([]);

    const onSubmit = () => {
        authService.signIn(model)
            .then(() => {
                history.push('/');
            })
            .catch(() => {
                setErrors(['Usuario o contraseña incorrecto']);
            });
    }

    console.log(errors);
    return (
        <Aux>
            <Breadcrumb />
            <div className="auth-wrapper">
                <div className="auth-content">
                    <div className="auth-bg">
                        <span className="r" />
                        <span className="r s" />
                        <span className="r s" />
                        <span className="r" />
                    </div>

                    <img src={Images.LogoWithSlogan} className="logo-img" />
                    <div className="card">
                        <div className="card-body text-center">
                            <div className="mb-4">
                                <i className="feather icon-unlock auth-icon" />
                            </div>
                            <h3 className="mb-4">Iniciar sesión</h3>
                            <div className="input-group mb-3">
                                <input
                                    type="email"
                                    className="form-control"
                                    placeholder="Usuario"
                                    onChange={({ target }) => setModel(prev => ({ ...prev, UserName: target.value }))}
                                />
                            </div>
                            <div className="input-group mb-4">
                                <input
                                    type="password"
                                    className="form-control"
                                    placeholder="Contraseña"
                                    onChange={({ target }) => setModel(prev => ({ ...prev, Password: target.value }))}
                                />
                            </div>
                            <div className="form-group text-left">
                                <div className="checkbox checkbox-fill d-inline">
                                    <input type="checkbox" name="checkbox-fill-1" id="checkbox-fill-a1" />
                                    <label htmlFor="checkbox-fill-a1" className="cr"> Recordar credenciales</label>
                                </div>
                            </div>
                            <button onClick={onSubmit} className="btn btn-primary shadow-2">Entrar</button>
                            <ErrorSection errors={errors} />
                            {/* <p className="mb-2 text-muted">Forgot password? <NavLink to="/auth/reset-password-1">Reset</NavLink></p>
                            <p className="mb-0 text-muted">Don’t have an account? <NavLink to="/auth/signup-1">Signup</NavLink></p> */}
                        </div>
                    </div>
                </div>
            </div>
        </Aux>
    );
}

export default SignIn;
import React, { Component, Suspense, useState } from 'react';
import { Switch, Route, Redirect } from 'react-router-dom';
import Loadable from 'react-loadable';

import '../../node_modules/font-awesome/scss/font-awesome.scss';

import Loader from './layout/Loader'
import Aux from "../hoc/_Aux";
import ScrollToTop from './layout/ScrollToTop';
import routes from "../route";
import authService from "../services/authService";

const SignIn = React.lazy(() => import('../pages/Authentication/SignIn/SignIn'));

const AdminLayout = Loadable({
    loader: () => import('./layout/AdminLayout'),
    loading: Loader
});


const GuestRoutes = () => {
    const [h, setH] = useState('hola');
    return (
        <Switch>
            <Route exact path={'/auth/sign_in'} component={SignIn} />
            <Redirect to="/auth/sign_in" />
        </Switch>
    );
};

const App = () => {
    const menu = routes.map((route, index) => {
        return (route.component) ? (
            <Route
                key={index}
                path={route.path}
                exact={route.exact}
                //name={route.name}
                render={props => (
                    <route.component {...props} />
                )} />
        ) : (null);
    });
    return (
        <Aux>
            <ScrollToTop>
                <Suspense fallback={<Loader />}>
                    <Switch>
                        <Route
                            render={_ =>
                                authService.isAuthenticated ? (
                                    <>
                                        <Switch>
                                            {menu}
                                            <Route path="/" component={AdminLayout} />
                                        </Switch>
                                    </>
                                ) : (
                                        <Route path="*" component={GuestRoutes} />
                                    )
                            }
                        />
                    </Switch>
                </Suspense>
            </ScrollToTop>
        </Aux>
    );
}


export default App;

import axios from 'axios';
import { CuentaModel } from '../models/CuentaModel';
import authService from './authService';

const cuentasService = (() => {
    return ({
        obtenerTodas(): Promise<CuentaModel[]> {
            return new Promise<any>((resolve, reject) => {
                axios.get(`${process.env.REACT_APP_API_URL}/api/cuentas/ObtenerTodos?clienteId=${authService.userData.Id}`)
                    .then((res: any) => {
                        resolve(res.data);
                    })
                    .catch((err: any) => {
                        reject(err)
                    });
            });
        },
        obtener(noCuenta: string): Promise<CuentaModel> {
            return new Promise<any>((resolve, reject) => {
                axios.get(`${process.env.REACT_APP_API_URL}/api/cuentas/Obtener/${noCuenta}`)
                    .then((res: any) => {
                        resolve(res.data);
                    })
                    .catch((err: any) => {
                        reject(err)
                    });
            });
        }
    });
})();

export default cuentasService;
import axios from 'axios';
import { CuentaEstadisticasModel } from '../models/CuentaEstadisticasModel';
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
        },
        estadisticas(noCuenta: string): Promise<CuentaEstadisticasModel> {
            return new Promise<any>((resolve, reject) => {
                axios.get(`${process.env.REACT_APP_API_URL}/api/cuentas/estadisticas/${noCuenta}`)
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
import axios from 'axios';
import { CuentaModel } from '../models/CuentaModel';
import { TransferenciaModelo } from '../models/TransferenciaModel';

const transferenciaService = (() => {
    return ({
        interna(modelo: TransferenciaModelo): Promise<boolean> {
            return new Promise<any>((resolve, reject) => {
                axios.post(`${process.env.REACT_APP_API_URL}/api/transaccion/interna`, modelo)
                    .then((res: any) => {
                        resolve(res.data);
                    })
                    .catch((err: any) => {
                        reject(err)
                    });
            });
        },
        obtenerTodos(noCuenta: string): Promise<TransferenciaModelo[]> {
            return new Promise<any>((resolve, reject) => {
                axios.get(`${process.env.REACT_APP_API_URL}/api/transaccion/obtenerTodos?noCuenta=${noCuenta}`)
                    .then((res: any) => {
                        resolve(res.data);
                    })
                    .catch((err: any) => {
                        reject(err)
                    });
            });
        },
    });
})();

export default transferenciaService;
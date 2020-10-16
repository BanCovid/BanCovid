import axios from 'axios';
import { BeneficiarioModel } from '../models/BeneficiarioModel';
import authService from './authService';

const beneficiariosService = (() => {
    return ({
        crear(modelo: BeneficiarioModel): Promise<boolean> {
            return new Promise<any>((resolve, reject) => {
                modelo.ClienteId = authService.userData.Id;
                axios.post(`${process.env.REACT_APP_API_URL}/api/beneficiarios/crear`, modelo)
                    .then((res: any) => {
                        resolve(res.data);
                    })
                    .catch((err: any) => {
                        reject(err)
                    });
            });
        },
        editar(modelo: BeneficiarioModel): Promise<boolean> {
            return new Promise<any>((resolve, reject) => {
                modelo.ClienteId = authService.userData.Id;
                axios.put(`${process.env.REACT_APP_API_URL}/api/beneficiarios/editar`, modelo)
                    .then((res: any) => {
                        resolve(res.data);
                    })
                    .catch((err: any) => {
                        reject(err)
                    });
            });
        },
        obtenerTodos(): Promise<BeneficiarioModel[]> {
            return new Promise<any>((resolve, reject) => {
                axios.get(`${process.env.REACT_APP_API_URL}/api/beneficiarios/obtenertodos?clienteId=${authService.userData.Id}`)
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

export default beneficiariosService;
import { AuthModel, UserModel } from "../models/UserModel";
import axios from 'axios';

const authService = (() => {
    var storageData = localStorage.getItem('current_user');
    var isAuthenticated = !!storageData;
    var userData: AuthModel = {} as AuthModel;

    if (storageData)
        userData = JSON.parse(storageData);

    return {
        userData,
        isAuthenticated,
        signIn(model: UserModel): Promise<any> {
            return new Promise<any>((resolve, reject) => {
                axios.post(`${process.env.REACT_APP_API_URL}/api/usuarios/iniciarsesion`, model)
                    .then((res: any) => {
                        this.isAuthenticated = true;
                        this.userData = res.data;
                        localStorage.setItem('current_user', JSON.stringify(res.data));
                        resolve(res);
                    })
                    .catch((err: any) => {
                        reject(err)
                    });
            });
        },
        signOut() {
            isAuthenticated = false;
            userData = {} as AuthModel;
            localStorage.removeItem('current_user');
            window.location.reload(false);
        }
    }
})();

export default authService;
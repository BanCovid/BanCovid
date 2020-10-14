import { UserModel } from "../models/UserModel";
import Http from "./http";

const authService = (() => {
    var token = localStorage.getItem('current_user');
    var isAuthenticated = !!token;

    var userData = {};

    return {
        userData,
        isAuthenticated,
        signIn(model: UserModel): Promise<any> {
            return new Promise<any>((resolve, reject) => {
                Http.anonymousPost(`${process.env.REACT_APP_API_URL}/api/usuarios/iniciarsesion`, model)
                .then((res: any) => {
                  this.isAuthenticated = true;
                  console.log(res);
                  //localStorage.setItem(res.access_token);
                  resolve(res);
                })
                .catch(({response}) => reject(response))
            });
        }
    }
})();

export default authService;
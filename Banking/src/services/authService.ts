import { UserModel } from "../models/UserModel";

const authService = (() => {
    var token = localStorage.getItem('current_user');
    var isAuthenticated = !!token;

    var userData = {};

    return {
        userData,
        isAuthenticated,
        signIn(model: UserModel): Promise<any> {
            return new Promise<any>((resolve, reject) => {
                if (model.UserName == '1085414' && model.Password == 'hola') {
                    this.isAuthenticated = true;
                    localStorage.setItem('current_user', '1');
                    resolve();
                } else {
                    reject();
                }
            });
        }
    }
})();

export default authService;
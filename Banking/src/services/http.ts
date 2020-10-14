import axios from 'axios';

const Http = (() => {
    return ({
        
        anonymousPost<t>(url: any, data: any): Promise<t> {
            return new Promise<t>((resolve, reject) => {
                axios
                    .post(url, data)
                    .then((res: any) => {
                        resolve(res);
                    })
                    .catch((err: any) => {
                        reject(err);
                    });
            });
        }
    });
})();

export default Http;
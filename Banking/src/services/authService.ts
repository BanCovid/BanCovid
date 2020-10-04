
const authService = (() => {
    //var token = AjaxHttp.getToken();
    var isAuthenticated = false;
    
    var userData = {};
  
    return {
      userData,
      isAuthenticated
    }
})();

export default authService;
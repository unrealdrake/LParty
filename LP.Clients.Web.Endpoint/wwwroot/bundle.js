function initHomeViewModel() {
    var homeViewModel = new Vue({
        el: '#home',
        data: {
            username: "",
            password: ""
        },
        computed: {
            fieldsAreValid: function () {
                return this.username !== "" && this.password !== "";
            }
        },
        methods: {
            login: function () {
            }
        }
    });
    return homeViewModel;
}
//var homeViewModel = new Vue({
//  el: '#home',
//  data: {
//    message: 'This is home view model. Ready for use'
//  }
//}); 
//# sourceMappingURL=bundle.js.map
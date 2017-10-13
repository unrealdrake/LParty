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
function registrationPageViewModel() {
    var registrationPageViewModel = new Vue({
        el: '#registration',
        data: {
            firstName: "",
            lastName: "",
            login: "",
            password: "",
            passwordConfirm: ""
        },
        computed: {},
        methods: {
            login: function () {
            }
        }
    });
    return registrationPageViewModel;
}
//# sourceMappingURL=bundle.js.map
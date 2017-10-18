interface IRegistrationPageViewModel {
    firstName: string;
    lastName: string;
    login: string;
    password: string;
    passwordConfirm: string;
}

function registrationPageViewModel(): IVue {
    var registrationPageViewModel = new Vue({
        el: '#registration',
        data: {
            firstName: "",
            lastName: "",
            login: "",
            password: "",
            passwordConfirm: ""
        },
        computed: {

        },
        methods: {
            login: () => {

            }
        }
    });

    return registrationPageViewModel;
}
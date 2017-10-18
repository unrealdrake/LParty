interface IHomeViewModel {
    username: string;
    password: string;
}

function initHomeViewModel(): IVue {
    var homeViewModel = new Vue({
        el: '#home',
        data: {
            username: "",
            password: ""
        },
        computed: {
            fieldsAreValid(this: IHomeViewModel) {
                return this.username !== "" && this.password !== "";
            }
        },
        methods: {
            login: () => {

            }
        }
    });

    return homeViewModel;
}
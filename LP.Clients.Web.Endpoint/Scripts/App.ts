import Vue from 'vue';

interface IHelloWorld extends Vue {
  message: string;
  buttonClick(): void;
}

var newTeamVm = new Vue({
  el: "#sayHello",
  data: {
    message: 'Hello World'
  },
  methods: {
    buttonClick: () => {
      this.message = "Have a good day";
    }

  }
} as Vue.ComponentOptions<IHelloWorld>);
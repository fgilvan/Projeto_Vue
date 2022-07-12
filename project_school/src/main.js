import { createApp } from 'vue'
// import Vue from 'vue'
import App from './App.vue'
// import VueResource from 'vue-resource'

// Vue.config.Vue.config.productionTip = false;
// Vue.use(VueResource);

// new Vue({
//     render: h => h(App),
// }).$mount('#app')

const app = createApp(App);
app.mount('#app')


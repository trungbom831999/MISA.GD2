import Vue from 'vue'
import App from './App.vue'
import 'bootstrap'
import VueRouter from 'vue-router'
import vuetify from './plugins/vuetify' // path to vuetify export
import '@mdi/font/css/materialdesignicons.css'

import Index from './components/home/Index'
import Supplier from './components/supplier/SupplierList.vue'
import Account from './components/account/AccountList.vue'
import Cash from './components/payment/Cash.vue'

Vue.use(VueRouter)

Vue.config.productionTip = false

const EventBus = new Vue();
export default EventBus;

//Các path
const routes = [{
        path: '/index',
        component: Index
    }, {
        path: '/supplier',
        component: Supplier
    },
    {
        path: '/account',
        component: Account
    },
    {
        path: '/cash',
        component: Cash
    }
]

const router = new VueRouter({
    routes // short for `routes: routes`
})
new Vue({
    router,
    vuetify,
    icons: {
        iconfont: 'mdi', // default - only for display purposes
    },
    render: h => h(App),
}).$mount('#app')
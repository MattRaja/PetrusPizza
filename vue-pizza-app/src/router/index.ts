import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '../views/Home.vue'
import AccountLogin from '../views/Account/Login.vue'
import PizzaNamesIndex from '../views/PizzaNames/Index.vue'
import PizzaNamesEdit from '../views/PizzaNames/Edit.vue'
import PizzaNamesCreate from '../views/PizzaNames/Create.vue'
import PizzaNamesDelete from '../views/PizzaNames/Delete.vue'
import PaymentsIndex from '../views/Payments/Index.vue'
import PersonsIndex from '../views/Persons/Index.vue'
import ToppingsIndex from '../views/Toppings/Index.vue'
import ToppingsCreate from '../views/Toppings/Create.vue'
import ToppingsEdit from '../views/Toppings/Edit.vue'
import ToppingsDelete from '../views/Toppings/Delete.vue'
import Ordering from '../views/Order/Ordering.vue'
import OrderIndex from '../views/Order/Index.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
    { path: '/', name: 'Home', component: Home },

    { path: '/account/login', name: 'AccountLogin', component: AccountLogin },

    { path: '/pizzanames', name: 'PizzaNames', component: PizzaNamesIndex },
    { path: '/pizzanames/create', name: 'PizzaNamesCreate', component: PizzaNamesCreate },
    { path: '/pizzanames/edit', name: 'PizzaNamesEdit', component: PizzaNamesEdit, props: true },
    { path: '/pizzanames/delete', name: 'PizzaNamesDelete', component: PizzaNamesDelete },
    { path: '/payments', name: 'Payments', component: PaymentsIndex },
    { path: '/persons', name: 'Persons', component: PersonsIndex },
    { path: '/toppings', name: 'Toppings', component: ToppingsIndex },
    { path: '/toppings/create', name: 'ToppingsCreate', component: ToppingsCreate },
    { path: '/toppings/edit', name: 'ToppingsEdit', component: ToppingsEdit, props: true },
    { path: '/toppings/delete', name: 'ToppingsDelete', component: ToppingsDelete },
    { path: '/order/ordering', name: 'Ordering', component: Ordering, props: true },
    { path: '/order', name: 'OrderIndex', component: OrderIndex, props: true }
]

const router = new VueRouter({
    base: "/vue-pizza-app",
    routes
})

export default router

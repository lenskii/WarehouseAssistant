import { createRouter, createWebHistory } from 'vue-router'

const routes = [
    {
    path: '/',
    name: 'home',
        component: () => import('../components/Home.vue')
    },
    {
        path: '/items',
        name: 'items',
        component: () => import('../components/Items.vue')
    },
    {
        path: '/storages',
        name: 'storages',
        component: () => import('../components/Storages.vue')
    },
    {
        path: '/transactions',
        name: 'transactions',
        component: () => import('../components/Transactions.vue')
    },
    {
        path: '/stocks',
        name: 'stocks',
        component: () => import('../components/Stocks.vue')
    },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router

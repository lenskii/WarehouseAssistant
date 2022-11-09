import Axios from 'axios';

import { createStore } from "vuex";
import { mapActions } from 'vuex'

export default createStore({
    state: {
        itemsList: [],
        storagesList: [],
        transactionsList: [],
        stocksList: [],
    },
    getters: {
        itemsList: state => {
            return this.state.itemsList
        },
        storagesList: state => {
            return this.state.storagesList
        },
        transactionsList: state => {
            return this.state.transactionsList
        },
        stocksList: state => {
            return this.state.stocksList
        },
    },
    mutations: {
        setItemsList: (state, payload) => {
            state.itemsList = payload;
        },
        setStoragesList: (state, payload) => {
            state.storagesList = payload;
        },
        setTransactionsList: (state, payload) => {
            state.transactionsList = payload;
        },
        setStocksList: (state, payload) => {
            state.stocksList = payload;
        },

        addTransaction(state, transaction) {

            let formData = new FormData();
            formData.append('ItemId', transaction.itemId);
            formData.append('ItemsCount', transaction.itemsCount);
            formData.append('StorageFromId', transaction.storageFromId);
            formData.append('StorageToId', transaction.storageToId);

            Axios.postForm('transactions/add', formData)
                .catch(e => {
                    alert(e)
                })
        }, 

        getStock(state, stock) {

            Axios.get('stocks/' + stock.storageId + '/' + stock.stockDate)
                .then(responce => {
                    state.stocksList = responce.data;
                })
                .catch(e => {
                    alert(e)
                })
        },
    },
    actions: {
        getItems: (context, payload) => {
         
            Axios.get('/items')
                .then(responce => {
                    context.commit('setItemsList', responce.data);
                })
                .catch(e => {
                    alert(e)
                })
        },
        getStorages: (context, payload) => {

            Axios.get('/storages')
                .then(responce => {
                    context.commit('setStoragesList', responce.data);
                })
                .catch(e => {
                    alert(e)
                })
        },
        getTransactions: (context, payload) => {

            Axios.get('/transactions')
                .then(responce => {
                    context.commit('setTransactionsList', responce.data);
                })
                .catch(e => {
                    alert(e)
                })
        },
        deleteTransaction(state, transaction) {
            Axios.delete('transactions/delete/' + transaction.guid)
                .catch(e => {
                    alert(e)
                })  
        }
    },
    computed: {
        itemsList() {
            return this.$store.getter.itemsList;
        },
        storagesList() {
            return this.$store.getter.storagesList;
        },
        transactionsList() {
            return this.$store.getter.transactionsList;
        },
    },
    mounted() {
        this.$store.dispatch('getItems');
        this.$store.dispatch('getStorages');
        this.$store.dispatch('getTransactions');
    },
    methods: mapActions([
        'getItems', 'getStorages', 'getTransactions'
    ])
});
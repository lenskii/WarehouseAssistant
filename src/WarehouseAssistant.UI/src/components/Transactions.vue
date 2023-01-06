<template>
    <h2 id="tableLabel">Перемещения</h2>
    <table v-if="transactionsList">
        <thead>
            <tr>
                <th>Дата</th>
                <th>Количество</th>
                <th>Откуда</th>
                <th>Куда</th>
                <th>Номенклатура</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="transaction in transactionsList" :key="transaction.guid">
                <td>{{ prettyDate(transaction.dateTime) }}</td>
                <td>{{ transaction.itemsCount }}</td>
                <td>{{ transaction.storageFromName }}</td>
                <td>{{ transaction.storageInName }}</td>
                <td>{{ transaction.itemName }}</td>
                <td><button @click="deleteTransaction(transaction)">Удалить</button></td>
            </tr>
        </tbody>
    </table>
    <button id="show-modal" @click="showModal = true">Добавить</button>
    <Teleport to="body">
        <modal :show="showModal" @close="onModalClose">
        </modal>
    </Teleport>
</template>

<style>
    @import '/src/assets/base.css';
</style>

<script>

    import Modal from './ModalAddTransition.vue'
    import { mapState, mapActions, mapMutations } from 'vuex'
    import moment from 'moment'

    export default {
        components: {
            Modal
        },
        data() {
             return {
                 showModal: false
             }
        },
        computed: {
            ...mapState({
                transactionsList: state => state.transactionsList
            })
        },
        methods:
        {
            onModalClose() {
                this.showModal = false;
            },
            ...mapActions([
                'getTransactions',
                'deleteTransaction'
            ]),
            prettyDate(dateTime) {
                return moment(dateTime).format('DD/MM/YYYY HH:mm:ss')
            }
        },

        created() {
            this.$store.dispatch('getTransactions')
        },
        mounted() {
            this.$store.dispatch('getTransactions')
        },
    }
</script>

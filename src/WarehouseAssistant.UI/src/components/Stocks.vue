<template>
    <h2 id="tableLabel">Остатки</h2>
    <p>До:</p>
    <Datepicker v-model="dateTo"></Datepicker>

    <select v-model="selectionStorage">
        <option v-for="storage in storagesList" :key="storage.id" :value="storage">{{storage.name}}</option>
    </select>

    <button class="btn-primary" @click="onSubmit">Показать</button>

    <table v-if="stocksList">
        <thead>
            <tr>
                <th>Номенклатура</th>
                <th>Количество</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="stocks in stocksList" :key="stocks.itemName">
                <td>{{ stocks.itemName }}</td>
                <td>{{ stocks.itemsCount }}</td>
            </tr>
        </tbody>
    </table>

</template>

<script>
    import { mapState, mapActions, mapMutations } from 'vuex'  

    import Datepicker from '@vuepic/vue-datepicker';
    import '@vuepic/vue-datepicker/dist/main.css'
    import moment from 'moment'

    export default {
        components: {
            Datepicker
        },
        data() {
            return {
                dateTo: null,
                selectionStorage: ''
               
            };
        },
        computed: {
            ...mapState({
                storagesList: state => state.storagesList,
                stocksList: state => state.stocksList,
            }),
        },
        methods:
        {
            onSubmit() {

                let stock = {
                    
                    stockDate: moment(this.dateTo).format('YYYY MM DD HH:mm:ss'),
                    storageId: this.selectionStorage.id
                }

                this.getStock(stock);               
            }, 
            ...mapMutations({
                getStock: 'getStock',
            }),
        },        
        created() {
            this.$store.dispatch('getStorages');
        },
        mounted() {
            this.$store.dispatch('getStorages')
        },
        
    }
</script>
<template>
    <h2 id="tableLabel">Номенклатура</h2>
    <table v-if="itemsList">
        <thead>
            <tr>         
                <th>Название</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="item in itemsList" :key="item.id">            
                <td>{{ item.name }}</td>
            </tr>
        </tbody>
    </table>
</template>

<style>
    @import '/src/assets/base.css';
</style>

<script>
    import { mapState, mapActions } from 'vuex'
    export default {
        computed: {
            ...mapState({
                itemsList: state => state.itemsList
            }),
        },
        methods: mapActions([
            'getItems',
        ]),
        created() {
            this.$store.dispatch('getItems')
        },
        mounted() {
            this.$store.dispatch('getItems')
        }
    }
</script>
<template>
    <h2 id="tableLabel">Склады</h2>
    <table>
        <thead>
            <tr>
                <th>Наименование</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="storage in storagesList" :key="storage.id">
                <td>{{ storage.name }}</td>
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
                storagesList: state => state.storagesList
            })
        },
        methods: mapActions([
            'getStorages',
        ]),
        created() {
            this.$store.dispatch('getStorages')
        },
        mounted() {
            this.$store.dispatch('getStorages')
        }
    }
</script>

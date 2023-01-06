<template>
    <Transition name="modal">
        <div v-if="show" class="modal-mask">
            <div class="modal-wrapper">
                <div class="modal-container">
                    <div class="modal-body">
                        <h2>Что</h2>
                        <select v-model="selectedItem">
                            <option v-for="item in itemsList" :key="item.id" :value="item">{{item.name}}</option>
                        </select>
                        <h2>Сколько</h2>
                        <input v-model.number="count" type="number">
                        <h2>Откуда</h2>

                        <input type="checkbox" id="checkbox" v-model="isOutside">
                        <label for="checkbox">Извне</label>
                        <select v-model="selectionStorageFrom" v-bind:disabled="isOutside">
                            <option v-for="storage1 in storagesList" :key="storage1.id" :value="storage1">{{storage1.name}}</option>
                        </select>

                        <h2>Куда</h2>
                        <select v-model="selectionStorageTo">
                            <option v-for="storage2 in storagesList" :key="storage2.id" :value="storage2">{{storage2.name}}</option>
                        </select>
                    </div>

                    <div class="modal-footer">
                        <slot name="footer">
                            <button class="modal-default-button" @click="onSubmit">OK</button>
                        </slot>
                    </div>
                </div>
            </div>
        </div>
    </Transition>
</template>

<script>

    import { mapState, mapActions, mapMutations } from 'vuex'

    export default {
        props: {
            show: Boolean,
        },
        data() {
            return {
                isOutside: false,
                selectedItem: '',
                count: 0,
                selectionStorageFrom: '',
                selectionStorageTo: ''
            }
        },
        computed: {
            ...mapState({
                itemsList: state => state.itemsList,
                storagesList: state => state.storagesList
            }),
        },
        created() {
            this.$store.dispatch('getItems');
            this.$store.dispatch('getStorages');
        },
        mounted() {
            this.$store.dispatch('getItems');
            this.$store.dispatch('getStorages');
        },      
        methods: {
            onSubmit() {
                if (this.selectionStorageFrom.id == this.selectionStorageTo.id) {
                    alert('Пункт отправления и доставки не должен совпадать')
                }
                else {

                    let storageFromId = 0;

                    if (!this.isOutside) {
                        storageFromId = this.selectionStorageFrom.id;
                    }

                    let transaction = {
                        itemId: this.selectedItem.id,
                        itemsCount: this.count,
                        storageFromId: storageFromId,
                        storageToId: this.selectionStorageTo.id
                    }

                    this.addTransaction(transaction);
                    this.$emit('close');
                }
            },
            ...mapMutations({
                addTransaction: 'addTransaction',
            }),
        }

    }
</script>

<style>
    .modal-mask {
        position: fixed;
        z-index: 9998;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.5);
        display: table;
        transition: opacity 0.3s ease;
    }

    .modal-wrapper {
        display: table-cell;
        vertical-align: middle;
    }

    .modal-container {
        width: 300px;
        margin: 0px auto;
        padding: 20px 30px;
        background-color: #fff;
        border-radius: 2px;
        box-shadow: 0 2px 8px rgba(0, 0, 0, 0.33);
        transition: all 0.3s ease;
    }

    .modal-header h3 {
        margin-top: 0;
        color: #42b983;
    }

    .modal-body {
        margin: 20px 0;
    }

    .modal-default-button {
    }

    .modal-enter-from {
        opacity: 0;
    }

    .modal-leave-to {
        opacity: 0;
    }

        .modal-enter-from .modal-container,
        .modal-leave-to .modal-container {
            -webkit-transform: scale(1.1);
            transform: scale(1.1);
        }
</style>
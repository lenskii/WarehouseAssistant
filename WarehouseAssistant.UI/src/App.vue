<template>
  <nav>
    <router-link to="/">Главная</router-link> |
    <router-link to="/transactions">Перемещения</router-link> |
    <router-link to="/stocks">Остаток</router-link> |
    <router-link to="/items">Номенклатуры</router-link> | 
    <router-link to="/storages">Склады</router-link>
  </nav>
  <router-view/>
</template>

<style>
    @import '/src/assets/base.css';
</style>

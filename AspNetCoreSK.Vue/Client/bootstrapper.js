'use strict';

import Vue from 'vue';

import router from './router';

import App from './components/App.vue';

const app = new Vue({
    router,
    ...App
});

app.$mount('#app');
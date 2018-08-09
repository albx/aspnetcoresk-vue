'use strict';

import Vue from 'vue';
import VueRouter from 'vue-router';

import HomePage from './components/pages/HomePage.vue';
import ContactPage from './components/pages/ContactPage.vue';

Vue.use(VueRouter);

let router = new VueRouter({
    mode: 'history',
    routes: [
        { path: '/', component: HomePage },
        { path: '/contact', component: ContactPage }
    ]
});

export default router;
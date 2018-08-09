'use strict';

import Vue from 'vue';
import axios from 'axios';

import router from './router';

import Identity from './plugins/identity';
import App from './components/App.vue';

Vue.use(Identity, {
    authority: "https://localhost:44316/",
    client_id: "aspnetcoresk.vue",
    redirect_uri: "https://localhost:44388/static/callback.html",
    response_type: "id_token token",
    scope: "openid profile MyFeaturesApi",
    post_logout_redirect_uri: "https://localhost:44388",
});

const app = new Vue({
    router,
    ...App
});



app.$mount('#app');
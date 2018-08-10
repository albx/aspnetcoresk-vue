'use strict';

import Vue from 'vue';
import axios from 'axios';

const httpHelper = {
    async setAuthorizationToken() {
        let accessToken = await Vue.identity.getAccessToken();
        if (accessToken) {
            axios.defaults.headers.common['Authorization'] = 'Bearer ' + accessToken;
        }
    }
};

export default httpHelper;
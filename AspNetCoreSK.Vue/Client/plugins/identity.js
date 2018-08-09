'use strict';

import Vue from 'vue';
import Oidc from 'oidc-client';

import IdentityService from '../services/IdentityService';

const Identity = {
    install(Vue, options) {
        let identityService = new IdentityService(new Oidc.UserManager(options));

        Vue.identity = identityService;
        Vue.prototype.$identity = identityService;
    }
};

export default Identity;
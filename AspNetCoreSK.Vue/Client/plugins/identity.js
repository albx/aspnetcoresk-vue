'use strict';

import Vue from 'vue';
import Oidc from 'oidc-client';

import IdentityService from '../services/IdentityService';

const Identity = {
    install(Vue, options) {
        let identityService = new IdentityService(new Oidc.UserManager(options));

        Vue.identity = identityService;
        Vue.prototype.$identity = identityService;

        Vue.mixin({
            methods: {
                callAuthorizedApi(api) {
                    this.$identity.getUser()
                        .then((user) => {
                            if (user) {
                                api(user.access_token);
                            }
                        });
                }
            }
        });
    }
};

export default Identity;
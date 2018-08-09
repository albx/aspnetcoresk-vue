'use strict';

export default class IdentityService {
    _userManager;
    _accessToken;

    constructor(userManager) {
        this._userManager = userManager;
    }

    getUser() {
        return this._userManager.getUser()
            .then((user) => {
                if (user) {
                    this._accessToken = user.access_token;
                }

                return user;
            })
            .catch((err) => null);
    }

    async getAccessToken() {
        let user = await this.getUser();
        if (user) {
            return user.access_token;
        }

        return undefined;
    }

    signinRedirect() {
        return this._userManager.signinRedirect();
    }

    signoutRedirect() {
        return this._userManager.signoutRedirect();
    }

    signinRedirectCallback() {
        return this._userManager.signinRedirectCallback();
    }
}
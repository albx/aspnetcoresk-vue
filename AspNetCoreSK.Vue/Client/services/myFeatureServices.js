'use strict';

import axios from 'axios';

export default class MyFeatureServices {
    constructor() {
        
    }

    getSampleData() {
        return axios.get('https://localhost:44308/api/values')
            .then(response => response.data)
            .catch(err => {
                console.log(err);
                return {
                    isError: true,
                    errorMessage: err
                };
            });
    }
};
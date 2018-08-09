'use strict';

import axios from 'axios';

export default class MyFeatureServices {
    constructor() {
        
    }

    getSampleData() {
        return axios.get('/myfeature/api/sample')
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
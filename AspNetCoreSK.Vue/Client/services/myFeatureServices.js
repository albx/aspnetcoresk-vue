'use strict';

import axios from 'axios';

let myFeatureServices = {
    getSampleData: function () {
        return axios.get('/myfeature/api/sample')
            .then(response => response.data)
            .catch(err => {
                console.log(err);
                return null;
            });
    }
};

export default myFeatureServices;
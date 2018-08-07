<template>
    <div>
        <h1>This is home page</h1>
        <p>asdalldsald</p>
        <hr />
        <div v-if="!sampleData.length">No items</div>
        <div class="alert alert-danger" v-if="sampleData.isError">{{ sampleData.errorMessage }}</div>
        <ul v-if="sampleData.length && !sampleData.isError">
            <li v-for="item in sampleData">{{ item }}</li>
        </ul>
    </div>
</template>
<script>
    import myFeatureServices from '../../services/myFeatureServices'

    export default {
        name: 'home-page',
        data() {
            return {
                sampleData: []
            }
        },
        mounted() {
            myFeatureServices.getSampleData().then(data => {
                this.sampleData = data || [];
            });
        }
    }
</script>
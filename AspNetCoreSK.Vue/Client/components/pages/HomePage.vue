<template>
    <div>
        <h1>This is home page</h1>
        <p>asdalldsald</p>
        <hr />
        <div v-if="!sampleData.length">No items</div>
        <ul v-if="sampleData.length">
            <li v-for="item in sampleData">{{ item }}</li>
        </ul>
    </div>
</template>
<script>
    import myFeatureServices from '../../services/myFeatureServices'

    export default {
        name: 'home-page',
        data: function() {
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
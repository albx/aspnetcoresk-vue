<template>
    <div>
        <h1>Loading</h1>
    </div>
</template>
<script>
    import Vue from 'vue'

    export default {
        name: 'identity-callback',
        mounted() {
            this.$identity
                .signinRedirectCallback()
                .then(() => {
                    window.location = "/"
                })
                .catch((err) => {
                    console.log(err)
                })
        }
    }
</script>
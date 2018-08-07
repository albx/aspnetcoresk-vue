<template>
    <div>
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
            <div class="container">
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <router-link to="/" class="navbar-brand">AspNetCoreSK.Vue - SPA</router-link>
                <div class="navbar-collapse collapse" id="navbarContent">
                    <ul class="nav navbar-nav mr-auto">
                        <li class="nav-item">
                            <router-link class="nav-link" to="/contact">Contact</router-link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="container">
            <router-view></router-view>
        </div>
    </div>
</template>
<script>
    import Vue from 'vue'

    export default {
        name: 'app'
    }
</script>
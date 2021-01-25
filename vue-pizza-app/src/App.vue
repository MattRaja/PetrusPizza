<template>
    <div>
        <header>
            <nav
                class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3"
            >
                <div class="container">
                    <router-link to="/pizzanames" class="navbar-brand">Petrus Pizza</router-link>
                    <button
                        class="navbar-toggler"
                        type="button"
                        data-toggle="collapse"
                        data-target=".navbar-collapse"
                        aria-controls="navbarSupportedContent"
                        aria-expanded="false"
                        aria-label="Toggle navigation"
                    >
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
                        <Identity />
                        <ul class="navbar-nav flex-grow-1">
                            <li class="nav-item">
                                <router-link to="/pizzanames" class="nav-link text-dark">Pizzas</router-link>
                            </li>
                            <template v-if="isAdmin">
                            <li class="nav-item">
                                <router-link to="/toppings" class="nav-link text-dark">Manage Toppings</router-link>
                            </li>
                            <li v-if="isAuthenticated" class="nav-item">
                                <router-link to="/order" class="nav-link text-dark">Cart</router-link>
                            </li>
                            </template>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>
        <div class="container">
            <main role="main" class="pb-3">
                <router-view />
            </main>
        </div>
    </div>
</template>
<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import Identity from "./components/Identity.vue";
import store from "./store";

@Component({
    components: {
        Identity
    }
})
export default class App extends Vue {
    get isAdmin(): boolean {
        return store.getters.isAdmin;
    }

    get isAuthenticated(): boolean {
        return store.getters.isAuthenticated;
    }
}
</script>
<style scoped>
    router-link{

    }
</style>

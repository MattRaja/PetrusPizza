<template>
    <div>
        <router-link v-if="isAdmin" to="/pizzanames/create" type="button"
                class="nav-link btn btn-primary col-sm-2 float-right">
                Add a Pizza
        </router-link>
        <h1 style="font-style: italic;" class="container-fluid col-1">Pizzas</h1>
        <div class="row" v-for="pizzaname in pizzanames" :key="pizzaname.id">
            <div class="card mt-2 col-sm-4 border-0" style="width: 18rem;" >
                <div class="card-body bg-light d-flex flex-column">
                    <h3 style="font-style: italic" class="card-title align-self-center font-weight-bold p-4 ">{{pizzaname.nameOfPizza}}</h3>
                    <ul v-for="defaultTopping in pizzaname.defaultToppings" :key="defaultTopping.id">
                    <p style="font-weight: bold; font-family: Ariel;" class="card-text text-center mr-4">{{defaultTopping}}</p>
                    </ul>
                    <p class="card-text font-weight-bold text-right p-4">{{pizzaname.price}} €</p>
                    <router-link v-if="isAuthenticated" :to="{name: 'Ordering', params: {pizzaName: pizzaname,
                     defaultToppings: pizzaname.defaultToppings, price: pizzaname.price} }" type="button"
                         class="nav-link btn btn-success">Order</router-link>
                    <template v-if="isAdmin">
                        <router-link :to="{name: 'PizzaNamesEdit', params: {pizzaName: pizzaname,
                    price: pizzaname.price} }" type="button"
                         class="nav-link btn btn-secondary">
                            Edit
                        </router-link>
                        <button
                            v-if="isAdmin"
                            @click="deleteOnClick(pizzaname)"
                            type="button"
                            class="btn btn-danger">
                            Delete
                        </button>
                    </template>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import router from "../../router";
import { IPizzaName } from "../../domain/IPizzaName";
import store from "../../store";

@Component
export default class PizzaNamesIndex extends Vue {
    get pizzanames(): IPizzaName[] {
        return store.state.pizzaNames;
    }

    get isAuthenticated(): boolean {
        return store.getters.isAuthenticated;
    }

    get isAdmin(): boolean {
        return store.getters.isAdmin;
    }

    deleteOnClick(pizzaname: IPizzaName): void {
        console.log("inherebud", pizzaname.id)
        store.dispatch('deletePizzaName', pizzaname.id);
    }

    editOnClick(id: string, pizzaname: IPizzaName): void {
        store.dispatch('editPizzaName', pizzaname.id);
    }

    mounted(): void {
        console.log("mounted");
        store.dispatch("getPizzaNames");
    }
}
</script>
<style scoped>
div.card:hover {
  background-color: lightgray;
}
.card {
    display:inline-block;
}
</style>

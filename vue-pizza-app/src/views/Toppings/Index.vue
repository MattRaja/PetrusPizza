<template>
    <div v-if="isAdmin">
        <router-link v-if="isAdmin" to="/toppings/create" type="button"
                class="nav-link btn btn-primary col-sm-2 float-right">
                Add a Topping
        </router-link>
        <h1 class="container-fluid col-3">Toppings</h1>
        <table class="table table-striped col-md-10">
            <thead>
                <tr>
                <th scope="col">Topping</th>
                <th scope="col">Price</th>
                </tr>
            </thead>
            <tbody v-for="topping in toppings" :key="topping.id">
                <tr scope="row">
                <td>{{topping.toppingName}}</td>
                <td>{{topping.price}}</td>
                <td>
                <router-link :to="{name: 'ToppingsEdit', params: {toppingToEdit: topping} }" type="button"
                    style="float: right;" class="nav-link btn col-5 btn-secondary">
                    Edit
                </router-link>
                </td>
                <td>
                <button
                    @click="deleteOnClick(topping)"
                    type="button"
                    class="btn btn-danger">
                    Delete
                </button>
                </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import router from "../../router";
import { ITopping } from "../../domain/ITopping";
import store from "../../store";

@Component
export default class ToppingsIndex extends Vue {
    get toppings(): ITopping[] {
        return store.state.toppings;
    }

    get isAdmin(): boolean {
        return store.getters.isAdmin;
    }

    editOnClick(id: string, topping: ITopping): void {
        store.dispatch('editTopping', topping.id);
    }

    deleteOnClick(topping: ITopping): void {
        console.log("monkassssssssssss:", topping.id)
        store.dispatch('deleteTopping', topping.id);
    }

    mounted(): void {
        console.log("mounted");
        store.dispatch("getToppings");
    }
}
</script>
<style scoped>
div.card:hover {
  background-color: lightgray;
}
</style>

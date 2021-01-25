<template>
    <div>
        <h1>Add a Topping</h1>
        <form>
            <div class="form-group">
                <label for="ToppingName" class="col-sm-2">Name</label>
                <input type="text" class="form-control col-sm-2" id="ToppingName" placeholder="Name">
            </div>
            <div class="form-group">
                <label for="Price" class="col-sm-2">Price</label>
                <input type="text" class="form-control col-sm-2" id="Price" placeholder="Price">
            </div>
            <button
                v-if="isAdmin"
                v-on:click="validateForm()"
                class="btn btn-primary">Add</button>
        </form>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import router from "../../router";
import store from "../../store";
import { data } from 'jquery';

@Component
export default class ToppingsCreate extends Vue {
    makeToppingOnClick(name: string, price: number): void {
        console.log("event")
        const appUserId = this.getAppUserId();
        const topping = {
            ToppingName: name.trim(),
            Price: price.toString().trim(),
            AppUserId: this.getAppUserId()
        };
        store.dispatch('createTopping', topping);
        router.push("/toppings")
    }

    validateForm() {
        console.log((document.querySelector("#ToppingName") as HTMLInputElement).value)
        console.log((document.querySelector("#Price") as HTMLInputElement).value)
        const name = (document.querySelector("#ToppingName") as HTMLInputElement).value
        const price = (document.querySelector("#Price") as HTMLInputElement).value
        if (name === null || price === "") {
            alert("Name and Price must be filled out");
        } else {
            if (/^[a-zA-Z]+$/.test(name) === false) {
                alert("Name can consist of only letters")
            } else {
                try {
                    const priceDecimal = parseFloat(price)
                    this.makeToppingOnClick(name, priceDecimal);
                } catch (error) {
                    alert("Price needs to be a decimal value")
                }
            }
        }
    }

    getAppUserId(): void{
        return store.getters.getAppUserId;
    }

    get isAdmin(): boolean {
        return store.getters.isAdmin;
    }

    mounted(): void {
        console.log("mounted");
        store.dispatch("getToppings");
    }
}
</script>

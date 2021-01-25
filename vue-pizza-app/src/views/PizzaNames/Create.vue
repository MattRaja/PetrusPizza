<template>
    <div>
        <h1>Add a Pizza</h1>
        <form>
            <div class="form-group">
                <label for="NameOfPizza" class="col-sm-2">Name</label>
                <input type="text" class="form-control col-sm-2" id="NameOfPizza" placeholder="Pizza name">
            </div>
            <div class="form-group">
                <label for="Price" class="col-sm-2">Price</label>
                <input type="text" class="form-control col-sm-2" id="Price" placeholder="Price">
            </div>
            <ul v-for="topping in toppings" :key="topping.id">
                <div class="form-check">
                    <input type="checkbox" class="form-check-input" :name="topping.toppingName" id="DefaultToppingsOut">
                    <label class="form-check-label" for="DefaultToppingsOut">{{topping.toppingName}}</label>
                </div>
            </ul>
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
import { IPizzaName } from "../../domain/IPizzaName";
import { ITopping } from "../../domain/ITopping";
import store from "../../store";
import { data } from 'jquery';

@Component
export default class PizzaNamesCreate extends Vue {
    makePizzaOnClick(name: string, price: number, array: string[]): void {
        console.log("event")
        const appUserId = this.getAppUserId();
        const pizza = {
            NameOfPizza: name.trim(),
            Price: price.toString().trim(),
            DefaultToppingsOut: array,
            AppUserId: this.getAppUserId()
        };
        store.dispatch('createPizzaName', pizza);
        router.push("/pizzanames")
    }

    validateForm() {
        console.log((document.querySelector("#NameOfPizza") as HTMLInputElement).value)
        console.log((document.querySelector("#Price") as HTMLInputElement).value)
        const name = (document.querySelector("#NameOfPizza") as HTMLInputElement).value
        const price = (document.querySelector("#Price") as HTMLInputElement).value
        if ((document.querySelector('#DefaultToppingsOut:checked') as HTMLInputElement) === null) {
            alert("At least one topping is required");
        } else {
            const array = []
            const checkboxes = document.querySelectorAll('#DefaultToppingsOut[type=checkbox]:checked')
            for (let i = 0; i < checkboxes.length; i++) {
                console.log(checkboxes[i].getAttribute("name"))
                array.push(checkboxes[i].getAttribute("name"))
            }
            console.log(array)
            if (name === null || price === "") {
                alert("Name and Price must be filled out");
            } else {
                if (/^[a-zA-Z]+$/.test(name) === false) {
                    alert("Name can consist of only letters")
                } else {
                    try {
                        const priceDecimal = parseFloat(price)
                        this.makePizzaOnClick(name, priceDecimal, array as string[]);
                    } catch (error) {
                        alert("Price needs to be a decimal value")
                    }
                }
            }
        }
    }

    getAppUserId(): string {
        return store.getters.getAppUserId;
    }

    get pizzanames(): IPizzaName[] {
        return store.state.pizzaNames;
    }

    get toppings(): ITopping[] {
        return store.state.toppings;
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

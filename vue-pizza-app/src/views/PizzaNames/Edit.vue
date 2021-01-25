<template>
    <div>
        <h1>{{ pizzaName.nameOfPizza }}</h1>
        <form>
            <div class="form-group">
                <label for="NameOfPizza" class="col-sm-2">Name</label>
                <input type="text" class="form-control col-sm-2" id="NameOfPizza" :value="pizzaName.nameOfPizza">
            </div>
            <div class="form-group">
                <label for="Price" class="col-sm-2">Price</label>
                <input type="text" class="form-control col-sm-2" id="Price" :value="price">
            </div>
            <ul v-for="topping in toppings" :key="topping.id">
                <div class="form-check">
                    <input type="checkbox" :checked="boxIsChecked(topping.toppingName)" :name="topping.toppingName" class="form-check-input" id="DefaultToppingsOut">
                    <label class="form-check-label" for="DefaultToppingsOut">{{topping.toppingName}}</label>
                </div>
            </ul>
            <button
            v-if="isAdmin"
            v-on:click="validateForm(pizzaName.id)"
            type="submit" class="btn btn-primary">Save</button>
            </form>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { IPizzaName } from '@/domain/IPizzaName';
import { IPizzaNameEdit } from '@/domain/IPizzaNameEdit';
import router from "../../router";
import { ITopping } from "../../domain/ITopping";
import store from "../../store";
import { data } from 'jquery';

@Component
export default class PizzaNamesEdit extends Vue {
    @Prop()
    private id!: string;

    @Prop()
    private pizzaName!: IPizzaName;

    @Prop()
    private price!: number;

    editPizzaOnClick(id: string, name: string, price: number, array: string[]): void {
        console.log("event")
        const appUserId = this.getAppUserId();
        const pizza: IPizzaNameEdit = {
            Id: id,
            NameOfPizza: name.trim(),
            Price: price.toString().trim(),
            DefaultToppingsOut: array,
            AppUserId: this.getAppUserId()
        };
        store.dispatch('editPizzaName', pizza);
        router.push("/pizzanames")
    }

    validateForm(id: string) {
        console.log((document.querySelector("#NameOfPizza") as HTMLInputElement).value)
        console.log((document.querySelector("#Price") as HTMLInputElement).value)
        const name = (document.querySelector("#NameOfPizza") as HTMLInputElement).value
        const price = (document.querySelector("#Price") as HTMLInputElement).value
        if ((document.querySelector('#DefaultToppingsOut:checked') as HTMLInputElement) === null) {
            alert("At least one topping is required");
        } else {
            const checkedValue = (document.querySelector('#DefaultToppingsOut:checked') as HTMLInputElement)!.checked;
            console.log(checkedValue)
            const array = []
            const checkboxes = document.querySelectorAll('#DefaultToppingsOut[type=checkbox]:checked')
            console.log(checkboxes.length)
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
                        this.editPizzaOnClick(id, name, priceDecimal, array as string[]);
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

    boxIsChecked(topping: string): boolean {
        return this.pizzaName.defaultToppings.includes(topping)
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
        store.dispatch("getPizzaNames");
    }
}
</script>

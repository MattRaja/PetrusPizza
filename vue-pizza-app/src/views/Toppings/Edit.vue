<template>
   <div>
        <h1>{{ toppingToEdit.toppingName }}</h1>
        <form>
            <div class="form-group">
                <label for="ToppingName" class="col-sm-2">Name</label>
                <input type="text" class="form-control col-sm-2" id="ToppingName" :value="toppingToEdit.toppingName">
            </div>
            <div class="form-group">
                <label for="Price" class="col-sm-2">Price</label>
                <input type="text" class="form-control col-sm-2" id="Price" :value="toppingToEdit.price">
            </div>
            <button type="submit"
            v-if="isAdmin"
            v-on:click="validateForm(toppingToEdit.id)"
             class="btn btn-primary">Save</button>
        </form>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import router from "../../router";
import { ITopping } from "../../domain/ITopping";
import { IToppingEdit } from "../../domain/IToppingEdit";
import store from "../../store";
import { data } from 'jquery';

@Component
export default class ToppingsEdit extends Vue {
    @Prop()
    private toppingToEdit!: ITopping;

    getAppUserId(): string {
        return store.getters.getAppUserId;
    }

    get isAdmin(): boolean {
        return store.getters.isAdmin;
    }

    editToppingOnClick(id: string, name: string, price: number): void {
        console.log("event")
        const appUserId = this.getAppUserId();
        const topping: IToppingEdit = {
            Id: id,
            ToppingName: name.trim(),
            Price: price.toString().trim(),
            AppUserId: this.getAppUserId()
        };
        store.dispatch('editTopping', topping);
        router.push("/toppings")
    }

    validateForm(id: string) {
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
                    this.editToppingOnClick(id, name, priceDecimal);
                } catch (error) {
                    alert("Price needs to be a decimal value")
                }
            }
        }
    }

    mounted(): void {
        console.log("mounted");
    }
}
</script>

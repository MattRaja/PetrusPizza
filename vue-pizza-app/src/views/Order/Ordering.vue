<template>
    <div>
        <h1 class="text-center" style="font-family: 'Times New Roman'; font-style: oblique;">{{ pizzaName.nameOfPizza }}</h1>
        <ul v-for="defaultTopping in pizzaName.defaultToppings" :key="defaultTopping.id">
            <p style="font-family: 'Helvetica'; font-weight: bold;" class="card-text text-center">{{defaultTopping}}</p>
        </ul>
        <div class="text-center pt-2">
        <div style="text-right; font-size: 30px; font-family: 'Times New Roman';">Type</div>
            <div class="btn-group btn-group-toggle pt-2" data-toggle="buttons">
                <div v-for="pizzatype in pizzatypes" :key="pizzatype.id">
                <label class="btn btn-secondary active mr-1">
                    <input type="radio" name="pizzaType" :id="pizzatype.pizzaTypeName" autocomplete="off">
                    {{ pizzatype.pizzaTypeName }}  + {{ pizzatype.price }} €
                </label>
                </div>
            </div>
        </div>
        <div class="text-center pt-2">
        <div style="text-right; font-size: 30px; font-family: 'Times New Roman';">Size</div>
            <div class="btn-group btn-group-toggle pt-2" data-toggle="buttons">
                <div v-for="pizzasize in pizzasizes" :key="pizzasize.id">
                <label class="btn btn-secondary active mr-1">
                    <input type="radio" name="pizzaSize" :id="pizzasize.pizzaSizeName" autocomplete="off">
                    {{ pizzasize.pizzaSizeName }}  + {{ pizzasize.price }} €
                </label>
                </div>
            </div>
        </div>
        <div class="text-center pb-5 pt-2">
            <div style="text-right; font-size: 30px; font-family: 'Times New Roman';">Toppings</div>
            <div v-for="topping in toppings" :key="topping.id" class="form-check">
                <input class="form-check-input" type="checkbox" :name="topping.toppingName" :value="topping.toppingName" id="ExtraTopping">
                <label class="form-check-label" :for="topping.toppingName">
                    {{ topping.toppingName }} + {{ topping.price }} €
                </label>
            </div>
        </div>
        <div class="row justify-content-center">
            <button @click="addOrderRow(pizzaName)" class="btn btn-default btn-primary text-center">
                Add to Cart
            </button>
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import router from "../../router";
import { ITopping } from "../../domain/ITopping";
import { IPizzaName } from "../../domain/IPizzaName";
import { IPizzaType } from "../../domain/IPizzaType";
import { IPizzaSize } from "../../domain/IPizzaSize";
import { IOrderRow } from "../../domain/IOrderRow";
import store from "../../store";

@Component
export default class Ordering extends Vue {
    @Prop()

    private pizzaName!: IPizzaName;

    private defaultToppings!: string[];

    private price!: number;

    private orderedUsers = [];

    addOrderRow(pizza: IPizzaName): void {
        const pizzaSize = (document.querySelector('input[name="pizzaSize"]:checked') as HTMLInputElement)!.getAttribute("id");
        const pizzaType = (document.querySelector('input[name="pizzaType"]:checked') as HTMLInputElement)!.getAttribute("id");
        console.log(pizzaSize);
        console.log(pizzaType);
        const extraToppingsArray = []
        const checkboxes = document.querySelectorAll('#ExtraTopping[type=checkbox]:checked');
        for (let i = 0; i < checkboxes.length; i++) {
            console.log(checkboxes[i].getAttribute("name"));
            extraToppingsArray.push(checkboxes[i].getAttribute("name"));
        }
        const orderRow: IOrderRow = {
            NameOfPizza: pizza.nameOfPizza.trim(),
            Price: pizza.price.toString().trim(),
            ExtraToppingsOnItems: extraToppingsArray as string[],
            AppUserId: this.getAppUserId(),
            PizzaSize: pizzaSize as string,
            PizzaType: pizzaType as string
        };
        store.dispatch('createOrderRow', orderRow);
        router.push("/pizzanames");
    }

    getAppUserId(): string {
        return store.getters.getAppUserId;
    }

    get toppings(): ITopping[] {
        return store.state.toppings;
    }

    get pizzatypes(): IPizzaType[] {
        return store.state.pizzaTypes;
    }

    get pizzasizes(): IPizzaSize[] {
        return store.state.pizzaSizes;
    }

    get pizzanames(): IPizzaName[] {
        return store.state.pizzaNames;
    }

    mounted(): void {
        console.log("mounted");
        store.dispatch("getPizzaNames");
        store.dispatch("getPizzaSizes");
        store.dispatch("getPizzaTypes");
        store.dispatch("getToppings");
    }
}

</script>
<style scoped>
div.card:hover {
  background-color: lightgray;
}
</style>

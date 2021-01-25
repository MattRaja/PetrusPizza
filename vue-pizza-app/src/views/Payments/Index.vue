<template>
    <div>
        <h1>Payments Index</h1>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import router from "../../router";
import { IPayment } from "../../domain/IPayment";
import store from "../../store";

@Component
export default class PaymentsIndex extends Vue {
    get sessions(): IPayment[] {
        return store.state.payments;
    }
}
</script>

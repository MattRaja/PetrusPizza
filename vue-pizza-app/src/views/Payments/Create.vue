<template>
    <div>
        <h1>Payment Create</h1>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component
export default class PaymentsCreate extends Vue {
    @Prop()
    private id!: string;
}
</script>

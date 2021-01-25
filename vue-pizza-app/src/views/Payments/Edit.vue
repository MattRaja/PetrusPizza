<template>
    <div>
        <h1>Payment Edit</h1>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component
export default class PaymentsEdit extends Vue {
    @Prop()
    private id!: string;
}
</script>

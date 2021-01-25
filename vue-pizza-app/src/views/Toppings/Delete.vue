<template>
    <div>
        <h1>Topping Details</h1>
        {{id}}
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component
export default class ToppingsDetails extends Vue {
    @Prop()
    private id!: string;
}
</script>

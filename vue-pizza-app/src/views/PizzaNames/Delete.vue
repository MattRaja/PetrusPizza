<template>
    <div>
        <h1>Pizza Details</h1>
        {{id}}
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component
export default class PizzaNamesDetails extends Vue {
    @Prop()
    private id!: string;
}
</script>

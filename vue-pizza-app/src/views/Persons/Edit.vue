<template>
    <div>
        <h1>Person Edit</h1>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component
export default class PersonsEdit extends Vue {
    @Prop()
    private id!: string;
}
</script>

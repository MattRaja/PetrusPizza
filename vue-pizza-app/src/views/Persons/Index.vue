<template>
    <div>
        <h1>Person Index</h1>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import router from "../../router";
import { IPerson } from "../../domain/IPerson";
import store from "../../store";

@Component
export default class PersonsIndex extends Vue {
    get sessions(): IPerson[] {
        return store.state.persons;
    }
}
</script>

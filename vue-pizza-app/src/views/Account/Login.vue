<template>
    <div class="row">
        <div class="col-md-6">
            <h4>Use a local account to log in.</h4>
            <h2 v-if="loginWasOk === false">Bad login attempt</h2>
            <hr />
            <div class="form-group">
                <label for="Input_Email">Email</label>
                <input v-model="loginInfo.email" class="form-control" type="email" id="Input_Email" />
            </div>
            <div class="form-group">
                <label for="Input_Password">Password</label>
                <input
                    v-model="loginInfo.password"
                    class="form-control"
                    type="password"
                    id="Input_Password"
                />
            </div>
            <div class="form-group">
                <button @click="loginOnClick($event)" class="btn btn-primary">Log in</button>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { ILoginDTO } from "@/types/ILoginDTO";
import store from "../../store";
import router from "../../router";

@Component
export default class LoginIndex extends Vue {
    private loginInfo: ILoginDTO = {
        email: "admin@admin.com",
        password: "@Dm1n123"
    };

    private loginWasOk: boolean | null = null;

    loginOnClick(): void {
        if (
            this.loginInfo.email.length > 0 &&
            this.loginInfo.password.length > 0
        ) {
            store
                .dispatch("authenticateUser", this.loginInfo)
                .then((isLoggedIn: boolean) => {
                    if (isLoggedIn) {
                        this.loginWasOk = true;
                        store.dispatch("checkAdmin", this.loginInfo)
                        router.push("/pizzanames");
                    } else {
                        this.loginWasOk = false;
                    }
                });
        }
    }
}
</script>

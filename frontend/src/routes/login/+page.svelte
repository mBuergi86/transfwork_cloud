<script lang="ts">
	import { enhance } from '$app/forms';
    import type { ActionData } from './$types';
    
    export let form: ActionData;
</script>

<pre>
    {JSON.stringify(form, null, 2)}
</pre>

<div class="">
    <div class="">
        <form method="post" use:enhance>
            <div class="">
                <label for="username">Username</label>
                <input type="text" id="username" name="username" value="{form?.data?.username ?? ''}" />
                {#if form?.errors?.username}
                    <p class=" text-red-500">Benutzername ist notwending</p>                    
                {/if}
            </div>
            <div class="">
                <label for="password">Password</label>
                <input type="password" id="password" name="password" />
                {#if form?.errors?.password}
                    <p class=" text-red-500">Passwort ist notwending</p>                    
                {/if}
            </div>
            <div class="">
                <button type="submit">Login</button>
            </div>
        </form>
    </div>
</div>
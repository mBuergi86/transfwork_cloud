<script lang="ts">
	import { applyAction, enhance, type SubmitFunction } from '$app/forms';
	import type { ActionData } from './$types';

	export let form: ActionData;

	const login: SubmitFunction = () => {
		return async ({ result }: { result: any }) => {
            if (result.type === 'redirect') {
                await applyAction(result);
            }
		};
	};
</script>

<div class="flex justify-center items-center my-[50%] bg-gray-200 w-80 h-64 p-4 rounded-xl shadow-lg bg-opacity-75">
	<form action="/login" method="post" use:enhance={login}>
		<div class="grid grid-rows-3 gap-3">
			<div class="flex justify-between items-center gap-2">
				<label for="username">Username:</label>
				<input type="text" id="username" name="username" value={form?.data?.username ?? ''} class=" bg-transparent border-b-black border-[1px]"/>
				{#if form?.errors?.username}
					<p class=" text-red-500">Benutzername ist notwending</p>
				{/if}
			</div>
			<div class="flex justify-between items-center">
				<label for="password" class="">Password:</label>
				<input type="password" id="password" name="password" class=" bg-transparent border-b-black border-[1px]"/>
				{#if form?.errors?.password}
					<p class=" text-red-500">Passwort ist notwending</p>
				{/if}
			</div>
			<div class="w-full text-center">
				<button type="submit" class="bg-green-500 hover:border-red-500 hover:border-2 border-2 border-green-500 rounded-lg p-2 active:scale-50 duration-300">Login</button>
			</div>
		</div>
	</form>
</div>

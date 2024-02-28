<script lang="ts">
	import type { PageData } from './$types';
	import type { Form } from '$lib/types/types';

	export let data: PageData;

	$: ({ todos } = data); 

	let formData: Form = {
		title: '',
		isComplete: false
	};

const POST = async () => {
	if (!formData.title) {
		return {
			status: 400,
			body: { message: 'Title is required' }
		}
	}

	const response = await fetch('http://34.88.103.38:5021/todos', {
		method: 'POST',
		headers: { 'Content-Type': 'application/json' },
		body: JSON.stringify({
			title: formData.title
		})
	})
		.then(res => res.json())
		.then((result) => console.log(result))
		.catch((error) => console.log('error', error));

	formData.title = '';
	location.reload();

	return new Response(JSON.stringify(response), {
		headers: {
			'Content-Type': 'application/json'
		},
		status: 201
	})
}

const PUT = async (formdata: Form, done: boolean) => {
	const response = await fetch(`http://34.88.103.38:5021/todos/${formdata.id}`, {
		method: 'PUT',
		headers: { 'Content-Type': 'application/json' },
		body: JSON.stringify({
			id: formdata.id,
			title: formdata.title,
			isComplete: done
		})
	})
		.then(res => res.json())
		.then((result) => console.log(result))
		.catch((error) => console.log('error', error));

	return new Response(JSON.stringify(response), {
		headers: {
			'Content-Type': 'application/json'
		},
		status: 201
	})
}

const DELETE = async (formdata: Form) => {
	const response = await fetch(`http://34.88.103.38:5021/todos/${formdata.id}`, {
		method: 'DELETE',
		headers: { 'Content-Type': 'application/json' }
	})
		.then(res => res.json())
		.then((result) => console.log(result))
		.catch((error) => console.log('error', error));

	location.reload();

	return new Response(JSON.stringify(response), {
		headers: {
			'Content-Type': 'application/json'
		},
		status: 201
	})
}
</script>

<div class=" grid justify-items-center">
	<div class=" flex justify-center p-4">
		<h1 class=" font-bold text-5xl text-white drop-shadow-lg shadow-black">TODO List</h1>
	</div>
	<form method="post" on:submit|preventDefault={POST}>
		<div class="flex justify-center items-center m-4">
			<input
				type="text"
				autocomplete="off"
				name="todo"
				id="todo_input"
				class="bg-white w-[450px] h-9 rounded-sm shadow-gray-950 drop-shadow-2xl p-4 transition duration-500 ease-in-out transform focus:scale-105 focus:outline-none focus:ring-2 focus:ring-rose-600 focus:ring-opacity-50"
				placeholder="Neue Aufgabe hinzufügen"
				bind:value={formData.title}
			/>
			<button
				type="submit"
				class="text-white font-bold bg-green-500 mx-4 p-2 rounded-lg hover:bg-green-300 transition-all duration-150 active:scale-75 focus:outline-none hover:ring-2 hover:ring-red-500"
				>Erstellen</button
			>
		</div>
	</form>
	<div class="flex flex-col items-baseline w-[510px] -ml-14">
		{#await todos}
			Loading...
		{:then todos} 
			{#each todos as { id, title, isComplete } (id) }
				<div class="flex justify-around items-center gap-4 w-full pt-2 pb-2">
					<div class="flex justify-between items-center bg-white w-full h-6 p-4 rounded-sm shadow-gray-950 drop-shadow-2xl">
						<input type="checkbox" name="todo" id="todoCheck" checked={isComplete} on:change={async (e) => {
							const done = e.currentTarget.checked;
							await PUT({id, title}, done);
						}} />
						<label for="todo_input" class="bg-white w-full px-4">{title}</label>
					</div>
					<button class="focus:outline-none active:scale-50 transition-all duration-150" on:click={async () => {
						await DELETE({id, title});
					}}>
					<div
							class="bg-red-500 rounded-full w-10 h-10 flex items-center justify-center fill-current text-white"
						>
							<svg
								class="fill-current text-white w-6 h-6"
								xmlns="http://www.w3.org/2000/svg"
								viewBox="0 -960 960 960"
								><path
									d="M280-120q-33 0-56.5-23.5T200-200v-520h-40v-80h200v-40h240v40h200v80h-40v520q0 33-23.5 56.5T680-120H280Zm400-600H280v520h400v-520ZM360-280h80v-360h-80v360Zm160 0h80v-360h-80v360ZM280-720v520-520Z"
								/></svg
							>
						</div>
				</button>
				</div>
			{/each}
		{/await}
	</div>
</div>

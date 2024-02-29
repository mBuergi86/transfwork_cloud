<script lang="ts">
	import type { PageData } from './$types';

	export let data: PageData;

	$: ({ todos } = data);

	let isVisible = false;
	let done = false;

	const visibleChange = (e: Event) => {
		isVisible = !isVisible;

		done = (e.currentTarget as HTMLInputElement).checked;
	};
</script>

<div class=" grid justify-items-center">
	<div class=" flex justify-center p-4">
		<h1 class=" font-bold text-5xl text-white drop-shadow-lg shadow-black">TODO List</h1>
	</div>
	<form method="POST" action="?/create">
		<div class="flex justify-center items-center m-4">
			<input
				type="text"
				autocomplete="off"
				name="todo"
				id="todo_input"
				class="bg-white w-[450px] h-9 rounded-sm shadow-gray-950 drop-shadow-2xl p-4 transition duration-500 ease-in-out transform focus:scale-105 focus:outline-none focus:ring-2 focus:ring-rose-600 focus:ring-opacity-50"
				placeholder="Neue Aufgabe hinzufügen"
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
			{#each todos as { id, title, isComplete } (id)}
				<div class="flex justify-around items-center gap-4 w-full pt-2 pb-2">
					<form action="?/update" method="POST">
						<div
							class="flex justify-start items-center bg-white w-[450px] h-6 p-4 rounded-sm shadow-gray-950 drop-shadow-2xl"
						>
							<input type="hidden" name="id" value={id} />
							<input
								type="checkbox"
								name="checked"
								checked={isComplete}
								value={done}
								on:change={visibleChange}
							/>
							<input type="text" name="title" id="title_input" value={title} class="hidden" />
							<label for="title_input" class="bg-white w-full px-4">{title}</label>
						</div>
						{#if isVisible}
							<div>
								<button
									class="focus:outline-none active:scale-50 transition-all duration-150"
									value={id}
								>
									<div
										class="bg-green-500 rounded-full w-10 h-10 flex items-center justify-center fill-current text-white"
									>
										<svg
											xmlns="http://www.w3.org/2000/svg"
											height="24"
											viewBox="0 -960 960 960"
											width="24"
											><path
												d="M840-680v480q0 33-23.5 56.5T760-120H200q-33 0-56.5-23.5T120-200v-560q0-33 23.5-56.5T200-840h480l160 160Zm-80 34L646-760H200v560h560v-446ZM480-240q50 0 85-35t35-85q0-50-35-85t-85-35q-50 0-85 35t-35 85q0 50 35 85t85 35ZM240-560h360v-160H240v160Zm-40-86v446-560 114Z"
											/></svg
										>
									</div>
								</button>
							</div>
						{/if}
					</form>
					<form action="?/delete" method="POST">
						<div>
							<input type="hidden" name="id" value={id} />
							<button
								class="focus:outline-none active:scale-50 transition-all duration-150"
								value={id}
							>
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
					</form>
				</div>
			{/each}
		{/await}
	</div>
</div>

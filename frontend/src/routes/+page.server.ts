import type { PageServerLoad } from './$types';

export const load = (async ({ fetch }) => {
	const res = await fetch('http://backend:8080/todos');
	const todos = await res.json();

	return {
		todos: todos
	};
}) satisfies PageServerLoad;

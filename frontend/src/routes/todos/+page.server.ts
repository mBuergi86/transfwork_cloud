import type { Actions, PageServerLoad } from './$types';
import { fail, redirect } from '@sveltejs/kit';

export const actions: Actions = {
	create: async ({ request }) => {
		const data = await request.formData();

		const res = await fetch('http://backend:8080/todos', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({
				title: data.get('todo')
			})
		});

		if (!res.ok) {
			return fail(401, { message: 'Failed to create todo' });
		}
		throw redirect(303, '/todos');
	},

	update: async ({ request }) => {
		const data = await request.formData();
		const id = data.get('id');
		const title = data.get('title');
		const isComplete = data.get('checked') === 'true';

		const res = await fetch(`http://backend:8080/todos/${id}`, {
			method: 'PUT',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({
				id: id,
				title: title,
				isComplete: isComplete
			})
		});

		if (!res.ok) {
			return fail(401, { message: 'Failed to update todo' });
		}
		throw redirect(303, '/todos');
	},

	delete: async ({ request }) => {
		const data = await request.formData();
		const id = data.get('id');

		const res = await fetch(`http://backend:8080/todos/${id}`, {
			method: 'DELETE'
		});

		if (!res.ok) {
			return fail(401, { message: 'Failed to delete todo' });
		}
		throw redirect(303, '/todos');
	}
} satisfies Actions;

export const load = (async ({ fetch, parent }) => {
	await parent();
	const res = await fetch('http://backend:8080/todos');
	const todos = await res.json();

	return {
		todos: todos
	};
}) satisfies PageServerLoad;
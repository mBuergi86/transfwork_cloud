import { getTodos } from '$db/todos'
import type { Form } from '$lib/types/types';
import type { PageServerLoad } from './$types';

export const load: PageServerLoad = async (): Promise<{ todos: Form[] }> => {
    console.log('load');
    const todos: Form[] = (await getTodos()).map(todo => todo as Form); // Fix: Map each WithId<Document> object to a Form object
    console.log(todos);
    return {
        todos: todos
    };
};
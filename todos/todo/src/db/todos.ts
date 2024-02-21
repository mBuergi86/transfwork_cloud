import { getDb } from '$db/mongo';

const db = getDb();

export async function addTodo(todo: string) {
    await db.collection('todos').insertOne({ todo });
}

export async function getTodos() {
    return await db.collection('todos').find({}).toArray();
}

export async function deleteTodo(todo: string) {
    await db.collection('todos').deleteOne({ todo });
}

export async function updateTodo(oldTodo: string, newTodo: string) {
    await db.collection('todos').updateOne({ todo: oldTodo }, { $set: { todo: newTodo } });
}

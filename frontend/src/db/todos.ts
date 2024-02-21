import db from '$db/mongo';

export const todos = db.collection('todos');
import { MongoClient } from 'mongodb';
import { MONGO_URL } from '$env/static/private';

const client = new MongoClient(MONGO_URL);

export async function connect(): Promise<void> {
    await client.connect();
}

export async function disconnect(): Promise<void> {
    await client.close();
}

export function getDb() {
    return client.db('todo');
}
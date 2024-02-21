import type { Form } from '$lib/types/types'

export const POST = async (formdata: Form) => {

    if (!formdata.title) {
        return {
            status: 400,
            body: { message: 'Title is required' }
        }
    }

    const response = await fetch('http://localhost:5021/todos', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            title: formdata.title
        })
    })
        .then(res => res.json())
        .then((result) => console.log(result))
        .catch((error) => console.log('error', error));

    formdata.title = '';
    location.reload();

    return new Response(JSON.stringify(response), {
        headers: {
            'Content-Type': 'application/json'
        },
        status: 201
    })
}

export const PUT = async (formdata: Form, done: boolean) => {
    const response = await fetch(`http://localhost:5021/todos/${formdata.id}`, {
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

export const DELETE = async (formdata: Form) => {
    const response = await fetch(`http://localhost:5021/todos/${formdata.id}`, {
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
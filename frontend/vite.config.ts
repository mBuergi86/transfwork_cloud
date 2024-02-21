import { sveltekit } from '@sveltejs/kit/vite';
import { defineConfig } from 'vite';

export default defineConfig({
	plugins: [sveltekit()],
	server: {
		proxy: {
			'/todos': {
				target: 'http://localhost:5021',
				changeOrigin: true,
				secure: false
			}
		}
	}
});
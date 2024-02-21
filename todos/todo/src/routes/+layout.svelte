<script lang="ts">
	import './styles.css';
	import kagoshima from '$lib/images/kagoshima.jpg'

	let images = {
		src: kagoshima,
		alt: 'Kagoshima, Japan'
	}
</script>

<div class="app flex h-full w-full justify-center items-center">
	<img src="{images.src}" alt="{images.alt}" class="fixed top-0 left-0 w-full h-full object-cover blur-[2px] -z-50" />
	<main>
		<slot />
	</main>
</div>
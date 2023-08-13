document.querySelector('h1').addEventListener('click', function() {
    gsap.to('h1', {
        scale: 1.2,
        duration: 0.5,
        yoyo: true,
        repeat: 1
    });
});

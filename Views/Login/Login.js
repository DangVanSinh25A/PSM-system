async function submitForm(event) {
    event.preventDefault();
    
    const formData = {
        Email: document.getElementById('email').value,
        Password: document.getElementById('password').value
    };

    const response = await fetch('/api/sign-in', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    });

    if (response.ok) {
        const data = await response.json();
        console.log(data);
        window.location.href = "/home";
    } else {
        console.error('Sign-in failed');
    }
}
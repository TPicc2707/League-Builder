export async function refreshToken() {
    const response = await fetch('/auth/refresh', {
        method: 'POST',
        credentials: 'include'
    });

    if (response.status === 204) {
        return { active: true, refreshed: false, anonymous: true };
    }

    if (response.status === 401) {
        return { active: false, refreshed: false };
    }

    if (!response.ok) {
        return { refreshed: false };
    }

    return await response.json();
}

export async function logout() {
    document.getElementById("logoutForm").submit();
}
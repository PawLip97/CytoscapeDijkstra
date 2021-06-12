import axios from 'axios';

//const API_URL = 'http://localhost:8080/api/auth/';

class AuthService {
    login(user) {
        console.log(user);
        return axios
            .post('/users/authenticate', {
                username: user.username,
                password: user.password
            })
            .then(response => {
                if (response.data.accessToken) {
                    localStorage.setItem('user', JSON.stringify(response.data));
                    console.log("Login sucessfull");
                    console.log(localStorage.getItem('user');
                }

                return response.data;
            });
    }

    logout() {
        localStorage.removeItem('user');
    }

    register(user) {
        console.log(user);
        return axios
            .post('/users/register', {
            username: user.username,
            password: user.password
        });
    }
}

export default new AuthService();
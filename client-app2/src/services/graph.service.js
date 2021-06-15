import axios from 'axios';

//const API_URL = 'http://localhost:8080/api/test/';

class GraphService {

    getAllGraphs() {
        return axios.get('graphs/allGraphs');
    }

    getUsersGraphs() {
        let user = JSON.parse(localStorage.getItem('user'));
        return axios.get('graphs/usersGraphs/' + user.id);
    }
}

export default new GraphService();
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

    saveGraph(userId, graphName, data, nodesCount, edgesCount) {
        return axios.post('graphs/saveGraph',
            {
                userId: userId,
                graphName: graphName,
                data: data,
                nodesCount: nodesCount,
                edgesCount: edgesCount
            });
    }

    deleteGraph(graphId) {
        return axios.delete('graphs/' + graphId)
    }
}

export default new GraphService();
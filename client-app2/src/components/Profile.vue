<template>
    <div class="container">
        <header class="jumbotron">
            <h3>
                <strong>{{currentUser.username}}</strong> Profile
            </h3>
        </header>
        <p>
            <strong>Id:</strong>
            {{currentUser.id}}
        </p>
        <p>
            <strong>Token:</strong>
            {{currentUser.accessToken.substring(0, 20)}} ... {{currentUser.accessToken.substr(currentUser.accessToken.length - 20)}}
        </p>
        <p>
            <strong>Your graphs:</strong><br /><br />
            <ul>
                <li v-for="item in graphsList" :key="item.name" style="margin-bottom:30px;">
                    <div class="graph-record-name" @click="graphClicked(item.data)">
                        <h4>{{ item.name }}</h4>
                    </div>
                    Nodes: {{ item.nodesCount }}; Edges: {{ item.edgesCount }} &nbsp;
                    <font-awesome-icon icon="trash-alt" class="clickable" @click="deleteGraph(item.id)" />
                </li>
            </ul>
        </p>
    </div>
</template>

<script>
    import graphService from "../services/graph.service";
import GraphService from "../services/graph.service";

    export default {
        name: 'Profile',
        data() {
            return {
                graphsList: []
            }
        },
        computed: {
            currentUser() {
                return this.$store.state.auth.user;
            }
        },
        methods: {
            graphClicked(data){
                this.$router.push({ name: 'graph', params: { graphData: data } });
            },
            getUsersGraphs() {
                GraphService.getUsersGraphs()
                    .then(
                        (response) => {
                            console.log(response.data);
                            this.graphsList = response.data;
                            return response.data;
                        },
                        (error) => {
                            this.content =
                                (error.response &&
                                    error.response.data &&
                                    error.response.data.message) ||
                                error.message ||
                                error.toString();
                            return null;
                        })
            },
            deleteGraph(graphId) {
                console.log(graphId);
                graphService.deleteGraph(graphId)
                    .then(
                        (response) => {
                            console.log(response);
                            this.getUsersGraphs();
                        },
                        (error) => {
                            this.content =
                                (error.response &&
                                    error.response.data &&
                                    error.response.data.message) ||
                                error.message ||
                                error.toString();
                            return null;
                        })
            }
        },
        mounted() {

            if (!this.currentUser) {
                this.$router.push('/login');
            }
            else
            {
                this.getUsersGraphs();
            }
        }
    };
</script>

<style scoped>

    .graph-record-name {
        cursor: pointer;
    }

    .graph-record-name:hover {
        color: blue;
        font-weight: bold;
    }

    .clickable {
        cursor: pointer;
    }

    ul {
        list-style:none;
    }
</style>
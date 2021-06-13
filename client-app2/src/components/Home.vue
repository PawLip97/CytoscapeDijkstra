<template>
    <div class="hello">
        <h1>Dijkstra Algorithm using Cytoscape</h1>
        <strong>
            Create your own weighted graph and calculate the shortest path between nodes!
        </strong>
        <br><br>
        <h3>Functionality includes:</h3><br />
        <ul>
            <li>Highly advanced graph editor, thanks to <a href="https://js.cytoscape.org/">Cytoscape</a></li>
            <br />
            <li>Changing aesthetic freely</li>
            <br />
            <li>Using Dijkstra algorithm to find the shortest path</li>
            <br />
            <li>Graph editor supports mobile devices</li>
            <br />
        </ul>

        <h3>Technology used:</h3><br />
        <ul>
            <li><a href="https://vuejs.org/"><icon :icon="['fab', 'vuejs']" /> Vue.js</a> for client-side code</li>
            <br />
            <li><a href="https://vuejs.org/"><icon :icon="['fab', 'vuejs']" /> .NET Core</a> for sever-side code</li>
            <br />
            <li><a href="https://webpack.js.org/">Cytoscape</a> for graph display and graph manipulation</li>
        </ul>
        <strong>To start, click the <a href="/cytoscapedijkstra/graph">Graph</a> menu!</strong>
        <br /><br />
        <strong>Made by Paweł Lipski</strong><br />
    </div>
</template>

<script>
    //import UserService from "../services/user.service";

    export default {
        name: "Home",
        data() {
            return {
                content: "",
            };
        },
        mounted() {
            /*
            UserService.getPublicContent().then(
                (response) => {
                    this.content = response.data;
                },
                (error) => {
                    this.content =
                        (error.response &&
                            error.response.data &&
                            error.response.data.message) ||
                        error.message ||
                        error.toString();
                }
            );

            UserService.getAllUsersTest()
                .then(response => {
                    console.log(response);
                })
                .catch(function (error) {
                    alert(error);
                });
                */
        },
    };
</script>
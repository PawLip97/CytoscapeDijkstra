<template>
    <div class="container">
        <header class="jumbotron">
            <h3>
                <strong>Community graphs</strong>
            </h3>
        </header>
        <p>
            <ul>
                <li v-for="item in graphsList" :key="item.name" @click="graphClicked(item.data)">
                    <p class="graph-record">
                        {{ item.name }}; Nodes: {{ item.nodesCount }}; Edges: {{ item.edgesCount }}
                    </p>
                </li>
            </ul>
        </p>
    </div>
</template>

<script>
    import GraphService from "../services/graph.service";

    export default {
        name: 'Community',
        data() {
            return {
                graphsList: []
            }
        },
        methods: {
            graphClicked(data){
                this.$router.push({ name: 'graph', params: { graphData: data } });
            }
        },
        mounted() {
            GraphService.getAllGraphs()
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
        }
    };
</script>

<style scoped>
.graph-record {
    cursor: pointer;
}

.graph-record:hover {
    color: blue;
    font-weight: bold;
}
</style>
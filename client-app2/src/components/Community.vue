<template>
    <div class="container">
        <header class="jumbotron">
            <h3>
                <strong>Community graphs</strong>
            </h3>
        </header>
        <p>
            <ul>
                <li v-for="item in graphsList" :key="item.name" style="margin-bottom:30px;">
                    <div class="graph-record-name" @click="graphClicked(item.data)">
                        <h4>{{ item.name }}</h4>
                    </div>
                    Nodes: {{ item.nodesCount }}; Edges: {{ item.edgesCount }} &nbsp;
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
        list-style: none;
    }
</style>
import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Counter from "@/components/Counter.vue";
import FetchData from "@/components/FetchData.vue";
import Graph from "@/components/Graph.vue";
import Help from "@/components/Help.vue";

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/Counter",
        name: "Counter",
        component: Counter,
    },
    {
        path: "/FetchData",
        name: "FetchData",
        component: FetchData,
    },
    {
        path: "/Graph",
        name: "Graph",
        component: Graph,
    },
    {
        path: "/Help",
        name: "Help",
        component: Help,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
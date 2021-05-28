<template>
    <h1>Help</h1>
    <br />
    <strong>Utilizing context menu:</strong>
    <p>
        Context menu allows for easy and fast access to most of avaible functions, relating to graph creation and modification.
        Different types of elements like nodes or edges have different options.
    </p>
    <p>To acces context menu, right click on an element</p>
    <strong>Nodes context menu:</strong>
    <br />

    <!-- <img src="../Images/context_menu.png" alt="Context menu" /> -->
    <p>The nodes context menu consists of six different options:</p>
    <ul>
        <li> Change label, to change nodes name</li>
        <li> Remove, to remove a node</li>
        <li> Add edge, to add an edge from a node</li>
        <li> Change color, to change nodes color</li>
        <li>Toggle label, to toggle visibility of nodes name</li>
    </ul>
    <p>With these options, you are able to freely modify nodes properties.</p>
    <strong>Backgrounds context menu:</strong>
    <br />

    <!-- <img src="../Images/background_menu.png" alt="Background menu" />-->
    <p>The backgrounds context menu consists of two different options:</p>
    <ul>
        <li> Add node, to add a node in a chosen position</li>
        <li> Remove selected, to remove all selected elements</li>
    </ul>
</template>


<script>
    export default {
        name: "Help",
        data() {
            return {
                currentCount: 0
            }
        },
        methods: {
            incrementCounter() {
                this.currentCount++;
            }
        }
    }
</script>
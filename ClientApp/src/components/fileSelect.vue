<template>
    <label class="file-select">
        <div class="btn btn-primary">
            <span v-if="value">Selected File: {{value.name}}</span>
            <span v-else><icon icon="upload" /> Import graph</span>
        </div>
        <input type="file" @change="handleFileChange" />
    </label>
</template>

<script>
    export default {
        props: {
            value: File
        },

        methods: {
            handleFileChange(e) {
                if (e.target.files[0].name.includes("json")) {
                    this.$emit('input', e.target.files[0])
                    this.$root.$emit('loadGraphJson');    // z jasona
                }
                else if (e.target.files[0].name.includes("txt")) {
                    this.$emit('input', e.target.files[0])
                    this.$root.$emit('loadGraphTxt');     // z txt matrix
                }
            }
        }
    }
</script>

<style scoped>
    .file-select > .select-button {
        padding: 1rem;
        color: white;
        background-color: #2EA169;
        border-radius: .3rem;
        text-align: center;
        font-weight: bold;
    }

    .file-select > input[type="file"] {
        display: none;
    }
</style>

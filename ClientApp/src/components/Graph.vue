/* eslint-disable */
<template>
    <div id="view">
        <div style="margin-top:6px;">
            <fileSelect id="fileSelector" v-model="file" style="cursor: pointer;margin-right:5px;"></fileSelect>
            <button type="button" class="btn btn-primary" @click="showModal()" style="float:right;margin-right:10px;"><icon icon="cog" /> Settings</button>
            <button type="button" class="btn btn-primary" @click="showModalExport()"><icon icon="download" /> Export</button>
        </div>
        <div>
            <div id="undo-redo-icons" style="position:absolute; margin-top:25px; margin-left:15px; z-index:1;">
                <div style="margin-bottom:9px;">Nodes: <strong>{{ nodesAmount }}</strong>; Edges: <strong>{{ edgesAmount }}</strong>; All: <strong>{{ nodesAmount + edgesAmount}}</strong>;</div>
                <icon id="undo" icon="undo" style="margin-left:5px;cursor:pointer;" />
                <icon id="redo" icon="redo" style="margin-left:5px;cursor:pointer;" />
                <icon id="center" icon="compress" style="margin-left:5px;cursor:pointer;" class="fa-lg" @click="center" />
            </div>
            <div id="cy"></div>
            <div id="path-panel" style="overflow:auto;">
                <div><h4>Dijkstra algorithm</h4></div>
                <div>
                    <b>Start node: </b>
                    <span>{{ pathNodeName1 }}</span>
                </div>
                <div>
                    <b>End node: </b>
                    <span>{{ pathNodeName2 }}</span>
                </div>
                <div>
                    <b>Found path: </b>
                    <span id="pathString" @click="pathElementsStringClicked">{{ pathElementsString }}</span>
                </div>
                <div>
                    <b>Distance: </b>
                    <span>{{ pathDistance }}</span>
                </div>
            </div>
        </div>

        <modal id="indexElements" name="indexElements" height="auto" width="70%" @opened="modalIndexOpened">
            <div style="margin-left:30px">
                <h1 class="mt-4">
                    Refresh elements names
                </h1>
                <h5 class="mt-5">
                    Elements to index:
                </h5>
                <div style="margin-left:30px;">
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="indexElementTypeRadios" id="indexElementTypeRadios1" value="0" checked>
                        <label class="form-check-label" for="indexElementTypeRadios1">
                            Nodes
                        </label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="indexElementTypeRadios" id="indexElementTypeRadios2" value="1">
                        <label class="form-check-label" for="indexElementTypeRadios2">
                            Edges
                        </label>
                    </div>
                </div>

                <h5 class="mt-5">
                    Index type:
                </h5>
                <div style="margin-left:30px;">
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="indexTypeRadios" id="indexTypeRadios1" value="0" checked>
                        <label class="form-check-label" for="indexTypeRadios1">
                            Numbers (1,2,3 etc.)
                        </label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="indexTypeRadios" id="indexTypeRadios2" value="1">
                        <label class="form-check-label" for="indexTypeRadios2">
                            Letters (a,b,c etc.)
                        </label>
                    </div>
                </div><br />
                <div>
                    <button type="button" class="btn btn-primary" @click="saveIndexElements()">Index elements</button>
                </div>
                <br />
            </div>
        </modal>

        <modal id="settings" name="settings" height="auto" width="70%" @opened="modalOpened">
            <div style="margin-left:30px">
                <h1 class="mt-4">
                    Graph settings
                </h1>
                <h5 class="mt-5">
                    Default elements name display:
                </h5>
                <div style="margin-left:30px;">
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="displayRadios" id="displayRadios1" value="0" checked>
                        <label class="form-check-label" for="displayRadios1">
                            Show all
                        </label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="displayRadios" id="displayRadios2" value="1">
                        <label class="form-check-label" for="displayRadios2">
                            Show only for nodes
                        </label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="displayRadios" id="displayRadios3" value="2">
                        <label class="form-check-label" for="displayRadios3">
                            Show only for edges
                        </label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="displayRadios" id="displayRadios4" value="3">
                        <label class="form-check-label" for="displayRadios4">
                            None
                        </label>
                    </div>
                </div>

                <h5 class="mt-5">
                    Default elements color:
                </h5>

                <ul>
                    <li style="padding-bottom:8px">
                        <table id="settingsNodeColor" style="background:white; float:left;">
                            <tr>
                                <th>
                                    <div class="one-color-settings node-color" id="gray" style="background:gray;"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings node-color" id="black" style="background:black;"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings node-color" id="green" style="background:green;"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings node-color" id="blue" style="background:#007bff;"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings node-color" id="purple" style="background:purple;"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings node-color" id="red" style="background:red;"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings node-color" id="orange" style="background:orange;"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings node-color" id="yellow" style="background:yellow;"></div>
                                </th>
                            </tr>
                        </table>
                        <div>&nbsp;Nodes</div>
                    </li>
                    <li style="padding-bottom:8px">
                        <table id="settingsEdgeColor" style="background:white; float:left;">
                            <tr>
                                <th>
                                    <div class="one-color-settings edge-color" id="gray" style="background:gray;"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings edge-color" id="black" style="background:black;"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings edge-color" id="green" style="background:green;"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings edge-color" id="blue" style="background:#007bff;"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings edge-color" id="purple" style="background:purple;"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings edge-color" id="red" style="background:red;"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings edge-color" id="orange" style="background:orange;"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings edge-color" id="yellow" style="background:yellow;"></div>
                                </th>
                            </tr>
                        </table>
                        <div>&nbsp;Edges</div>
                    </li>
                    <li style="padding-bottom:5px">
                        <table id="settingsSelectionColor" style="background:white; float:left;">
                            <tr>
                                <th>
                                    <div class="one-color-settings selection-color" id="0" style="background:rgb(255,0,0);"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings selection-color" id="1" style="background:rgb(0,255,0);"></div>
                                </th>
                                <th>
                                    <div class="one-color-settings selection-color" id="2" style="background:rgb(0,0,255);"></div>
                                </th>
                            </tr>
                        </table>
                        <div>&nbsp;Selection color</div>
                    </li>
                </ul>
                <br />
                <div>
                    <button type="button" class="btn btn-primary" @click="saveSettings()">Save</button>
                </div>
                <br />
            </div>
        </modal>

        <modal name="export" height="auto" width="70%" scrolalble="true">
            <div style="margin-left:30px">
                <h1 class="mt-4">
                    Choose export:
                </h1>
                <div>
                    <button type="button" class="btn btn-primary" @click="exportGraph()" style="margin-bottom:5px">As JSON</button>
                </div>
                <div>
                    <button type="button" class="btn btn-primary" @click="exportGraphAsPhoto()" style="margin-bottom:5px">As photo (.jpg)</button>
                </div>
                <div>
                    <button type="button" class="btn btn-primary" @click="exportGraphAsAdjacencyMatrix()" style="margin-bottom:5px"> As adjacency matrix</button>
                </div>
                <div>
                    <div v-if="setsMessage == '' ">
                        <button type="button" class="btn btn-secondary" @click="exportCalculationResults()" style="margin-bottom:5px" disabled> Export calculation results</button>
                        Calculate sets to unlock.
                    </div>
                    <button type="button" class="btn btn-primary" @click="exportCalculationResults()" style="margin-bottom:5px" v-else> Export calculation results</button>
                </div>
                <br />
            </div>
        </modal>
    </div>
</template>

<script>
    import cytoscape from "cytoscape";
    import cxtmenu from 'cytoscape-cxtmenu';
    import FileSelect from './fileSelect.vue';
    import Popper from 'cytoscape-popper';
    import UndoRedo from 'cytoscape-undo-redo';
    import scriptManager from './scriptManager.js'
    import $ from 'jquery'

    cytoscape.use(cxtmenu);
    cytoscape.use(Popper);
    cytoscape.use(UndoRedo);

    export default {
        name: 'Cytoscape',
        props: ["cyStyle", "cyLayout"],
        components: {
            FileSelect
        },
        data: function () {
            return {
                input: '',
                output: '',
                msg: 'vue to cytoscape',
                i: 0,
                nodeEdge1: 0,
                nodeEdge2: 0,
                pathNodeId1: 0,
                pathNodeId2: 0,
                pathNodeName1: '-',
                pathNodeName2: '-',
                pathElementsIds: [],
                pathElementsString: '-',
                pathDistance: '-',
                independentSets: [],
                independentSetsLabels: [],
                exportedGraph: '',
                file: null,
                isLoadGraph: false,
                independentNodesOrEdges: '',
                setsMessage: '',
                displayElements: 0,
                nodesDefaultColor: 'gray',
                edgesDefaultColor: 'gray',
                selectionDefaultColor: 2,
                nodesAmount: 0,
                edgesAmount: 0
            }
        },
        methods: {
            Test: function () {
                this.$modal.show('settings');
            },
            calculateElementsAmount: function () {
                this.nodesAmount = this.cy.nodes().length;
                this.edgesAmount = this.cy.edges().length;
                //console.log(this.nodesAmount)
                //console.log(this.edgesAmount)
            },
            saveIndexElements: function () {
                //console.log("saveIndexElements")

                var indexElementsType = $('input[name="indexElementTypeRadios"]:checked').val()
                var indexType = $('input[name="indexTypeRadios"]:checked').val()

                //console.log(indexElementsType )
                //console.log(indexType )

                // 0 - nodes, 1 - edges
                var elementsToIndex = indexElementsType == 0 ? this.cy.nodes() : this.cy.edges();

                // numbers 1,2,3 etc.
                if (indexType == 0) {
                    for (var j = 0; j < elementsToIndex.length; j++) {
                        elementsToIndex[j]._private.data.name = j + 1;
                    }
                }

                // letters 1,2,3 etc.
                if (indexType == 1) {
                    for (var j = 0; j < elementsToIndex.length; j++) {
                        var ordA = 'a'.charCodeAt(0);
                        var ordZ = 'z'.charCodeAt(0);
                        var len = ordZ - ordA + 1;

                        var n = j;
                        var s = "";
                        while (n >= 0) {
                            s = String.fromCharCode(n % len + ordA) + s;
                            n = Math.floor(n / len) - 1;
                        }

                        elementsToIndex[j]._private.data.name = s;
                    }
                }

                this.cy.elements().select();
                this.cy.elements().unselect();

                this.$modal.hide('indexElements');
            },
            indexElements: function () {
                this.$modal.show('settings');
                //console.log("indexElements")
            },
            center: function () {
                this.cy.maxZoom(2.5);
                this.cy.fit();
                this.cy.maxZoom(100);
            },
            showModalIndexElements: function () {
                this.$modal.show('indexElements');
            },
            showModal: function () {
                this.$modal.show('settings');
            },
            calculate: function () {
                var calculateSelected = $('input[name="calculateRadios"]:checked').val();

                switch (calculateSelected) {
                    case '0':
                        this.calculateIndependentNodeSets();
                        break;
                    case '1':
                        this.calculateIndependentEdgeSets();
                        break;
                    case '2':
                        this.calculateMinimumVertexCover();
                        break;
                    case '3':
                        this.calculateMinimumEdgeCover();
                        break;
                    case '4':
                        this.calculateDominatingSets();
                        break;
                    default:
                        console.log("No calculation selected");
                }
            },
            showModalExport: function () {
                this.$modal.show('export');
            },
            modalIndexOpened: function () {
                // zaznaczenie indexElementType radio button
                $('input[name="displayRadios"][value="' + this.indexElementsType + '"]').prop("checked", true);

                // zaznaczenie indexType radio button
                $('input[name="displayRadios"][value="' + this.indexType + '"]').prop("checked", true);
            },
            modalOpened: function () {
                // zaznaczenie displayMode radio button
                $('input[name="displayRadios"][value="' + this.displayElements + '"]').prop("checked", true);

                // zaznaczenie kolorów zale¿nie od aktualnych ustawieñ
                $('div[class="one-color-settings node-color"][id="' + this.nodesDefaultColor + '"]')
                    .removeClass('one-color-settings').addClass('one-color-settings-selected');
                //console.log(this.nodesDefaultColor)

                $('div[class="one-color-settings edge-color"][id="' + this.edgesDefaultColor + '"]')
                    .removeClass('one-color-settings').addClass('one-color-settings-selected');
                //console.log(this.edgesDefaultColor)

                $('div[class="one-color-settings selection-color"][id="' + this.selectionDefaultColor + '"]')
                    .removeClass('one-color-settings').addClass('one-color-settings-selected');
                //console.log(this.selectionDefaultColor)

                // settings color
                var settingsNodeColor = document.getElementById("settingsNodeColor")
                //console.log(settingsNodeColor)
                settingsNodeColor.addEventListener("click", function (event) {
                    //console.log(event.target.id);
                    if (event.target.id != '') {
                        var clickedElement = document.getElementsByClassName("node-color");
                        //console.log(clickedElement[event.target.id]);
                        for (var i = 0; i < clickedElement.length; i++) {     // usuwa zaznaczenie ze wszysztkich kolorów
                            //console.log(clickedElement);
                            clickedElement[i].className = "one-color-settings node-color"

                        }
                        clickedElement[event.target.id].className = "one-color-settings-selected node-color";    // zaznacza tylko jeden
                        //console.log(clickedElement.className);
                    }
                })

                // edge color
                var settingsEdgeColor = document.getElementById("settingsEdgeColor")
                //console.log(settingsEdgeColor)
                settingsEdgeColor.addEventListener("click", function (event) {
                    //console.log(event.target.id);
                    if (event.target.id != '') {
                        var clickedElement = document.getElementsByClassName("edge-color");
                        //console.log(clickedElement[event.target.id]);
                        for (var i = 0; i < clickedElement.length; i++) {     // usuwa zaznaczenie ze wszysztkich kolorów
                            //console.log(clickedElement);
                            clickedElement[i].className = "one-color-settings edge-color"

                        }
                        clickedElement[event.target.id].className = "one-color-settings-selected edge-color";    // zaznacza tylko jeden
                        //console.log(clickedElement.className);
                    }
                })

                // selection color
                var settingsSelectionColor = document.getElementById("settingsSelectionColor")
                //console.log(settingsNodeColor)
                settingsSelectionColor.addEventListener("click", function (event) {
                    //console.log(event.target.id);
                    if (event.target.id != '') {
                        var clickedElement = document.getElementsByClassName("selection-color");
                        //console.log(clickedElement[event.target.id]);
                        for (var i = 0; i < clickedElement.length; i++) {     // usuwa zaznaczenie ze wszysztkich kolorów
                            //console.log(clickedElement);
                            clickedElement[i].className = "one-color-settings selection-color"

                        }
                        clickedElement[event.target.id].className = "one-color-settings-selected selection-color";    // zaznacza tylko jeden
                        //console.log(clickedElement.className);
                    }
                })
            },
            saveSettings: function () {
                var displaySelected = $('input[name="displayRadios"]:checked').val()
                var nodeColorSelected = $('div[class="one-color-settings-selected node-color"]').attr("id");
                var edgeColorSelected = $('div[class="one-color-settings-selected edge-color"]').attr("id");
                var selectionColorSelected = $('div[class="one-color-settings-selected selection-color"]').attr("id");

                //console.log(nodeColorSelected)
                //console.log(edgeColorSelected)
                //console.log(selectionColorSelected)

                if (!(displaySelected === undefined)) {
                    this.displayElements = displaySelected;
                }

                if (!(nodeColorSelected === undefined)) {
                    this.nodesDefaultColor = nodeColorSelected;
                }

                if (!(edgeColorSelected === undefined)) {
                    this.edgesDefaultColor = edgeColorSelected;
                }

                if (!(selectionColorSelected === undefined)) {
                    this.selectionDefaultColor = selectionColorSelected;
                }

                switch (this.displayElements) {
                    case '0':   // show all
                        this.cy.nodes().removeClass('hide-label');
                        this.cy.edges().addClass('show-label');
                        break;
                    case '1':   // show only for nodes
                        this.cy.nodes().removeClass('hide-label');
                        this.cy.edges().removeClass('show-label');
                        break;
                    case '2':   // show only for edges
                        this.cy.nodes().addClass('hide-label');
                        this.cy.edges().addClass('show-label');
                        break;
                    case '3':   // none
                        this.cy.nodes().addClass('hide-label');
                        this.cy.edges().removeClass('show-label');
                        break;
                    default:
                    //console.log("displayElements selection error");
                }

                this.changeColor([this.cy.nodes(), this.nodesDefaultColor, this.cy.nodes().classes()])    // zmiana kolorów node'ów
                this.changeColor([this.cy.edges(), this.edgesDefaultColor, this.cy.edges().classes()])    // zmiana kolorów edge'ów

                var selectionStyle = this.cy.style()[25];

                //console.log(selectionStyle);

                switch (this.selectionDefaultColor) {
                    case '0':
                        selectionStyle.properties[0].value = [255, 0, 0];         // node selection color
                        selectionStyle.properties[0].pfValue = [255, 0, 0];
                        selectionStyle.properties[0].strValue = "rgb([255, 0, 0])";

                        selectionStyle.properties[1].value = [255, 0, 0];         //edge selection color
                        selectionStyle.properties[1].pfValue = [255, 0, 0];
                        selectionStyle.properties[1].strValue = "rgb(255, 0, 0)";
                        break;
                    case '1':
                        selectionStyle.properties[0].value = [0, 255, 0];         // node selection color
                        selectionStyle.properties[0].pfValue = [0, 255, 0];
                        selectionStyle.properties[0].strValue = "rgb(0, 255, 0]";

                        selectionStyle.properties[1].value = [0, 255, 0];         //edge selection color
                        selectionStyle.properties[1].pfValue = [0, 255, 0];
                        selectionStyle.properties[1].strValue = "rgb(0, 255, 0)";
                        break;
                    case '2':
                        selectionStyle.properties[0].value = [0, 0, 255];         // node selection color
                        selectionStyle.properties[0].pfValue = [0, 0, 255];
                        selectionStyle.properties[0].strValue = "rgb(0, 0, 255)";

                        selectionStyle.properties[1].value = [0, 0, 255];         //edge selection color
                        selectionStyle.properties[1].pfValue = [0, 0, 255];
                        selectionStyle.properties[1].strValue = "rgb(0, 0, 255)";
                        break;
                    default:
                        console.log("error selection color");
                }

                //console.log(selectionStyle);

                //[ele, event.target.id, ele.classes()]

                /*
                if (ele._private.group == "nodes") {
                          ele.toggleClass('hide-label');
                        }

                        if (ele._private.group == "edges") {
                          ele.toggleClass('show-label');
                        }
                */
                this.$modal.hide('settings');

            },
            pathElementsStringClicked: function (a) {
                this.cy.elements().unselect();

                var builtString = "";

                console.log(this.pathElementsIds);

                for (var i = 0; i < this.pathElementsIds.length; i++) {
                    if (i == 0) {
                        builtString += '[id = "' + this.pathElementsIds[i] + '"]';
                    }
                    else {
                        builtString += ', [id = "' + this.pathElementsIds[i] + '"]';
                    }
                }

                console.log(builtString);

                this.cy.filter(builtString).select();

                /*
                //console.log(setIndex)
                var builtString = "";
                for (i = 0; i < this.pathElementsIds[setIndex].length; i++) {   // buduje stringa ¿eby mo¿na by³o od razu u¿yc filtru na wszystkich elementach
                    if (this.independentNodesOrEdges == 'n') {
                        if (i == 0) {
                            builtString += 'node[id = "' + this.independentSets[setIndex][i] + '"]';
                        }
                        else {
                            builtString += ', node[id = "' + this.independentSets[setIndex][i] + '"]';
                        }
                    }
                    else {
                        if (i == 0) {
                            builtString += 'edge[id = "' + this.independentSets[setIndex][i] + '"]';
                        }
                        else {
                            builtString += ', edge[id = "' + this.independentSets[setIndex][i] + '"]';
                        }
                    }
                }
                this.cy.filter(builtString).select();
                //console.log(builtString)
                //elements.push(this.cy.filter('node[id.includes("' + splitted[i] + '")'));
                */
            },
            independentSetClicked: function (a) {
                this.cy.elements().unselect();
                var i = 0;
                //console.log(a);

                var textOfClickedSet = '';
                var indexOfDot = '';
                var setIndex = '';

                // firefox
                if (a.path === undefined) {
                    textOfClickedSet = a.srcElement.innerHTML;

                    var cleanString = textOfClickedSet.replace('\n', '').trim();
                    indexOfDot = cleanString.indexOf('.');   // musze sprawdzac od kropki, bo inaczej np zbiór "15" bra³ jako "1"
                    setIndex = cleanString.substring(0, indexOfDot) - 1;
                    //console.log(setIndex);
                }

                // chrome
                if (!(a.path === undefined)) {
                    textOfClickedSet = a.path[0].innerText;

                    indexOfDot = textOfClickedSet.indexOf('.');   // musze sprawdzac od kropki, bo inaczej np zbiór "15" bra³ jako "1"
                    setIndex = textOfClickedSet.substring(0, indexOfDot) - 1;

                    //console.log(setIndex);
                }

                // var setIndex = a.path[0].innerText.charAt(0) - 1;   // -1, ¿eby na stronie mog³y siê zaczynaæ od 1, a nie od 0

                //console.log(setIndex)
                var builtString = "";
                for (i = 0; i < this.independentSets[setIndex].length; i++) {   // buduje stringa ¿eby mo¿na by³o od razu u¿yc filtru na wszystkich elementach
                    if (this.independentNodesOrEdges == 'n') {
                        if (i == 0) {
                            builtString += 'node[id = "' + this.independentSets[setIndex][i] + '"]';
                        }
                        else {
                            builtString += ', node[id = "' + this.independentSets[setIndex][i] + '"]';
                        }
                    }
                    else {
                        if (i == 0) {
                            builtString += 'edge[id = "' + this.independentSets[setIndex][i] + '"]';
                        }
                        else {
                            builtString += ', edge[id = "' + this.independentSets[setIndex][i] + '"]';
                        }
                    }
                }
                this.cy.filter(builtString).select();
                //console.log(builtString)
                //elements.push(this.cy.filter('node[id.includes("' + splitted[i] + '")'));
            },
            addNode: function (position) {
                //console.log(this.i)
                var newNode = this.cy.add({
                    group: "nodes",
                    data: { id: this.i, weight: 75, name: this.i++ },
                    position: position,
                    weight: 50,
                });

                switch (this.displayElements) {
                    case '0':   // show all
                        newNode.removeClass('hide-label');
                        break;
                    case '1':   // show only for nodes
                        newNode.removeClass('hide-label');
                        break;
                    case '2':   // show only for edges
                        newNode.addClass('hide-label');
                        break;
                    case '3':   // none
                        newNode.addClass('hide-label');
                        break;
                    default:
                    //console.log("displayElements selection error");
                }

                this.changeColor([newNode, this.nodesDefaultColor, newNode.classes()])    // zmiana koloru zale¿nie od wybranego defaulta

                return [this.i - 1, position];
            },
            addNodeUndo: function (args) {
                //console.log("addUndo");
                var a = this.cy.$('#' + args[0]);
                this.cy.remove(a);
                --this.i;
                return args[1];
            },
            addEdge: function (args) {
                var newEdge = this.cy.add({
                    group: 'edges',
                    data: { id: this.i, source: args[0], target: args[1], name: this.i++ },
                    classes: "show-label"
                });
                //console.log('adding', args[0] + "-" + args[1]);


                switch (this.displayElements) {
                    case '0':   // show all
                        newEdge.addClass('show-label');
                        break;
                    case '1':   // show only for nodes
                        newEdge.removeClass('show-label');
                        break;
                    case '2':   // show only for edges
                        newEdge.addClass('show-label');
                        break;
                    case '3':   // none
                        newEdge.removeClass('show-label');
                        break;
                    default:
                    //console.log("displayElements selection error");
                }

                this.changeColor([newEdge, this.edgesDefaultColor, newEdge.classes()])    // zmiana koloru zale¿nie od wybranego defaulta

                return [args[0], args[1], this.i - 1];
            },
            addEdgeUndo: function (args) {
                var a = this.cy.$('#' + args[2]);
                this.cy.remove(a);
                return [args[0], args[1]]
            },
            changeColor: function (args) {
                //console.log(args[0]);
                //console.log(args[1]);
                //console.log(args[2]);
                this.cy.$().unselect();
                var classlessEle = this.removeClasses(args[0]);

                for (var i = 0; i < classlessEle.length; i++) {
                    if (classlessEle[i]._private.group == "nodes") {
                        classlessEle[i].toggleClass('node-' + args[1]);
                    }
                    if (classlessEle[i]._private.group == "edges") {
                        classlessEle[i].toggleClass('edge-' + args[1]);
                    }
                }
                return [classlessEle, args[1], args[2]]
            },
            changeColorUndo: function (args) {
                //console.log(args[0]);
                //console.log(args[1]);

                var classlessEle = this.removeClasses(args[0]);
                if (classlessEle._private.group == "nodes") {
                    classlessEle.toggleClass(args[2] != "" ? args[2] : 'node');
                }
                if (classlessEle._private.group == "edges") {
                    classlessEle.toggleClass(args[2] != "" ? args[2] : 'edge');
                }

                return [classlessEle, args[1], args[2]];
            },
            changeLabel: function (args) {
                this.cy.$().unselect();
                //console.log(args[1])
                var previousName = args[0]._private.data.name;
                args[0]._private.data.name = args[1];
                //console.log(previousName);
                args[0].unselect();
                args[0].select();
                return [args[0], previousName];
            },
            changeLabelUndo: function (args) {
                //console.log(args[1]);
                var previousName = args[0]._private.data.name;
                //console.log(previousName)
                args[0]._private.data.name = args[1];

                args[0].unselect();
                args[0].select();
                args[0].unselect();

                return [args[0], previousName]
            },
            removeElement: function (ele) {
                return ele.remove();
            },
            removeElementUndo: function (ele) {
                return ele.restore();
            },
            removeClasses: function (ele) {

                for (var i = 0; i < ele.length; i++) {
                    if (ele[i]._private.group == "nodes") {
                        ele[i].removeClass('node-gray');
                        ele[i].removeClass('node-black');
                        ele[i].removeClass('node-green');
                        ele[i].removeClass('node-blue');
                        ele[i].removeClass('node-purple');
                        ele[i].removeClass('node-red');
                        ele[i].removeClass('node-orange');
                        ele[i].removeClass('node-yellow');
                    }
                    if (ele[i]._private.group == "edges") {
                        ele[i].removeClass('edge-gray');
                        ele[i].removeClass('edge-black');
                        ele[i].removeClass('edge-green');
                        ele[i].removeClass('edge-blue');
                        ele[i].removeClass('edge-purple');
                        ele[i].removeClass('edge-red');
                        ele[i].removeClass('edge-orange');
                        ele[i].removeClass('edge-yellow');
                    }
                }
                return ele;
            },
            view_init: function () {
                var self = this;

                this.cy = cytoscape({
                    container: document.getElementById("cy"), // kontener do renderowania edytora
                    wheelSensitivity: 0.20,
                    elements: [
                        {
                            data: { id: "1", name: "a" },
                            position: { x: 500, y: 400 }
                        },
                        {
                            data: { id: "2", name: "b" },
                            position: { x: 300, y: 400 }
                        },
                        {
                            data: { id: "3", name: "c" },
                            position: { x: 100, y: 400 }
                        },
                        {
                            data: { id: "4", name: "d" },
                            position: { x: 100, y: 600 }
                        },
                        {
                            data: { id: "5", name: "e" },
                            position: { x: 300, y: 600 }
                        },
                        {
                            data: { id: "11", source: "2", target: "4", name: "2" }
                        },
                        {
                            data: { id: "6", source: "1", target: "2", name: "1" }
                        },
                        {
                            data: { id: "7", source: "2", target: "3", name: "3" }
                        },
                        {
                            data: { id: "8", source: "3", target: "4", name: "4" }
                        },
                        {
                            data: { id: "9", source: "4", target: "5", name: "5" }
                        },
                        {
                            data: { id: "10", source: "5", target: "2", name: "6" }
                        },
                        {
                            data: { id: "12", source: "1", target: "5", name: "7" }
                        }
                    ],

                    style: [
                        {
                            selector: "node",
                            style: {
                                label: "data(name)"
                            }
                        },
                        {
                            selector: ".node-green",
                            style: {
                                label: "data(name)",
                                "background-color": "green"
                            }
                        },
                        {
                            selector: ".node-blue",
                            style: {
                                label: "data(name)",
                                "background-color": "#007bff"
                            }
                        },
                        {
                            selector: ".node-purple",
                            style: {
                                label: "data(name)",
                                "background-color": "purple"
                            }
                        },
                        {
                            selector: ".node-red",
                            style: {
                                label: "data(name)",
                                "background-color": "red"
                            }
                        },
                        {
                            selector: ".node-orange",
                            style: {
                                label: "data(name)",
                                "background-color": "orange"
                            }
                        },
                        {
                            selector: ".node-yellow",
                            style: {
                                label: "data(name)",
                                "background-color": "yellow"
                            }
                        },
                        {
                            selector: ".node-black",
                            style: {
                                label: "data(name)",
                                "background-color": "black"
                            }
                        },
                        {
                            selector: ".node-gray",
                            style: {
                                label: "data(name)"
                            }
                        },
                        {
                            selector: ".edge-green",
                            style: {
                                "line-color": "green"
                            }
                        },
                        {
                            selector: ".edge-blue",
                            style: {
                                "line-color": "#007bff"
                            }
                        },
                        {
                            selector: ".edge-purple",
                            style: {
                                "line-color": "purple"
                            }
                        },
                        {
                            selector: ".edge-red",
                            style: {
                                "line-color": "red"
                            }
                        },
                        {
                            selector: ".edge-orange",
                            style: {
                                "line-color": "orange"
                            }
                        },
                        {
                            selector: ".edge-yellow",
                            style: {
                                "line-color": "yellow"
                            }
                        },
                        {
                            selector: ".edge-black",
                            style: {
                                "line-color": "black"
                            }
                        },
                        {
                            selector: ".edge-gray",
                            style: {
                            }
                        },
                        {
                            selector: "edge",
                            style: {
                                width: 3,
                                "text-margin-y": -10
                            }
                        },
                        {
                            selector: ":selected",
                            style: {
                                "background-color": "blue",
                                "line-color": "blue"
                            }
                        },
                        {
                            selector: ".hide-label",
                            style: {
                                label: ""
                            }
                        },
                        {
                            selector: ".show-label",
                            style: {
                                label: "data(name)"
                            }
                        }
                    ],
                    layout: {
                        name: 'preset'
                    }
                });

                //calculating elements amount
                this.cy.on('render', function () {
                    //console.log('event');
                    self.calculateElementsAmount()
                });

                // undo redo
                var ur = this.cy.undoRedo({
                    isDebug: true
                });

                ur.action("addNode", this.addNode, this.addNodeUndo);
                ur.action("addEdge", this.addEdge, this.addEdgeUndo);
                ur.action("changeColor", this.changeColor, this.changeColorUndo);
                ur.action("changeLabel", this.changeLabel, this.changeLabelUndo);
                ur.action("removeElement", this.removeElement, this.removeElementUndo);

                // menu wierzcho³ków lub krawêdzi
                this.cy.cxtmenu({
                    selector: 'node',
                    commands: [
                        {
                            content: 'Toggle label',
                            select: function (ele) {
                                //console.log(ele);
                                if (ele._private.group == "nodes") {
                                    ele.toggleClass('hide-label');
                                }

                                if (ele._private.group == "edges") {
                                    ele.toggleClass('show-label');
                                }
                                //ele.style().selector('node').style('label', '').update();
                                //console.log(ele.style());
                            }
                        },
                        {
                            content: 'Find path',
                            select: function (ele) {
                                //console.log(ele);

                                /*
                                var dijkstra = cy.elements().dijkstra('#e', function(edge){
                                  return edge.data('weight');
                                });

                                var pathToJ = dijkstra.pathTo( cy.$('#j') );
                                var distToJ = dijkstra.distanceTo(cy.$('#j'));
                                */

                                var eleId = ele.data('id');

                                console.log("dasdsa");

                                if (self.pathNodeId1 == '0' && self.pathNodeId2 == '0') {
                                    self.pathNodeId1 = eleId;

                                    self.pathNodeName1 = ele.data('name');
                                    self.pathNodeName2 = '-';
                                    self.pathElementsString = '-';
                                    self.pathElementsIds = [];
                                    self.pathDistance = '-';


                                    self.cy.elements().unselect()
                                } else
                                    if (self.pathNodeId1 != '0' && self.pathNodeId2 == '0') {
                                        self.pathNodeId2 = eleId;
                                        self.pathNodeName2 = ele.data('name');

                                        var dijkstra = self.cy.elements().dijkstra(self.cy.$('#' + self.pathNodeId1), function (edge) {
                                            return parseInt(edge.data('name'));
                                        });

                                        //var pathToJ = dijkstra.pathTo( cy.$('#j') );
                                        //var distToJ = dijkstra.distanceTo(cy.$('#j'));

                                        console.log(dijkstra);

                                        // jak dojdzie tutaj, to ele jest destination
                                        var pathTo = dijkstra.pathTo(ele)
                                        var distTo = dijkstra.distanceTo(ele);

                                        self.pathDistance = distTo;

                                        var pathElementsArray = [];

                                        console.log(pathTo);
                                        pathTo.each(function (e) {
                                            console.log(e.data('name'));

                                            pathElementsArray.push(e.data('name'));
                                            self.pathElementsIds.push(e.data('id'));
                                            // zaznaczenie ka¿dego elementu w œcie¿ce
                                            e.select();
                                        });

                                        console.log(pathTo);

                                        console.log(pathElementsArray);

                                        console.log(self.pathElementsIds)

                                        //console.log(pathElementsArray.toString());

                                        self.pathElementsString = pathElementsArray.join(" -> ");
                                        console.log(self.pathElementsString);

                                        console.log(distTo);
                                        dijkstra = 0;

                                        self.pathNodeId1 = '0';
                                        self.pathNodeId2 = '0';
                                    }
                                ele.select();
                            }
                        },
                        {
                            content: 'Change color',//'<span class="fa fa-star fa-2x"></span>',
                            select: function (ele) {
                                self.cy.$().unselect();
                                var popperElement = document.getElementById(ele._private.data.id);
                                if (!popperElement) {
                                    let node = ele;
                                    let div = document.createElement('div');

                                    div.addEventListener("contextmenu", function (event) {
                                        event.preventDefault();
                                    });

                                    let html = "<table style=\"background:white;\"><tr><th><div id=\"gray\" class=\"one-color\" style=\"background:gray;\"></div></th><th><div class=\"one-color\" id=\"black\" style=\"background:black;\"></div></th><th><div class=\"one-color\" id=\"green\" style=\"background:green;\"></div></th><th><div class=\"one-color\" id=\"blue\" style=\"background:#007bff;\"></div></th></tr><tr><th><div class=\"one-color\" id=\"purple\" style=\"background:purple;\"></div></th><th><div class=\"one-color\" id=\"red\" style=\"background:red;\"></div></th><th><div class=\"one-color\" id=\"orange\" style=\"background:orange;\"></div></th><th><div class=\"one-color\" id=\"yellow\" style=\"background:yellow;\"></div></th></tr></table>";

                                    let popper = node.popper({
                                        content: () => {

                                            div.classList.add('popper');
                                            div.id = ele._private.data.id;
                                            div.innerHTML = html;

                                            document.body.appendChild(div);
                                            return div;
                                        }
                                    });

                                    let update = () => {
                                        popper.scheduleUpdate();
                                    };
                                    node.on('position', update);
                                    node.connectedNodes().on('position', update);
                                    self.cy.on('pan zoom resize', update);

                                    div.addEventListener("click", function (event) {
                                        //console.log(ele);
                                        //console.log(event.target.id);

                                        if (event.target.id != "") {
                                            //console.log("");
                                            ur.do("changeColor", [ele, event.target.id, ele.classes()])
                                            div.parentNode.removeChild(div);
                                        }
                                    })
                                }
                                else {
                                    popperElement.parentNode.removeChild(popperElement);
                                }
                            }
                        },
                        {
                            content: 'Add edge',
                            select: function (ele) {
                                //self.addEdge(ele);
                                //console.log(ele);
                                var eleId = ele._private.data.id;
                                if (self.nodeEdge1 == '0' && self.nodeEdge2 == '0') {
                                    self.nodeEdge1 = eleId;
                                    self.cy.elements().unselect()
                                } else
                                    if (self.nodeEdge1 != '0' && self.nodeEdge2 == '0') {
                                        self.nodeEdge2 = eleId;
                                        ur.do("addEdge", [self.nodeEdge1, self.nodeEdge2]);

                                        self.nodeEdge1 = '0';
                                        self.nodeEdge2 = '0';
                                    }
                                ele.select();
                            }
                        },
                        {
                            content: 'Remove',
                            select: function (ele) {
                                //self.removeElement(ele);
                                ur.do("removeElement", ele);
                            }
                        },
                        {
                            content: 'Change label',
                            select: function (ele) {
                                self.cy.$().unselect();
                                var popperElement = document.getElementById(ele._private.data.id);
                                if (!popperElement) {
                                    let node = ele;
                                    let input = document.createElement('input');
                                    input.placeholder = "New label";
                                    let popper = node.popper({
                                        content: () => {

                                            input.classList.add('popper');
                                            input.id = ele._private.data.id;
                                            input.innerHTML = 'Sticky Popper content';

                                            document.body.appendChild(input);
                                            return input;
                                        }
                                    });

                                    let update = () => {
                                        popper.scheduleUpdate();
                                    };
                                    node.on('position', update);
                                    node.connectedNodes().on('position', update);
                                    self.cy.on('pan zoom resize', update);

                                    input.addEventListener("keyup", function (event) {
                                        if (event.keyCode === 13) {
                                            event.preventDefault();
                                            if (input.value.trim() != '') {
                                                ur.do("changeLabel", [ele, input.value.trim()]);
                                            }
                                            //console.log(ele._private.data);
                                            input.parentNode.removeChild(input);

                                        }
                                    })
                                }
                                else {
                                    popperElement.parentNode.removeChild(popperElement);
                                }
                            }
                        }
                    ],
                    fillColor: 'rgba(0, 0, 0, 0.85)'
                });

                this.cy.cxtmenu({
                    selector: 'edge',
                    commands: [
                        {
                            content: 'Change color',//'<span class="fa fa-star fa-2x"></span>',
                            select: function (ele) {
                                self.cy.$().unselect();
                                var popperElement = document.getElementById(ele._private.data.id);
                                if (!popperElement) {
                                    let node = ele;
                                    let div = document.createElement('div');

                                    div.addEventListener("contextmenu", function (event) {
                                        event.preventDefault();
                                    });

                                    let html = "<table style=\"background:white;\"><tr><th><div id=\"gray\" class=\"one-color\" style=\"background:gray;\"></div></th><th><div class=\"one-color\" id=\"black\" style=\"background:black;\"></div></th><th><div class=\"one-color\" id=\"green\" style=\"background:green;\"></div></th><th><div class=\"one-color\" id=\"blue\" style=\"background:#007bff;\"></div></th></tr><tr><th><div class=\"one-color\" id=\"purple\" style=\"background:purple;\"></div></th><th><div class=\"one-color\" id=\"red\" style=\"background:red;\"></div></th><th><div class=\"one-color\" id=\"orange\" style=\"background:orange;\"></div></th><th><div class=\"one-color\" id=\"yellow\" style=\"background:yellow;\"></div></th></tr></table>";

                                    let popper = node.popper({
                                        content: () => {

                                            div.classList.add('popper');
                                            div.id = ele._private.data.id;
                                            div.innerHTML = html;

                                            document.body.appendChild(div);
                                            return div;
                                        }
                                    });

                                    let update = () => {
                                        popper.scheduleUpdate();
                                    };
                                    node.on('position', update);
                                    node.connectedNodes().on('position', update);
                                    self.cy.on('pan zoom resize', update);

                                    div.addEventListener("click", function (event) {
                                        //console.log(ele);
                                        //console.log(event.target.id);

                                        if (event.target.id != "") {
                                            //console.log("");
                                            ur.do("changeColor", [ele, event.target.id, ele.classes()])
                                            div.parentNode.removeChild(div);
                                        }
                                    })
                                }
                                else {
                                    popperElement.parentNode.removeChild(popperElement);
                                }
                            }
                        },
                        {
                            content: 'Remove',
                            select: function (ele) {
                                //self.removeElement(ele);
                                ur.do("removeElement", ele);
                            }
                        },
                        {
                            content: 'Change weight',
                            select: function (ele) {
                                self.cy.$().unselect();
                                var popperElement = document.getElementById(ele._private.data.id);
                                if (!popperElement) {
                                    let node = ele;
                                    let input = document.createElement('input');
                                    input.placeholder = "New weight";
                                    let popper = node.popper({
                                        content: () => {

                                            input.classList.add('popper');
                                            input.id = ele._private.data.id;
                                            input.innerHTML = 'Sticky Popper content';

                                            document.body.appendChild(input);
                                            return input;
                                        }
                                    });

                                    let update = () => {
                                        popper.scheduleUpdate();
                                    };
                                    node.on('position', update);
                                    node.connectedNodes().on('position', update);
                                    self.cy.on('pan zoom resize', update);

                                    input.addEventListener("keyup", function (event) {
                                        if (event.keyCode === 13) {
                                            event.preventDefault();
                                            if (input.value.trim() != '') {
                                                ur.do("changeLabel", [ele, input.value.trim()]);
                                            }
                                            //console.log(ele._private.data);
                                            input.parentNode.removeChild(input);

                                        }
                                    })
                                }
                                else {
                                    popperElement.parentNode.removeChild(popperElement);
                                }
                            }
                        }
                    ],
                    fillColor: 'rgba(0, 0, 0, 0.85)'
                });

                // menu planszy
                this.cy.cxtmenu({
                    selector: 'core',

                    commands: [
                        {
                            content: 'Add node',
                            select: function (ele, event) {
                                //console.log(event.position);
                                //self.addNode(event.position);
                                ur.do("addNode", event.position);
                            }
                        },
                        {
                            content: 'Remove all',
                            select: function () {
                                self.i = 1;
                                ur.do("removeElement", self.cy.elements());
                            }
                        },
                        {
                            content: 'Remove selected',
                            select: function () {
                                var selectedElements = self.cy.$(':selected');
                                ur.do("removeElement", selectedElements);

                            }
                        }
                    ],
                    fillColor: 'rgba(0, 0, 0, 0.85)'
                });

                this.i = this.cy.elements().length + 1;

                // undo/redo
                document.addEventListener("keydown", function (e) {
                    if (e.ctrlKey && e.target.nodeName === 'BODY') {
                        if (e.which === 90) {
                            ur.undo();
                        }
                        else if (e.which === 89) {
                            //console.log("redo")
                            ur.redo();
                        }
                    }
                });

                // ikony undo i redo
                document.getElementById("undo").addEventListener("click", function () {
                    ur.undo();
                });

                document.getElementById("redo").addEventListener("click", function () {
                    ur.redo();
                });
            },
            calculateIndependentNodeSets: function () {
                var t0 = performance.now();
                var nodeSets = this.calculateMinimumVertexCover();

                this.cy.$().unselect();

                var i = 0;
                var j = 0;
                var minimumVertexCoverSets = [];      // stare nazwy, zmieniæ na independent node sets
                var minimumVertexCoverSetsLabels = [];
                for (i = 0; i < nodeSets.length; i++) {

                    var builtString = "";
                    for (j = 0; j < nodeSets[i].length; j++) {   // buduje stringa ¿eby mo¿na by³o od razu u¿yc filtru na wszystkich wierzcho³kach
                        if (j == 0) {
                            builtString += 'node[id = "' + nodeSets[i][j] + '"]';
                        }
                        else {
                            builtString += ', node[id = "' + nodeSets[i][j] + '"]';
                        }
                    }
                    var minimumVertexSet = this.cy.filter(builtString);
                    //console.log(builtString);
                    //console.log(minimumVertexSet)
                    var setDifference = this.cy.nodes().difference(minimumVertexSet);
                    //console.log(b);
                    //console.log("");

                    var k = 0;

                    minimumVertexCoverSets.push([]);
                    minimumVertexCoverSetsLabels.push([]);
                    for (k = 0; k < setDifference.length; k++) {

                        minimumVertexCoverSets[i].push(setDifference[k]._private.data.id);
                        minimumVertexCoverSetsLabels[i].push(setDifference[k]._private.data.name);
                    }
                }

                this.independentSets = minimumVertexCoverSets;
                this.independentSetsLabels = minimumVertexCoverSetsLabels;

                this.independentNodesOrEdges = 'n';
                this.setsMessage = 'Independent vertex sets:';
                var t1 = performance.now();
                console.log("Maximum independent node set took " + (t1 - t0) + " miliseconds")
            },
            calculateIndependentEdgeSets: function () {
                var t0 = performance.now();
                var startEdge = "";
                var edgeSum = [];

                var nodes = this.cy.nodes();
                var j;
                var i;

                this.cy.$().unselect();

                for (i = 0; i < nodes.length; i++) {
                    var edgesForSingleNode = [];
                    var nodeEdges = nodes[i]._private.edges;
                    for (j = 0; j < nodeEdges.length; j++) {
                        edgesForSingleNode.push(nodeEdges[j]._private.data.id);   // w nawiasach maj¹ byæ kombinacje krawêdzi.... nice

                    }
                    edgeSum.push(edgesForSingleNode)
                }
                //console.log(edgeSum);

                var results = [];
                // kombinacja ka¿dego elementu z ka¿dym
                for (var o = 0; o < edgeSum.length; o++) {
                    for (var h = 0; h < edgeSum[o].length - 1; h++) {
                        for (var k = h + 1; k < edgeSum[o].length; k++) {
                            results.push([edgeSum[o][h], edgeSum[o][k]]);
                        }
                    }
                }

                var q = scriptManager.getMinimumEdgeCoverSets(results);

                // dope³nienie
                var i = 0;
                var j = 0;
                var maximumIndependentEdgeSets = [];      // stare nazwy, zmieniæ na independent node sets
                var maximumIndependentEdgeSetsLabels = [];
                for (i = 0; i < q.length; i++) {

                    var builtString = "";
                    for (j = 0; j < q[i].length; j++) {   // buduje stringa ¿eby mo¿na by³o od razu u¿yc filtru na wszystkich wierzcho³kach
                        if (j == 0) {
                            builtString += 'edge[id = "' + q[i][j] + '"]';
                        }
                        else {
                            builtString += ', edge[id = "' + q[i][j] + '"]';
                        }
                    }
                    var minimumVertexSet = this.cy.filter(builtString);
                    //console.log(builtString);
                    //console.log(minimumVertexSet)
                    var setDifference = this.cy.edges().difference(minimumVertexSet);
                    //console.log(b);
                    //console.log("");

                    var k = 0;

                    maximumIndependentEdgeSets.push([]);
                    maximumIndependentEdgeSetsLabels.push([]);
                    for (k = 0; k < setDifference.length; k++) {

                        maximumIndependentEdgeSets[i].push(setDifference[k]._private.data.id);
                        maximumIndependentEdgeSetsLabels[i].push(setDifference[k]._private.data.name + "");
                    }
                }


                this.independentSets = maximumIndependentEdgeSets;
                this.independentSetsLabels = maximumIndependentEdgeSetsLabels;
                this.independentNodesOrEdges = 'e';
                this.setsMessage = 'Independent edge sets:';
                var t1 = performance.now();
                console.log("Maximum independent edge sets took " + (t1 - t0) + " miliseconds")
            },
            calculateMinimumVertexCover: function () {
                var t0 = performance.now();
                this.cy.$().unselect();

                var edges = this.cy.edges();
                var edgesArray = [];
                var i = 0;
                for (i = 0; i < edges.length; i++) {
                    edgesArray.push([edges[i]._private.data.target, edges[i]._private.data.source]);
                }
                // console.log(edgesArray);
                var q = scriptManager.getMinimumEdgeCoverSets(edgesArray);

                var p = [];
                // zamiana id elementów na ich label, czyli name
                var o;
                var u;
                for (o = 0; o < q.length; o++) {
                    p.push([]);
                    for (u = 0; u < q[o].length; u++) {
                        p[o][u] = (this.cy.getElementById(q[o][u])._private.data.name + "");
                    }
                }

                this.independentSets = q;
                this.independentSetsLabels = p;
                this.independentNodesOrEdges = 'n';
                this.setsMessage = 'Minimal vertex cover:';

                var t1 = performance.now();
                console.log("Minimum vertex cover took " + (t1 - t0) + " miliseconds")
                return q;
            },
            calculateMinimumEdgeCover: function () {
                var t0 = performance.now();
                this.cy.$().unselect();
                var nodes = this.cy.nodes();
                var edgesArray = [];
                var i = 0;
                var j = 0;
                for (i = 0; i < nodes.length; i++) {
                    //console.log(nodes[i]._private.data.name);
                    edgesArray.push([])
                    for (j = 0; j < nodes[i]._private.edges.length; j++) {
                        edgesArray[i].push(nodes[i]._private.edges[j]._private.data.id);
                    }
                }
                //console.log(edgesArray);
                var q = scriptManager.getMinimumEdgeCoverSets(edgesArray);

                var p = [];
                // zamiana id elementów na ich label, czyli name
                var o;
                var u;
                for (o = 0; o < q.length; o++) {
                    p.push([]);
                    for (u = 0; u < q[o].length; u++) {
                        p[o][u] = (this.cy.getElementById(q[o][u])._private.data.name + "");
                    }
                }

                this.independentSets = q;
                this.independentSetsLabels = p;
                this.independentNodesOrEdges = 'e';
                this.setsMessage = 'Minimal edge cover sets:';
                var t1 = performance.now();
                console.log("Minimum edge cover took " + (t1 - t0) + " miliseconds")
            },
            calculateDominatingSets: function () {
                var t0 = performance.now();
                this.cy.$().unselect();
                var nodes = this.cy.nodes();

                var neighborNodesArray = [];

                var i = 0;
                var j = 0;
                for (i = 0; i < nodes.length; i++) {
                    //console.log(nodes[i]._private.data.name);
                    neighborNodesArray.push([])
                    neighborNodesArray[i].push(nodes[i]._private.data.id);
                    for (j = 0; j < nodes[i]._private.edges.length; j++) {
                        if (nodes[i]._private.edges[j]._private.data.source == nodes[i]._private.data.id) {
                            neighborNodesArray[i].push(nodes[i]._private.edges[j]._private.data.target);
                        }
                        else {
                            neighborNodesArray[i].push(nodes[i]._private.edges[j]._private.data.source);
                        }
                    }
                }
                //console.log(neighborNodesArray);
                var q = scriptManager.getMinimumEdgeCoverSets(neighborNodesArray);


                var p = [];
                // zamiana id elementów na ich label, czyli name
                var o;
                var u;
                for (o = 0; o < q.length; o++) {
                    p.push([]);
                    for (u = 0; u < q[o].length; u++) {
                        p[o][u] = (this.cy.getElementById(q[o][u])._private.data.name + "");
                    }
                }
                //console.log(p);

                this.independentSets = q;
                this.independentSetsLabels = p;
                this.independentNodesOrEdges = 'n';
                this.setsMessage = 'Dominating sets:';
                var t1 = performance.now();
                console.log("Minimum dominating sets took " + (t1 - t0) + " miliseconds")
            },
            exportGraph: function () {
                var data = JSON.stringify(this.cy.json());
                var file = new Blob([data], { type: "json" });
                if (window.navigator.msSaveOrOpenBlob)
                {   // IE10+
                    //window.navigator.msSaveOrOpenBlob(file, filename);
                }
                else { // Others
                    var a = document.createElement("a"),
                        url = URL.createObjectURL(file);
                    a.href = url;
                    a.download = "graph.json";
                    document.body.appendChild(a);
                    a.click();
                    setTimeout(function () {
                        document.body.removeChild(a);
                        window.URL.revokeObjectURL(url);
                    }, 0);
                }
            },
            exportGraphAsPhoto: function () {
                var photo = this.cy.jpg({ output: 'blob', full: true });
                var file = new Blob([photo]);
                if (window.navigator.msSaveOrOpenBlob) // IE10+
                {
                    //window.navigator.msSaveOrOpenBlob(file, filename);
                }
                else { // Others
                    var a = document.createElement("a"),
                        url = URL.createObjectURL(file);
                    a.href = url;
                    a.download = "graph.jpg";
                    document.body.appendChild(a);
                    a.click();
                    setTimeout(function () {
                        document.body.removeChild(a);
                        window.URL.revokeObjectURL(url);
                    }, 0);
                }
            },
            loadGraphJson: function () {
                //var fileToLoad = document.getElementById("fileToLoad").files[0];
                var self = this;
                this.cy.elements().remove();
                var fileToLoad = this.file;
                var fileReader = new FileReader();
                var textFromFileLoaded = '';
                fileReader.onload = function (fileLoadedEvent) {
                    textFromFileLoaded = fileLoadedEvent.target.result;
                    //console.log(textFromFileLoaded);
                    self.cy.json(JSON.parse(textFromFileLoaded));
                    self.i = self.cy.elements().length + 1;
                    self.cy.fit();
                };
                //console.log(fileToLoad)

                fileReader.readAsText(fileToLoad, "UTF-8");
            },
            loadGraphTxt: function () {
                //var fileToLoad = document.getElementById("fileToLoad").files[0];
                var self = this;
                var fileToLoad = this.file;
                var fileReader = new FileReader();
                var textFromFileLoaded = '';
                this.i = 0;
                this.cy.elements().remove();    //usuniêcie aktualnego grafu

                fileReader.onload = function (fileLoadedEvent) {
                    textFromFileLoaded = fileLoadedEvent.target.result;
                    //console.log(textFromFileLoaded);


                    var rowsSplittedRaw = textFromFileLoaded.split('\n');
                    var rowsSplitted = rowsSplittedRaw.filter(function (el) {   // usuniêcie pustych wierszy
                        return el != "";
                    });
                    //console.log(rowsSplitted)
                    for (var i = 0; i < rowsSplitted.length; i++) {   // przechodzi przez kolejne wiersze pliku

                        var columnsSplitted = rowsSplitted[i].split('|');
                        //console.log(columnsSplitted)
                        for (var j = 0; j < columnsSplitted.length; j++) {    //przechodzi przez kolejne kolumny wiersza
                            if (i == 0) {   // pierwszy wiersz to nazwy wierzcho³ków

                                self.cy.add({
                                    group: "nodes",
                                    data: { id: self.i, weight: 75, name: columnsSplitted[j] },
                                    weight: 50,
                                });
                            } else if (i > 0) {         // od drugiego wiersza s¹ po³¹czenia miêdzy node'ami

                                if (j > (i - 1)) {        // ¿eby nie tworzy³o krawêdzi dwa razy (macierz jest symetryczna)
                                    if (columnsSplitted[j] != '0') {

                                        self.cy.add({
                                            group: 'edges',
                                            data: { id: self.i, source: i - 1, target: j, name: columnsSplitted[j] }
                                        });
                                    }
                                }
                            }
                            self.i += 1;
                        }
                    }
                    //for (var i = 0; i < )
                    //self.cy.json(JSON.parse(textFromFileLoaded));
                    var layout = self.cy.layout({ name: 'grid' })   // zdefiniowanie i za³adowanie nowego layoutu
                    layout.run();
                };
                //console.log(fileToLoad)
                fileReader.readAsText(fileToLoad, "UTF-8");
            },
            exportGraphAsAdjacencyMatrix: function () {

                var nodes = this.cy.nodes();
                var endString = '';
                for (var i = 0; i < (nodes.length + 1); i++) {  // kolejne wiersze stringa

                    for (var j = 0; j < nodes.length; j++) {  // kolejne nody danego wiersza

                        if (i == 0) {   // pierwszy wiersz to nazwy wierzcho³ków
                            endString += nodes[j]._private.data.name + '|';
                        }
                        else {
                            //if(nodes[j].) // je¿eli node [j] jest po³¹czony z nodem [i-1] -> daj jedynkê
                            var isConnected = false;
                            var edgeName = '';
                            for (var k = 0; k < nodes[j]._private.edges.length; k++) {   // sprawdza krawêdzie po³¹czone z [j], czy nie s¹ po³¹czone tak¿e z [i]
                                var tempEdge = nodes[j]._private.edges[k]._private.data;
                                if (tempEdge.target == nodes[i - 1]._private.data.id) {    // zamiast 1 kiedy jest po³¹czenie, bêdzie nazwa krawêdzi
                                    isConnected = true;
                                    edgeName = tempEdge.name;
                                } else if (tempEdge.source == nodes[i - 1]._private.data.id) {
                                    isConnected = true;
                                    edgeName = tempEdge.name;
                                }
                            }
                            if (isConnected && (nodes[i - 1]._private.data.id != nodes[j]._private.data.id)) {
                                endString += edgeName + '|';
                            }
                            else {
                                endString += 0 + '|';
                            }
                        }
                    }
                    endString = endString.slice(0, -1);
                    if (i == 0) {
                        endString += '\n';  // dodatkowy enter po wierszu z nazwami wierzcho³ków
                    }
                    endString += '\n';
                }
                //console.log(endString);

                var data = endString;      // zapisanie pliku
                var file = new Blob([data]);
                if (window.navigator.msSaveOrOpenBlob) // IE10+
                {
                    //window.navigator.msSaveOrOpenBlob(file, filename);
                }
                else { // Others
                    var a = document.createElement("a"),
                        url = URL.createObjectURL(file);
                    a.href = url;
                    a.download = "graphAdjacencyMatrix.txt";
                    document.body.appendChild(a);
                    a.click();
                    setTimeout(function () {
                        document.body.removeChild(a);
                        window.URL.revokeObjectURL(url);
                    }, 0);
                }
            },
            exportCalculationResults: function () {
                //console.log(this.independentSetsLabels)

                var setsToExport = this.independentSetsLabels;
                //console.log(setsToExport)
                var setsString = this.setsMessage + "\n";

                //console.log(setsToExport)
                for (var i = 0; i < setsToExport.length; i++) {
                    //console.log(setsToExport[i])
                    var joined = setsToExport[i].join('", "');
                    setsString += i + '. [ "' + joined + '" ]\n';
                    //console.log(joined);
                }

                //console.log(setsString)
                var data = setsString;      // zapisanie pliku
                var file = new Blob([data]);
                if (window.navigator.msSaveOrOpenBlob) // IE10+
                {
                    //window.navigator.msSaveOrOpenBlob(file, filename);
                }
                else { // Others
                    var a = document.createElement("a"),
                        url = URL.createObjectURL(file);
                    a.href = url;
                    a.download = "graph_calculation_result.txt";
                    document.body.appendChild(a);
                    a.click();
                    setTimeout(function () {
                        document.body.removeChild(a);
                        window.URL.revokeObjectURL(url);
                    }, 0);
                }
            }
        },
        computed: {

        },
        mounted: function () {
            this.view_init();

            this.$root.$on('loadGraphJson', () => {
                this.loadGraphJson();
                //console.log("loadGraphJson")
            })

            this.$root.$on('loadGraphTxt', () => {
                this.loadGraphTxt();
                //console.log("loadGraphTxt")
            })

            // WARNING. Tutaj zawsze ustalam widocznoœæ wszystkich elementów. USUÑ POTEM!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            this.cy.nodes().removeClass('hide-label');
            this.cy.edges().addClass('show-label');
            //
        }
    }

    function multiDimensionalUnique(arr) {
        var uniques = [];
        var itemsFound = {};
        for (var i = 0, l = arr.length; i < l; i++) {
            var stringified = JSON.stringify(arr[i]);
            if (itemsFound[stringified]) { continue; }
            uniques.push(arr[i]);
            itemsFound[stringified] = true;
        }
        return uniques;
    }

    if (matchMedia) {
        const mq = window.matchMedia("(max-width: 1000px)");
        mq.addListener(WidthChange);
        WidthChange(mq)
    }

    function WidthChange(mq) {
        if (mq.matches) {
            //console.log("less than 1000")

            $("#settings").attr("width", "90%");
            //console.log($("#settings"));
        }
        else {
            //console.log("more than 1000")
            $("#settings").attr("width", "30%");
        }
    }


</script>

<style>

    @media (max-width: 767px) {
        /* On small screens, the nav menu spans the full width of the screen. Leave a space for it. */
        #cy {
            height: 450px;
            top: 50px;
            left: 0px;
            text-align: left;
            position: relative;
            width: 100%;
            border-style: solid;
            display: inline-block;
        }

        #path-panel {
            float: left;
            margin-top: 50px;
            width: 100%;
        }

        #calculate-panel {
            float: left;
            width: 40%;
            text-align: right;
        }

        #independencies-panel {
            position: relative;
            top: 50px;
            width: 40%;
            float: right;
        }
    }

    @media (min-width: 787px) {
        #cy {
            height: 600px;
            top: 50px;
            left: 0px;
            text-align: left;
            position: relative;
            width: 79%;
            border-style: solid;
            display: inline-block;
        }

        #path-panel {
            display: inline-block;
            float: right;
            width: 19%;
            margin-top: 30px;
            min-height: 600px;
            max-height: 600px;
        }

        #calculate-panel {
            float: left;
            text-align: right;
        }

        #independencies-panel {
            position: relative;
            top: 50px;
            float: left;
        }
    }

    body {
        font: 14px helvetica neue, helvetica, arial, sans-serif;
    }

    #independentSets:hover {
        color: blue;
        font-weight: bold;
    }

    #pathString:hover {
        cursor: pointer;
        color: blue;
        font-weight: bold;
    }

    .active {
        color: blue;
        font-weight: bold;
    }

    .form-check-input {
        cursor: pointer;
    }

    .form-check-label {
        cursor: pointer;
    }

    .popper {
        border: 1px solid red;
        background: #fff;
        padding: 0.25em;
    }

    .one-color {
        width: 20px;
        height: 20px;
        margin: 5px;
        border: black;
        border-style: groove;
        border-width: 2px;
        cursor: pointer;
    }

    .one-color-settings {
        width: 20px;
        height: 20px;
        margin: 2px;
        border: black;
        border-style: groove;
        border-width: 2px;
        cursor: pointer;
    }

    .one-color-settings-selected {
        width: 23px;
        height: 23px;
        margin: 2px;
        border: black;
        border-style: groove;
        border-width: 4px;
        cursor: pointer;
    }

        .one-color-settings-selected:after {
            content: '\2713';
            position: relative;
            bottom: 4px;
            left: 1px;
        }
</style>


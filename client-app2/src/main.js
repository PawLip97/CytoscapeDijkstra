import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import { FontAwesomeIcon } from './plugins/font-awesome'
//import VModal from 'vue-js-modal'

import VModalFinal from 'vue-final-modal'

//import UndoRedo from 'cytoscape-undo-redo'
import _ from 'underscore'

createApp(App)
    .use(router)
    .use(store)
  //  .use(VModal)
    .use(VModalFinal())
    //.use(UndoRedo)
    .use(_)
    .component("font-awesome-icon", FontAwesomeIcon)
    .mount("#app");
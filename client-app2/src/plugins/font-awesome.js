import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import {
    faHome,
    faUser,
    faUserPlus,
    faSignInAlt,
    faSignOutAlt,

    faEnvelope, faHeart, faGraduationCap, faInfo, faList, faSpinner, faProjectDiagram, faUpload, faDownload, faCog, faPen, faQuestion, faUndo, faRedo, faCompress, faSync
} from "@fortawesome/free-solid-svg-icons";

import { faFontAwesome, faMicrosoft, faVuejs } from '@fortawesome/free-brands-svg-icons'

library.add(faHome, faUser, faUserPlus, faSignInAlt, faSignOutAlt,
    faEnvelope, faHeart, faGraduationCap, faInfo, faList, faSpinner, faProjectDiagram, faUpload, faDownload, faCog, faPen, faQuestion, faUndo, faRedo, faCompress, faSync,
    faFontAwesome, faMicrosoft, faVuejs
    );

export { FontAwesomeIcon };
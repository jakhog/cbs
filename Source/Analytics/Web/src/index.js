
import React from 'react';
import ReactDOM from "react-dom";
import { BrowserRouter, Route } from "react-router-dom";
import { Provider } from "react-redux";
import { routes } from "./utils/routes";
import rootReducer from "./reducers";
import { createStore, applyMiddleware } from "redux";
import thunk from "redux-thunk";
import {QueryCoordinator} from '@dolittle/queries';

import "./assets/react-leaflet.scss";
import "./assets/main.scss";
import Analytics from './components/Analytics';
import NationalSocietyOverview from './components/NationalSocietyOverview';

QueryCoordinator.apiBaseUrl = process.env.API_BASE_URL;

const store = createStore(rootReducer, applyMiddleware(thunk));

ReactDOM.render(
    <Provider store={store}>
        <BrowserRouter>
            <div>
                {/* <Route path="/analytics/" exact component={Analytics} />  */}
                <Route path="/analytics/" exact component={NationalSocietyOverview} />
            </div>
        </BrowserRouter>
    </Provider>,
    document.getElementById("app")
);

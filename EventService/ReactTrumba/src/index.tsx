import * as React from "react";
import * as ReactDOM from "react-dom";

import { EventForm } from './components/EventForm';
import { EventModel } from './models/EventModel';

import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import 'react-widgets/dist/css/react-widgets.css';
import './css/style.css';

ReactDOM.render(
    <EventForm model={new EventModel()} />,
    document.getElementById("example")
);
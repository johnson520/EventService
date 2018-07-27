import * as React from "react";
import { EventModel } from "./../models/EventModel";
import { EventStartAndDuration } from "./EventStartAndDuration";
import { EventCustomFields } from "./EventCustomFields";
import { QuestionBase } from "./../models/QuestionBase";
import { EventFormState } from "./../models/EventFormState";

export interface EventFormProps {
  model: EventModel;
}
export interface Templates {
  [index: string]: QuestionBase<any>[];
}

// 'HelloProps' describes the shape of props.
// State is never set so we use the '{}' type.
export class EventForm extends React.Component<EventFormProps, EventFormState> {
  private templates: Templates = {};
  private templateNames: string[] = [];

  constructor(props: EventFormProps) {
    super(props);
    this.templates = this.getTemplates();
    this.templateNames = Object.keys(this.templates);
    const initialState = new EventFormState("", []);

    if (this.templateNames.length > 0) {
      initialState.currentTemplate = this.templateNames[0];
      initialState.questions = this.templates[this.templateNames[0]];
    }

    this.state = initialState;
  }

  stateSetter = (key: string, value: any) => {
    var obj: EventFormState = {} as EventFormState;
    obj[key] = value;
    this.setState(obj);
  };

  stateGetter = (key: string) => {
    return this.state[key];
  };

  customFieldGetter = (key: string) => {
    return this.state.customFields[key];
  };

  customFieldSetter = (key: string, value: any) => {
    var cf = this.state.customFields;
    cf[key] = value;
    return this.setState({ customFields: cf });
  };


  onTemplateChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    this.setState({
      currentTemplate: event.target.value,
      questions: this.templates[event.target.value]
    });
  };

  getTemplates(): Templates {
    const xhr = new XMLHttpRequest();
    xhr.open(
      "GET",
      "http://trumbaaddevent.azurewebsites.net/api/templates",
      false
    );
    xhr.send();
    if (xhr.status === 200) {
      return JSON.parse(xhr.responseText).templates;
    }
    return null;
  }

  render() {
    return (
      <div className="formWrapper">
        <form>
          <div id="templateNav">
            <label>Template</label>
            <select
              id="eventTemplate"
              className="form-control"
              value={this.state.currentTemplate}
              onChange={this.onTemplateChange}
            >
              {this.templateNames.map(t => <option value={t} key={t}>{t}</option>)}
            </select>
          </div>
          <div className="templateDivider" />
          <div className="form-row">
            <div className="form-group col-md-9 col-sm-8 col-12">
              <div className="col-12 templateFormField">
                <label className="textInputLabel fieldLabel">
                  {" "}
                  Event Title
                </label>
                <input
                  id="eventTitleInput"
                  value={this.state.eventTitle}
                  onChange={event => {
                    this.stateSetter("eventTitle", event.target.value);
                    this.stateSetter("eventTitleDirty", true);
                  }}
                  type="text"
                  className={`form-control ${
                    this.state.eventTitle ? "" : "isEmpty"
                  } ${
                    this.state["eventTitleDirty"] ? "isDirty" : ""
                  }`}
                  required
                />
              </div>
            </div>
            <div className="form-group col-md-3 col-sm-4 col-12 privateEventWrapper">
              <label className="textInputLabel fieldLabel hiddenLabel">
                Private Event
              </label>
              <div className="form-check checkBoxWrapper">
                <input
                  checked={this.state.eventPrivate}
                  onChange={event =>
                    this.setState({ eventPrivate: event.target.checked })
                  }
                  className="form-check-input"
                  type="checkbox"
                  id="eventPrivate"
                />
                <label className="form-check-label" htmlFor="eventPrivate">
                  Private Event
                </label>
              </div>
            </div>
          </div>
          <div className="form-row">
            <div className="form-group col-md-10 col-sm-9 col-8">
              <div className="col-12">
                <label className="textInputLabel fieldLabel">Location</label>
                <textarea
                  value={this.state.eventLocation}
                  onChange={event =>
                    this.setState({ eventLocation: event.target.value })
                  }
                  id="location"
                  placeholder="123 Alphabet St"
                  className="form-control"
                />
              </div>
            </div>
            <div
              className="form-group col-md-2 col-sm-3 col-4"
              id="addressLinks"
            >
              <label className="textInputLabel fieldLabel hiddenLabel">
                Address Links
              </label>
              <a href="#">Add Map Link</a>
              <a href="#">Enter Lat/Long</a>
              <a href="#">Recent Links</a>
            </div>
          </div>
          <EventStartAndDuration
            stateSetter={this.stateSetter}
            stateGetter={this.stateGetter}
          />
          <EventCustomFields
            questions={this.state.questions}
            stateSetter={this.customFieldSetter}
            stateGetter={this.customFieldGetter}
          />
          <div className="form-row">
            <div className="form-group col-12">
              <div className="col-12">
                <label className="textInputLabel fieldLabel">Description</label>
                <textarea
                  value={this.state.eventDescription}
                  onChange={event =>
                    this.setState({ eventDescription: event.target.value })
                  }
                  id="description"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="form-row buttonRow">
            <div className="col-3">
              <button type="button" className="btn btn-danger col-12">
                Cancel
              </button>
            </div>
            <div className="col-3">
              <button type="button" className="btn btn-secondary col-12">
                Preview
              </button>
            </div>
            <div className="col-3">
              <button type="button" className="btn btn-info col-12">
                Save & Copy
              </button>
            </div>
            <div className="col-3">
              <button type="submit" className="btn btn-success col-12">
                Submit
              </button>
            </div>
          </div>
        </form>
        <pre>{JSON.stringify(this.state, null, "\t")}</pre>
      </div>
    );
  }
}

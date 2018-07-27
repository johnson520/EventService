import * as React from "react";

export interface EventStartAndDurationProps {
  stateSetter: (k: string, v: any) => void;
  stateGetter: (k: string) => any;
}

export class EventStartAndDuration extends React.Component<
  EventStartAndDurationProps
> {
  render() {
    return (
      <div className="form-row">
        <div className="form-group col-lg-4 col-12">
          <div id="dateFormField" className="col-12">
            <label className="textInputLabel fieldLabel">Start Date</label>
            <input
              value={this.props.stateGetter("eventStartDate")}
              onChange={event =>
                this.props.stateSetter("eventStartDate", event.target.value)
              }
              type="date"
              className="form-control"
              placeholder="Start Date"
              required
            />
          </div>
        </div>
        <div className="form-group col-md-5 col-8" hidden={this.props.stateGetter("eventAllDay")}>
          <section id="startTimeSection1">
            <div className="col-12">
              <label className="textInputLabel fieldLabel">Start Time</label>
              <input
                value={this.props.stateGetter("eventStartTime")}
                onChange={event =>
                  this.props.stateSetter("eventStartTime", event.target.value)
                }
                id="eventStartTime"
                className="form-control"
                type="time"
                required
              />
            </div>
          </section>
        </div>
        <div className="form-group col-md-5 col-8" hidden={!this.props.stateGetter("eventAllDay")}>
          <section>
            <div className="col-12">
              <label className="textInputLabel fieldLabel">Days</label>
              <input
                value={this.props.stateGetter("eventDurationDays")}
                onChange={event =>
                  this.props.stateSetter(
                    "eventDurationDays",
                    parseInt(event.target.value)
                  )
                }
                className={`form-control ${
                  this.props.stateGetter("eventDurationDays") === 0  ? "isInvalid" : ""
                }`}
                type="number"
              />
            </div>
          </section>
        </div>
        <div className="form-group col-md-3 col-sm-4 col-4 allDayEventWrapper">
          <label className="textInputLabel fieldLabel hiddenLabel">
            All Day Event
          </label>
          <div className="form-check checkBoxWrapper">
            <input
              checked={this.props.stateGetter("eventAllDay")}
              onChange={event =>
                this.props.stateSetter("eventAllDay", event.target.checked)
              }
              className="form-check-input"
              type="checkbox"
            />
            <label className="form-check-label" htmlFor="eventAllDay">
              All Day Event
            </label>
          </div>
        </div>
        <div className="form-group col-md-6 col-6" hidden={this.props.stateGetter("eventAllDay")}>
          <label className="textInputLabel fieldLabel durationLabel">
            Duration
          </label>
          <section>
            <div className="col-6 brokenDiv">
              <label className="">Hours</label>
              <input
                value={this.props.stateGetter("eventDurationHours")}
                onChange={event =>
                  this.props.stateSetter(
                    "eventDurationHours",
                    parseInt(event.target.value)
                  )
                }
                className={`form-control ${
                  this.props.stateGetter("eventDurationHours") + this.props.stateGetter("eventDurationMinutes") === 0  ? "isInvalid" : ""
                }`}
                min="0"
                type="number"
              />
            </div>
            <div className="col-6 brokenDiv">
              <label className="">Minutes</label>
              <input
                value={this.props.stateGetter("eventDurationMinutes")}
                onChange={event =>
                  this.props.stateSetter(
                    "eventDurationMinutes",
                    parseInt(event.target.value)
                  )
                }
                className={`form-control ${
                  this.props.stateGetter("eventDurationHours") + this.props.stateGetter("eventDurationMinutes") === 0  ? "isInvalid" : ""
                }`}
                min="0"
                max="59"
                step="5"
                type="number"
              />
            </div>
          </section>
        </div>
      </div>
    );
  }
}

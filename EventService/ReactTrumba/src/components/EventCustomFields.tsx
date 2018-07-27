import * as React from "react";
import { QuestionBase } from "./../models/QuestionBase";
import { Multiselect } from 'react-widgets'

export interface CustomFieldProps {
  questions: QuestionBase<any>[];
  stateSetter: (k: string, v: any) => void;
  stateGetter: (k: string) => any;
}

export class EventCustomFields extends React.Component<CustomFieldProps, {}> {

  getValue = (key: string, defaultValue: any) : any => this.props.stateGetter(key) || defaultValue;
  setValue = (key: string, value: any) : void => this.props.stateSetter(key, value);

  render() {
    const elements = [] as JSX.Element[];
    this.props.questions.forEach(q => {
      switch (q.controlType) {
        case "textbox":
          elements.push(
            <div className="form-row" key={q.key}>
              <div className="form-group col-12">
                <div className="col-12 templateFormField">
                  <label className="textInputLabel fieldLabel">{q.label}</label>
                  <input
                    value={this.getValue(q.key, "")}
                    onChange={event =>
                      this.setValue(q.key, event.target.value)
                    }
                    id={q.key}
                    type={q.type}
                    className="form-control"
                    required={q.required}
                  />
                </div>
              </div>
            </div>
          );
          break;
        case "dropdown":
          elements.push(
            <div className="form-row" key={q.key}>
              <div className="form-group col-12">
                <div className="col-12 templateFormField">
                  <label className="textInputLabel fieldLabel">{q.label}</label>
                  <select
                    id={q.key}
                    className="form-control"
                    value={this.getValue(q.key, "")}
                    onChange={event =>
                      this.setValue(q.key, event.target.value)
                    }
                  >
                    {q.options.map(o => (
                      <option value={o.key} key={o.key}>
                        {o.value}
                      </option>
                    ))}
                  </select>
                </div>
              </div>
            </div>
          );
          break;
        case "imagepicker":
          elements.push(
            <div className="form-row" key={q.key}>
              <div className="form-group col-12">
                <div className="col-12 templateFormField">
                  <label className="textInputLabel fieldLabel">{q.label}</label>
                  <select
                    id={q.key}
                    className="form-control"
                    value={this.getValue(q.key, "")}
                    onChange={event =>
                      this.setValue(q.key, event.target.value)
                    }
                  >
                    {q.options.map(o => (
                      <option value={o.key} key={o.key}>
                        {o.value} ({o.url})
                      </option>
                    ))}
                  </select>
                </div>
              </div>
            </div>
          );
          break;
        case "checkbox":
          elements.push(
            <div className="form-row" key={q.key}>
              <div className="form-group col-12">
                <div className="col-12 templateFormField">
                  <div className="form-check checkBoxWrapper customFieldCheckBox">
                    <input
                      checked={this.getValue(q.key, false)}
                      onChange={event =>
                        this.props.stateSetter(q.key, event.target.checked)
                      }
                      className="form-check-input"
                      type="checkbox"
                      id={q.key}
                    />
                    <label className="form-check-label" htmlFor={q.key}>
                      {q.label}
                    </label>
                  </div>
                </div>
              </div>
            </div>
          );
          break;
        case "checkboxgroup":
          elements.push(
            <div className="form-row" key={q.key}>
              <div className="form-group col-12">
                <div className="col-12 templateFormField">
                  <label className="textInputLabel fieldLabel">{q.label}</label>
                  <Multiselect id={q.key} defaultValue={this.getValue(q.key, [])}
                    data={q.options.map(o => ({ key: o.key, value: o.value }))}
                    textField="value"
                    valueField="key"
                    onChange={(items) => this.setValue(q.key, items)}
                    placeholder={`Choose ${q.label}`}
                  />
                </div>
              </div>
            </div>
          );
          break;
        case "richtext":
          elements.push(
            <div className="form-row" key={q.key}>
              <div className="form-group col-12">
                <div className="col-12 templateFormField">
                  <label className="textInputLabel fieldLabel">{q.label}</label>
                  <textarea
                    value={this.getValue(q.key, "")}
                    onChange={event =>
                      this.setValue(q.key, event.target.value)
                    }
                    id={q.key}
                    className="form-control"
                    required={q.required}
                  />
                </div>
              </div>
            </div>
          );

          break;
      }
    });

    return elements;
  }
}

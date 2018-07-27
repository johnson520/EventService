export class EventModel {
  public eventTemplate: string;
  public eventTitle: string;
  public eventPrivate: boolean;
  public eventLocation: string;
  public eventStartDate: string;
  public eventStartTime: string;
  public eventDurationHours: number;
  public eventDurationMinutes: number;
  public eventDurationDays: number;
  public eventRepeat: string;
  public eventAllDay: boolean;
  public eventDescription: string;
  public eventWebLink: string;
  public customFields : { [key: string]: any };
  [key: string]: any;

  constructor() {
    this.eventTemplate = "";
    this.eventTitle = "";
    this.eventPrivate = false;
    this.eventLocation = "";
    this.eventStartDate = "2018-07-26";
    this.eventStartTime = "14:30";
    this.eventDurationHours = 1;
    this.eventDurationMinutes = 0;
    this.eventDurationDays = 1;
    this.eventRepeat = "None";
    this.eventAllDay = false;
    this.eventDescription = "";
    this.eventWebLink = "";
    this.customFields = {};
  }
}

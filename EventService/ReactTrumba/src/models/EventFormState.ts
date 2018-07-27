import { QuestionBase } from './QuestionBase';
import { EventModel } from './EventModel';

export class EventFormState extends EventModel {
    currentTemplate: string;
    questions: QuestionBase<any>[];

    constructor(ct: string, qs: QuestionBase<any>[]) {
        super();
        this.currentTemplate = ct;
        this.questions = qs;
    }
  }
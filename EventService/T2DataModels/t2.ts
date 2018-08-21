// generated from FieldDisplayStyle.cs, FieldType.cs, IAsset.cs, ICalendar.cs, IEvent.cs, IField.cs, IFieldValue.cs, IModel.cs, ITemplate.cs on 8/21/2018 1:45 PM

//	classes and interfaces defined in FieldDisplayStyle.cs:

export const enum FieldDisplayStyle {
	Inline,
	DropDown,
	MultiTag,
	AutoComplete
}

//	classes and interfaces defined in FieldType.cs:

export const enum FieldType {
	SingleLine = 0,
	MultiLine = 1,
	Number = 2,
	Boolean = 3,
	Currency = 4,
	Enumeration = 5,
	Url = 6,
	DateTime = 7,
	TimeSpan = 8,
	RichLocation = 9,
	Period = 10,
	Email = 11,
	PhoneUS = 12,
	PhoneInt = 13,
	PhoneUS10NoExt = 14,
	PhoneUS10OptExt = 15,
	Image = 16,
	CustomAsset = 17
}

//	classes and interfaces defined in IAsset.cs:

export interface IAsset {
	assetID: number;
	displayName?: string;
	fieldValues: Array<IFieldValue>;
}

//	classes and interfaces defined in ICalendar.cs:

export interface ICalendar {
	calendarID: number;
	displayName?: string;
	timeZoneCode?: number;
	allowTimeZoneOverrides?: boolean;
}

//	classes and interfaces defined in IEvent.cs:

export interface IEvent {
	eventID: number;
	ownerCalendarID: number;
	title?: string;
	description?: string;
	weblink?: string;
	startDateTime: string /* DateTime */;
	endDateTime: string /* DateTime */;
	allDay?: boolean;
	fieldValues: Array<IFieldValue>;
}

//	classes and interfaces defined in IField.cs:

export interface IField {
	fieldID: number;
	displayName?: string;
	description?: string;
	fieldType: FieldType;
	htmlEditorEnabled?: boolean;
	showDescription?: boolean;
	conflictChecksEnabled?: boolean;
	requiresValue?: boolean;
	allowedValues: Array<IAsset>;
	allowsMultipleValues?: boolean;
	displayStyle: FieldDisplayStyle;
	minChars?: number;
	maxChars?: number;
	minValue?: number;
	maxValue?: number;
}

//	classes and interfaces defined in IFieldValue.cs:

export interface IFieldValue {
	fieldID: number;
}

//	classes and interfaces defined in IModel.cs:

export interface IModel {
	templates: Array<ITemplate>;
	calendars: Array<ICalendar>;
	currentTemplate: ITemplate;
	currentCalendar: ICalendar;
	currentEvent: IEvent;
}

//	classes and interfaces defined in ITemplate.cs:

export interface ITemplate {
	templateID: number;
	displayName?: string;
	fields: Array<IField>;
	titleField?: number;
	locationField?: number;
	allowLocationOverrides?: boolean;
}


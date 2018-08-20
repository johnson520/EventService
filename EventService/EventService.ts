// generated from AllowedValue.cs, AssetModel.cs, CustomField.cs, EventModel.cs, EventTemplates.cs, FieldType.cs on 8/17/2018 2:49 PM

//	classes and interfaces defined in AllowedValue.cs:

export interface AllowedValue {
	key: string;
	url: string;
	value: string;
}

//	classes and interfaces defined in AssetModel.cs:

export interface AssetModel {
	assetID: number;
	capacity: number;
	capacityLabel: string;
	displayName: string;
	image: ImageObject;
	parentDisplayName: string;
}

export interface AssetCustomField {
	label: string;
	type: FieldType;
	value: any;
}

export interface ImageObject {
	size: ImageSize;
	url: string;
}

export interface ImageSize {
	height: number;
	width: number;
}

export interface AssetsResponse {
	itemNo: number;
	totalItems: number;
}

//	classes and interfaces defined in CustomField.cs:

export interface CustomField {
	allowedValues: Array<AllowedValue>;
	description: string;
	displayName: string;
	displayStyle: string;
	fieldType: FieldType;
	key: string;
	maxChars?: number;
	maxValue?: number;
	minChars?: number;
	minValue?: number;
	multipleValues?: boolean;
	required?: boolean;
}

//	classes and interfaces defined in EventModel.cs:

export interface EventModel {
	eventId: number;
	eventAllDay?: boolean;
	eventDescription: string;
	eventDurationDays: number;
	eventDurationHours: number;
	eventDurationMinutes: number;
	eventLocation: string;
	eventPrivate?: boolean;
	eventRepeat: EventRepeat;
	eventRepeatMonthlyOn: string;
	eventRepeatAnnuallyOn: string;
	eventRepeatDailyEvery: string;
	eventRepeatWeeklyEvery: string;
	eventRepeatMonthlyEvery: string;
	eventRepeatThru: string;
	eventStartDate: string;
	eventStartTime: string;
	eventTemplate: string;
	eventTitle: string;
	eventWebLink: string;
	customFields: { [key: string]: any };
	owningCalendar: string;
}

export const enum EventRepeat {
	None,
	Daily,
	Weekly,
	Monthly,
	Annually
}

//	classes and interfaces defined in EventTemplates.cs:

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


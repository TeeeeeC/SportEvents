export class EventModel {
  eventID: number;
  eventName: string;
  oddsForFirstTeam: number;
  oddsForDraw: number;
  oddsForSecondTeam: number;
  eventStartDate: string;

  constructor(eventID: number) {
    this.eventID = eventID;
  }
}

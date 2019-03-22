import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EventModel } from 'src/models/event';

@Injectable()
export class EventsService {
  baseUrl: string = 'http://localhost:50983/api/events/';

  constructor(private http: HttpClient) { }

  getEvents(): Observable<EventModel[]> {
    return this.http.get<EventModel[]>(this.baseUrl + 'getEvents');
  }

  addEvent(): Observable<EventModel> {
    return this.http.post<EventModel>(this.baseUrl + 'addEvent', {});
  }

  deleteEvent(eventID: number): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'deleteEvent', eventID);
  }

  updateEvent(event: EventModel): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'updateEvent', event);
  }
}

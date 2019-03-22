import { Component, OnInit } from '@angular/core';
import { EventModel } from 'src/models/event';
import { EventsService } from 'src/services/events.service';
import { DatePipe } from '@angular/common'

@Component({
  selector: 'edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})

export class EditComponent implements OnInit {
  events: EventModel[];

  constructor(private eventsService: EventsService, private datepipe: DatePipe) {
    this.events = [];
  }

  ngOnInit() {
    this.getEvents();
  }

  getEvents(): void {
    this.eventsService.getEvents()
      .subscribe(events => { this.events = events });
  }

  addEvent(): void {
    this.eventsService.addEvent()
      .subscribe(eventItem => {
        this.events.push(eventItem);
      });
  }

  deleteEvent(eventID: number): void {
    this.eventsService.deleteEvent(eventID)
      .subscribe(() => {
        this.events = this.events.filter(e => {
          return e.eventID != eventID;
        });
      });
  }

  updateEvent(event: EventModel): void {
    this.eventsService.updateEvent(event)
      .subscribe(() => {
        alert('Update event with id: ' + event.eventID);
      }, errorData => {
        let errors: string[] = [];
        if (errorData.status === 400) {
          for (var fieldName in errorData.error.modelState) {
            errors.push(errorData.error.modelState[fieldName][0]);
          }
        } else {
          errors.push("Internal server error!");
        }

        alert(errors);
      });
  }
}

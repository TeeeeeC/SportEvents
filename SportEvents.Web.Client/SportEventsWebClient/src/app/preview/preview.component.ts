import { Component, OnInit } from '@angular/core';
import { EventsService } from 'src/services/events.service';
import { EventModel } from 'src/models/event';

@Component({
  selector: 'preview',
  templateUrl: './preview.component.html',
  styleUrls: ['./preview.component.css']
})

export class PreviewComponent implements OnInit {
  events: EventModel[];
  utcDate: number;

  constructor(private eventsService: EventsService) {
    this.events = [];
    this.utcDate = Date.parse(new Date().toUTCString());
  }

  ngOnInit() {
    this.getEvents();
  }

  getEvents(): void {
    this.eventsService.getEvents()
      .subscribe(events => this.events = events);
  }

  getClassByStartDate(startDateStr: string): string {
    let startDate = Date.parse(startDateStr);

    if (startDate < this.utcDate) {
      return 'event-expired';
    }

    return '';
  }

  printOdd(eventID: number, oddType: string, oddValue: number): void {
    if (oddValue != null) {
      console.log(eventID + ' ' + oddType + ' ' + oddValue.toFixed(2));
    }
  }
}

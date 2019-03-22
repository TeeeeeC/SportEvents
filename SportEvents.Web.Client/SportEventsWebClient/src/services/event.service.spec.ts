import { EventsService } from "./events.service";
import { EventModel } from 'src/models/event';
import { of } from 'rxjs';

describe('EventService', () => {
  let httpClientSpy: { get: jasmine.Spy };
  let eventsService: EventsService;

  beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get', 'post']);
    eventsService = new EventsService(<any>httpClientSpy);
  });

  it('should return expected events (HttpClient called once)', () => {
    const expectedEvents: EventModel[] =
      [new EventModel(1), new EventModel(2)];

    httpClientSpy.get.and.returnValue(of(expectedEvents));

    eventsService.getEvents().subscribe(
      events => expect(events).toEqual(expectedEvents, 'expected events'),
      fail
    );
    expect(httpClientSpy.get.calls.count()).toBe(1, 'one call');
  });
});

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Event {
  id: number;
  eventTitle: string;
  location: string;
  ticketPrice: number;
}

@Injectable({
  providedIn: 'root'
})
export class EventService {

  private apiUrl = 'https://localhost:7226/api/event';

  constructor(private http: HttpClient) {}

  getEvents(): Observable<Event[]> {
    const url = `${this.apiUrl}?t=${Date.now()}`;
    return this.http.get<Event[]>(url);
  }

  getEvent(id: number): Observable<Event> {
    return this.http.get<Event>(`${this.apiUrl}/${id}`);
  }

  addEvent(event: Event): Observable<Event> {
    return this.http.post<Event>(this.apiUrl, event);
  }

  updateEvent(id: number, event: Event): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, event);
  }

  deleteEvent(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
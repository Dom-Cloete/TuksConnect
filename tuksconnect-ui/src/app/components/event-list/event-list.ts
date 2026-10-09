import { Component, OnInit } from '@angular/core';
import { EventService, Event } from '../../services/event.service';
import { CommonModule } from '@angular/common';
import { RouterModule, Router, ActivatedRoute } from '@angular/router'; 

@Component({
  selector: 'app-event-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './event-list.html',
  styleUrls: ['./event-list.css']
})
export class EventListComponent implements OnInit {

  events: Event[] = [];

  constructor(private service: EventService, private router: Router, private route: ActivatedRoute) {}

  
  ngOnInit(): void {
    this.route.url.subscribe(() => {
      this.loadEvents();
    });

    this.loadEvents();
  }

  loadEvents() {
    this.service.getEvents().subscribe(data => {
      this.events = data;
    });
  }

  deleteEvent(id: number) {
  this.service.deleteEvent(id).subscribe(() => {
    alert('Event deleted successfully');
    this.loadEvents();
  });
}

  editEvent(id: number) {
    this.router.navigate(['/edit', id]);
  }
}
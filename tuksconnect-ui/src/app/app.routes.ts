import { Routes } from '@angular/router';
import { EventListComponent } from './components/event-list/event-list';
import { AddEventComponent } from './components/add-event/add-event';
import { EditEventComponent } from './components/edit-event/edit-event';

export const routes: Routes = [
  { path: '', redirectTo: 'events', pathMatch: 'full' },
  { path: 'events', component: EventListComponent },
  { path: 'add', component: AddEventComponent },
  { path: 'edit/:id', component: EditEventComponent },
  { path: '**', redirectTo: 'events' }
];
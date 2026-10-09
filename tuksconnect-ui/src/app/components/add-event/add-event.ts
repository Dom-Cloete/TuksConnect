import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { EventService } from '../../services/event.service';
import { Router } from '@angular/router';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-add-event',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './add-event.html',
  styleUrls: ['./add-event.css']
})
export class AddEventComponent {

  form;

  constructor(
    private fb: FormBuilder,
    private service: EventService,
    private router: Router
  ) {
    this.form = this.fb.group({
      eventTitle: ['', Validators.required],
      location: ['', Validators.required],
      ticketPrice: [0, Validators.required]
    });
  }

  submit() {
    if (this.form.valid) {
      const event = this.form.value as any;
      this.service.addEvent(event).subscribe(() => {
        this.router.navigate(['/events']);
      });
    }
  }

  cancel() {
    this.router.navigate(['/events']);
  }
}
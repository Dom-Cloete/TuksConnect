import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { EventService } from '../../services/event.service';
import { ActivatedRoute, Router } from '@angular/router';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-edit-event',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './edit-event.html',
  styleUrls: ['./edit-event.css']
})
export class EditEventComponent implements OnInit {

  form;
  id!: number;

  constructor(
    private fb: FormBuilder,
    private service: EventService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.form = this.fb.group({
      id: 0,
      eventTitle: ['', Validators.required],
      location: ['', Validators.required],
      ticketPrice: [0, Validators.required]
    });
  }

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));

    this.service.getEvent(this.id).subscribe((data: any) => {
      this.form.patchValue(data);
    });
  }

  submit() {
    const event = this.form.value as any;
    this.service.updateEvent(this.id, event).subscribe(() => {
      this.router.navigate(['/events']);
    });
  }

  cancel() {
    this.router.navigate(['/events']);
  }
}
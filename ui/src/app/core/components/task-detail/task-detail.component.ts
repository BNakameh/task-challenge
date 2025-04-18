import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Task } from '../../models/task';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-task-detail-modal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './task-detail.component.html',
  styleUrls: ['./task-detail.component.css']
})
export class TaskDetailComponent {
  @Input() task!: Task;

  constructor(public activeModal: NgbActiveModal) {}

  formatDate(dateString: string): string {
    return new Date(dateString).toLocaleDateString();
  }
}

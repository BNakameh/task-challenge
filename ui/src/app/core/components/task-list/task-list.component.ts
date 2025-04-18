import { Component, OnInit } from '@angular/core';
import { Task } from '../../models/task';
import { TaskService } from '../../services/task.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TaskDetailComponent } from '../task-detail/task-detail.component';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css'],
  standalone: true,
  imports: [CommonModule, RouterModule],
  providers: [DatePipe]
})
export class TaskListComponent implements OnInit {
  tasks: Task[] = [];
  isLoading = true;
  error: string | null = null;

  constructor(
    private taskService: TaskService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks(): void {
    this.isLoading = true;
    this.error = null;

    this.taskService.getTasks().subscribe({
      next: (tasks) => {
        this.tasks = tasks;
        this.isLoading = false;
      },
      error: (err) => {
        this.error = 'Failed to load tasks. Please try again later.';
        this.isLoading = false;
        console.error('Error loading tasks:', err);
      }
    });
  }

  viewTaskDetails(taskId: number): void {
    this.taskService.getTaskById(taskId).subscribe({
      next: (task) => {
        const modalRef = this.modalService.open(TaskDetailComponent);
        modalRef.componentInstance.task = task;
      },
      error: (err) => {
        console.error('Error loading task details:', err);
      }
    });
  }
}

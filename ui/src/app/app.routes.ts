import { Routes } from '@angular/router';
import { TaskListComponent } from './core/components/task-list/task-list.component';

export const routes: Routes = [
  { path: 'tasklist', component: TaskListComponent },
  { path: '', redirectTo: 'tasklist', pathMatch: 'full' },
  { path: '**', redirectTo: 'tasklist' }
];

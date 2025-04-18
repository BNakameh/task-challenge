import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TaskListComponent } from './core/components/task-list/task-list.component';

const routes: Routes = [
  { path: 'tasklist', component: TaskListComponent },
  { path: '', redirectTo: '/tasklist', pathMatch: 'full' },
  { path: '**', redirectTo: '/tasklist' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

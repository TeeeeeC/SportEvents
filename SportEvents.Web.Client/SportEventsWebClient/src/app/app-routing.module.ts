import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PreviewComponent } from './preview/preview.component';
import { EditComponent } from './edit/edit.component';

const routes: Routes = [
  {
    path: 'Preview',
    component: PreviewComponent,
  },
  {
    path: 'Edit',
    component: EditComponent,
  },
  {
    path: '',
    redirectTo: '/Preview',
    pathMatch: 'full'
  },
  { path: '**', component: PreviewComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

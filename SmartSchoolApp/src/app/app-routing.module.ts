import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentsComponent } from './Components/students/students.component';
import { TeachersComponent } from './Components/teachers/teachers.component';
import { PerfilComponent } from './Components/perfil/perfil.component';
import { DashboardComponent } from './Components/dashboard/dashboard.component';

const routes: Routes = [
  {path: 'Students', component: StudentsComponent},
  {path: 'Teachers', component: TeachersComponent},
  {path: 'Perfil', component: PerfilComponent},
  {path: 'Dashboard', component: DashboardComponent},
  { path:'', redirectTo:"Dashboard", pathMatch:'full'},
  { path:'**', redirectTo:"Dashboard", pathMatch:'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

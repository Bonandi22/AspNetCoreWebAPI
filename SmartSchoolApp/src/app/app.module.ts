import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { StudentsComponent } from './Components/students/students.component';
import { TeachersComponent } from './Components/teachers/teachers.component';
import { PerfilComponent } from './Components/perfil/perfil.component';
import { NavComponent } from './Components/shared/nav/nav.component';
import { TittleComponent } from './Components/shared/tittle/tittle.component';
import { DashboardComponent } from './Components/dashboard/dashboard.component';

import { BsDropdownModule  } from 'ngx-bootstrap/dropdown';

import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';

@NgModule({
  declarations: [
    AppComponent,
    StudentsComponent,
    TeachersComponent,
    PerfilComponent,
    NavComponent,
    TittleComponent,
    DashboardComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
    timeOut: 3500,
    positionClass: 'toast-bottom-right',
    preventDuplicates: true,
    progressBar: true,
    closeButton: true
    })
  ],

  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }

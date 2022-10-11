import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

//Componentes
import { NavigationComponent } from './components/navigation/navigation.component';
import { LibroFormComponent } from './components/libro-form/libro-form.component';
import { LibroListComponent } from './components/libro-list/libro-list.component';
import { AsignaturaFormComponent } from './components/asignatura-form/asignatura-form.component';
import { AsignaturaListComponent } from './components/asignatura-list/asignatura-list.component';
import { ModalDeleteComponent } from './components/modal/modal-delete.component';

//Services
import { LibrosService } from './services/libros/libros.service'
import { AsignaturasService } from './services/asignaturas/asignaturas.service'

//Material Modules
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table'



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,

    NavigationComponent,
    LibroFormComponent,
    LibroListComponent,
    AsignaturaFormComponent,
    AsignaturaListComponent,
    ModalDeleteComponent
  ],
  entryComponents: [ModalDeleteComponent],
  imports: [
    //BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    MatButtonModule,
    MatCheckboxModule,
    MatDialogModule,
    MatSelectModule,
    MatSidenavModule,
    MatListModule,
    MatTableModule,
    MatToolbarModule,
    MatIconModule,
    MatGridListModule,
    MatMenuModule,
    MatFormFieldModule,
    MatInputModule,
    NoopAnimationsModule

  ],
  providers: [
    LibrosService,
    AsignaturasService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

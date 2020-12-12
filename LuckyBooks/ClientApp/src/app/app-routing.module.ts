import { NgModule } from '@angular/core';
import {Routes,RouterModule} from '@angular/router'
import { CommonModule } from '@angular/common';
import {LibroListComponent} from './components/libro-list/libro-list.component'
import {LibroFormComponent} from './components/libro-form/libro-form.component'
import { AsignaturaListComponent } from './components/asignatura-list/asignatura-list.component';
import { AsignaturaFormComponent } from './components/asignatura-form/asignatura-form.component';

const routes:Routes=[
  {
    path:'',
    redirectTo:'/libros',
    pathMatch:'full'
  },
  {
    path:'libros',
    component:LibroListComponent
  },{
    path:'libros/agregar',
    component:LibroFormComponent
  },
  {
    path:'libros/editar/:id',
    component:LibroFormComponent
  },
  {
    path:'asignaturas',
    component:AsignaturaListComponent
  },{
    path:'asignaturas/agregar',
    component:AsignaturaFormComponent
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

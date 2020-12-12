import { Component, OnInit, ViewChild, Input, Inject } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import {IAsignatura, IEstado} from '../../Models/AsignaturasModel';
import { MatTableDataSource } from '@angular/material/table';
import { AsignaturasService } from '../../services/asignaturas/asignaturas.service';



@Component({
  selector: 'app-asignatura-list',
  templateUrl: './asignatura-list.component.html',
  styleUrls: ['./asignatura-list.component.css']
})
export class AsignaturaListComponent implements OnInit {

  appName: string = 'Asignaturas';
  asignaturas:any=[];

  constructor(private asignaturasService: AsignaturasService) { }
  
  estados: IEstado[] = [
    { value: 1, viewValue: 'Activo' },
    { value: 0, viewValue: 'Inactivo' },

  ];

  dataSource: MatTableDataSource<any>;
  displayedColumns: string[] = ['id_asig', 'descripcion', 'estado', 'Acciones'];
  
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  getAsignaturas(){
    this.asignaturasService.getAsignaturas().subscribe(
      (res:any)=>{     
        this.asignaturas=res;
        this.dataSource=new MatTableDataSource(res);
        this.dataSource.sort=this.sort;
      },
      err=>console.error(err)
      
    )
    
  }

  deleteAsignatura(id: number){

    this.asignaturasService.deleteAsignatura(id)
      .subscribe(
        res=>{
        console.log(res);
        this.getAsignaturas();
        },
        err=>console.error(err)
      )
    
  }


  ngOnInit() {
    this.getAsignaturas();
   
  }

}

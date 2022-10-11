import { Component, OnInit, ViewChild, Input, Inject } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { IAsignatura, IEstado } from '../../Models/AsignaturasModel';
import { MatTableDataSource } from '@angular/material/table';
import { AsignaturasService } from '../../services/asignaturas/asignaturas.service';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material';
import { ModalDeleteComponent } from '../modal/modal-delete.component';



@Component({
  selector: 'app-asignatura-list',
  templateUrl: './asignatura-list.component.html',
  styleUrls: ['./asignatura-list.component.css']
})
export class AsignaturaListComponent implements OnInit {

  //#region Variables
  appName: string = 'Asignaturas';
  asignaturas: any = [];

  estados: IEstado[] = [
    { value: true, viewValue: 'Activo' },
    { value: false, viewValue: 'Inactivo' },

  ];

  asignatura: IAsignatura = {
    id_asig: 0,
    descripcion: '',
    estado: true
  }

  dataSource: MatTableDataSource<any>;
  displayedColumns: string[] = ['id_asig', 'descripcion', 'estado', 'Acciones'];

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  txtFiltro = new FormControl();

  //#endregion

  constructor(
    private asignaturasService: AsignaturasService,
    public dialog: MatDialog
  ) {

  }

  ngOnInit() {
    this.getAsignaturas();

  }


  //#region Filtrado 
  applyFilter(event: any) {
    //Leer el filtro
    const filterValue = event
    this.dataSource.filter = filterValue.trim().toLowerCase();

  }
  //#endregion


  getAsignaturas() {
    this.asignaturasService.getAsignaturas().subscribe(
      (res: any) => {
        this.asignaturas = res;
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
      },
      err => console.error(err)

    )

  }



  getAsignaturasFiltro() {
    this.asignaturasService.postAsignaturasFiltro(this.asignatura).subscribe(
      (res: any) => {
        this.asignaturas = res;
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
      },
      err => console.error(err)
    )
  }

  //#region Abrir Modal
  async openDialog(id, tipo) {
    const dialogRef = this.dialog.open(ModalDeleteComponent, {
      width: '25rem',
      disableClose: false,
      data: {
        id: id,
        tipo: tipo,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {    
      if (result !== undefined) {
        this.getAsignaturas();

      }
    });
  }
  //#endregion

}


import { Component, OnInit, ViewChild, Input, Inject, HostBinding } from '@angular/core';
import { ILibro, IStock } from '../../Models/LibrosModel';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { LibrosService } from '../../services/libros/libros.service';
import { HttpParams } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';
import { ModalDeleteComponent } from '../modal/modal-delete.component';


@Component({
  selector: 'app-libro-list',
  templateUrl: './libro-list.component.html',
  styleUrls: ['./libro-list.component.css']
})
export class LibroListComponent implements OnInit {

  //#region Variables
  appName: string = 'Libros';
  libros: any = [];
  dataSource: MatTableDataSource<any>;
  displayedColumns: string[] = ['Id_libro', 'descripcion', 'asignatura', 'stock', 'Acciones'];

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  stocks: IStock[] = [
    { value: 1, viewValue: 'Todos' },
    { value: 2, viewValue: 'En Stock' },
    { value: 3, viewValue: 'Sin Stock' }
  ];


  libro: ILibro = {
    Id_libro: 0,
    cDescripcion: '',
    cAsignatura: '',
    bStock: 1
  }
  //#endregion

  constructor(
    private librosService: LibrosService,
    public dialog: MatDialog
  ) {

  }

  ngOnInit() {

    this.getLibros();

  }


  //#region Obtener Libros
  getLibros() {
    this.librosService.getLibros().subscribe(
      (res: any) => {

        this.libros = res;

        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
      },
      err => console.error(err)
    )
  }
  //#endregion




  //#region Obtener Libros Con filtrado
  getLibrosFiltro() {
    this.librosService.postLibrosFiltro(this.libro).subscribe(
      (res: any) => {
        console.log(res)
        this.libros = res;
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
      },
      err => console.error(err)
    )
  }
  //#endregion


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
      console.log(result)
      if (result !== undefined) {
        this.getLibros();
      }
    });
  }
  //#endregion

}


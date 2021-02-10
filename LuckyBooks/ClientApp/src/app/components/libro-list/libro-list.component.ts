
import { Component, OnInit, ViewChild, Input, Inject, HostBinding } from '@angular/core';
import {ILibro, IStock} from '../../Models/LibrosModel';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { LibrosService } from '../../services/libros/libros.service';
import { HttpParams } from '@angular/common/http';
import {MatDialog} from '@angular/material/dialog';


@Component({
  selector: 'app-libro-list',
  templateUrl: './libro-list.component.html',
  styleUrls: ['./libro-list.component.css']
})
export class LibroListComponent implements OnInit {

  appName: string = 'Libros';
  libros:any=[];

  constructor(private librosService: LibrosService) { }
  
  dataSource: MatTableDataSource<any>;
  displayedColumns: string[] = ['Id_libro', 'descripcion', 'asignatura', 'stock', 'Acciones'];
  
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  stocks: IStock[] = [
    { value: 1, viewValue: 'Todos' },
    { value: 2, viewValue: 'En Stock' },
    { value: 3, viewValue: 'Sin Stock' }
  ];


  libro:ILibro={
    Id_libro:0,
    cDescripcion:'',
    cAsignatura:'',
    bStock: 1
  }

  /* paramsFiltro = new HttpParams()
  .set('cDescripcion', this.libro.cDescripcion)
  .set('cAsignatura', this.libro.cAsignatura).
  set('bStock',this.libro.bStock);
  
 */

  getLibros(){
    this.librosService.getLibros().subscribe(
      (res:any)=>{
        
        this.libros=res;

        this.dataSource=new MatTableDataSource(res);
        this.dataSource.sort=this.sort;
      },
      err=>console.error(err)
    )
  }

  deleteLibro(id: number){

    this.librosService.deleteLibro(id)
      .subscribe(
        res=>{
        console.log(res);
        this.getLibros();
        },
        err=>console.error(err)
      )
    
  }

  getLibrosFiltro(){
    this.librosService.postLibrosFiltro(this.libro).subscribe(
      (res:any)=>{
        this.libros=res;
        this.dataSource=new MatTableDataSource(res);
        this.dataSource.sort=this.sort;
      },
      err=>console.error(err)
    )
  }

  ngOnInit() {

    this.getLibros();
   
  }

}

//Dialog mover a la clase de arriba
export class DialogContentExample {
  constructor(public dialog: MatDialog) {}

  openDialog() {
    const dialogRef = this.dialog.open(LibroListComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
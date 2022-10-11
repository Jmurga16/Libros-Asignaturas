import { Component, HostBinding, OnInit } from '@angular/core';
import {ILibro, ILibroEdit, IStock} from '../../Models/LibrosModel';
import { ActivatedRoute, Router } from '@angular/router'
import { LibrosService } from '../../services/libros/libros.service';
import { AsignaturasService } from '../../services/asignaturas/asignaturas.service';

@Component({
  selector: 'app-libro-form',
  templateUrl: './libro-form.component.html',
  styleUrls: ['./libro-form.component.css']
})
export class LibroFormComponent implements OnInit {

  @HostBinding('class') classes='row';

  //Estaticos
  appName: string = 'Libros';
  asignaturas:any=[];

  prueba:any=[];
  //opciones:any=[];

  options: IStock[]   = [
    { value: 201, viewValue: 'Computacion' },
    { value: 210, viewValue: 'Calculo' },
    { value: 212, viewValue: 'Matematica' },
    {value:310, viewValue:'Historia Universal'}
  ];

  libro:ILibro={
    Id_libro:0,
    descripcion:'',
    asignatura:'',
    cAsignatura:'',
    stock: 0,
    nId_asig:0
  }

  libroEdit:ILibroEdit={
    Id_libro:0,
    descripcion:'',
    nId_asig:0,
    stock:0
  }

  edit:boolean=false;

  
  constructor(private librosService: LibrosService, private router: Router,
              private activatedRoute: ActivatedRoute, private asignaturasService:AsignaturasService) { }

  saveNewLibro(){
    //console.log(this.libro)
    //eliminar datos al guardar :
    delete this.libro.Id_libro;
    
    //fin eliminar datos
    this.librosService.saveLibro(this.libro)
      .subscribe(
        res=>{        
          this.router.navigate(['/', 'libros']);
        },
        err=>this.router.navigate(['/', 'libros'])
        
      );
    
  }

  getAsignaturas(){
      this.asignaturasService.getAsignaturas().subscribe(
        (res:any)=>{     
          this.asignaturas=res;
          console.log(res);
        },
        err=>console.error(err)
        
      )
    }



  ngOnInit(): void {
    const params = this.activatedRoute.snapshot.params;
    this.getAsignaturas();

    if(params.id){
      this.librosService.getOne(params.id).subscribe(
        (res:any)=>{  
          this.libroEdit=res;
          this.libro.Id_libro=this.libroEdit[0].id_libro;
          this.libro.cDescripcion=this.libroEdit[0].descripcion;
          this.libro.nId_asig=parseInt(this.libroEdit[0].asignatura);
          this.libro.nStock=this.libroEdit[0].stock;
          this.edit=true;
        
        },
        err=>console.error(err)
      );
      }
      
  }

    updateLibro(){
      
      this.librosService.updateLibro(this.libro.Id_libro,this.libro)
        .subscribe(
          res=>{
            this.router.navigate(['/libros']); 
          },
          err=>this.router.navigate(['/libros'])
        );
    }

    fnRouterBack(){
      this.router.navigate(['/libros']); 
    }


}

export class Option {
  nId_asig: number;
  cDescripcion: string;
  constructor(n: number, s:string) {
    this.nId_asig = n;
    this.cDescripcion=s;
  }
}
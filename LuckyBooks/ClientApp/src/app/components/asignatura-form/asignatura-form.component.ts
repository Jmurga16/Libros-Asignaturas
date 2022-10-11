import { Component, HostBinding, OnInit } from '@angular/core';
import { IAsignatura, IEstado, IAsignaturaEdit } from 'src/app/Models/AsignaturasModel';
import { ActivatedRoute, Router } from '@angular/router'
import { AsignaturasService } from '../../services/asignaturas/asignaturas.service';

@Component({
  selector: 'app-asignatura-form',
  templateUrl: './asignatura-form.component.html',
  styleUrls: ['./asignatura-form.component.css']
})
export class AsignaturaFormComponent implements OnInit {

  @HostBinding('class') classes='row';

  //Estaticos
  appName: string = 'Asignaturas';

  estados: IEstado[] = [
    { value: true, viewValue: 'Activo' },
    { value: false, viewValue: 'Inactivo' },

  ];
  
  asignatura:IAsignatura={
    id_asig:0,
    descripcion:'',
    estado:true,
    nId_asig:0,
    cDescripcion:'',
    bEstado:false,
  }

  asignaturaEdit:IAsignaturaEdit={
    id_asig:0,
    descripcion: '',
    estado:true
  }

  edit:boolean=false;


  constructor(private asignaturasService: AsignaturasService, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  saveNewAsignatura(){
    //console.log(this.asignatura)
    //eliminar datos al guardar :
    //delete this.asignatura.id_asig;
    
    //fin eliminar datos
    this.asignaturasService.saveAsignatura(this.asignatura)
      .subscribe(
        res=>{        
          this.router.navigate(['/', 'asignaturas']);
        },
        err=>this.router.navigate(['/', 'asignaturas'])
        
      );
    
  }

  ngOnInit() {
    const params = this.activatedRoute.snapshot.params;

    if(params.id){
      this.asignaturasService.getAsignaturaUnica(params.id).subscribe(
        (res:any)=>{  
          this.asignaturaEdit=res;
          console.log(this.asignatura)
          this.asignatura.id_asig=this.asignaturaEdit[0].id_asig;
          this.asignatura.descripcion=this.asignaturaEdit[0].descripcion;
          this.asignatura.estado=this.asignaturaEdit[0].estado;

          this.edit=true;
        
        },
        err=>console.error(err)
      );
      }
  }

  updateAsignatura(){
      
    this.asignaturasService.updateAsignatura(this.asignatura.id_asig,this.asignatura)
      .subscribe(
        res=>{
          this.router.navigate(['/asignaturas']); 
        },
        err=>this.router.navigate(['/asignaturas'])
      );
  }
  

  fnRouterBack(){
    this.router.navigate(['/asignaturas']); 
  }

}

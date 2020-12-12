import { Component, HostBinding, OnInit } from '@angular/core';
import { IAsignatura, IEstado } from 'src/app/Models/AsignaturasModel';
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
    { value: 1, viewValue: 'Activo' },
    { value: 0, viewValue: 'Inactivo' },

  ];
  
  asignatura:IAsignatura={
    id_asig:0,
    descripcion:'',
    estado:false,
    nId_asig:0,
    cDescripcion:'',
    bEstado:false,
  }

  edit:boolean=false;


  constructor(private asignaturasService: AsignaturasService, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  saveNewAsignatura(){
    //console.log(this.asignatura)
    //eliminar datos al guardar :
    delete this.asignatura.id_asig;
    
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
  }

}

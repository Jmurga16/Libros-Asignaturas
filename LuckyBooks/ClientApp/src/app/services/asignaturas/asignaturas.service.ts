import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {IAsignatura} from '../../Models/AsignaturasModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AsignaturasService {

  API_URI='https://localhost:44302/api'
  constructor( private http:HttpClient) { }

  //getAsignaturas():Observable<any>{
   // return this.http.get<any>('api/asignaturas')
  //}
  getAsignaturas(){
    return this.http.get(`${this.API_URI}/asignaturas`)
  }

  getAsignatura(id:string){
    return this.http.get(`${this.API_URI}/asignaturas/${id}`);
  }

  deleteAsignatura(id:number){
    return this.http.delete(`${this.API_URI}/asignaturas/${id}`);
  }

  saveAsignatura(asignatura: IAsignatura){
    return this.http.post(`${this.API_URI}/asignaturas`,asignatura);
  }

  updateAsignatura(id:string|number,updatedAsignatura: IAsignatura): Observable<IAsignatura>{
    return this.http.put(`${this.API_URI}/asignaturas/${id}`,updatedAsignatura);
  }
}

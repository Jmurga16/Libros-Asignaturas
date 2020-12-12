import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ILibro} from '../../Models/LibrosModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LibrosService {

  API_URI='https://localhost:44302/api'
  
  constructor( private http:HttpClient) { }

  //getLibros():Observable<any>{
   // return this.http.get<any>('api/libros')
  //}
  getLibros(){
    return this.http.get(`${this.API_URI}/libros`)
  }

  getOne(id:string){
    return this.http.get(`${this.API_URI}/libros/editar/${id}`);
  }

  deleteLibro(id:number){
    return this.http.delete(`${this.API_URI}/libros/${id}`);
  }

  saveLibro(libro: ILibro){
    return this.http.post(`${this.API_URI}/libros`,libro);
  }

  updateLibro(id:string|number,updatedLibro: ILibro): Observable<ILibro>{
    return this.http.put(`${this.API_URI}/libros/${id}`,updatedLibro);
  }
}

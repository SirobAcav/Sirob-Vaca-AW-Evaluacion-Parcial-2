import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Conferencia } from '../models/conferencia';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConferenciaService {

  private api="http://localhost:5000/api/Conferencias";

  constructor(private http:HttpClient){}

  getAll():Observable<Conferencia[]>{
    return this.http.get<Conferencia[]>(this.api);
  }

  getById(id:number){
    return this.http.get<Conferencia>(`${this.api}/${id}`);
  }

  create(data:Conferencia){
    return this.http.post(this.api,data);
  }

  update(id:number,data:Conferencia){
    return this.http.put(`${this.api}/${id}`,data);
  }

  delete(id:number){
    return this.http.delete(`${this.api}/${id}`);
  }

}
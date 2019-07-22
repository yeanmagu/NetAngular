import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Books } from '../models/books';
import { ROOT_URL } from '../models/config';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Filter } from '../models/filters';
import { Reporte } from '../models/Reporte';

@Injectable()
export class DataserviceService {

  books: Observable<Books[]>;
  newbook: Books;
  constructor(private http: HttpClient)
  {

  }
  getBooks() {
    console.log(ROOT_URL);
    return this.http.get<Books[]>(ROOT_URL + '/books/getBooks');
  }
  AddBook(obj1: Books) {
    const headers = new HttpHeaders().set('content-type', 'application/json');

    var obj = {
      Titulo: obj1.titulo,
      FechaPublicacion: obj1.fechaPublicacion,
      Edicion: obj1.edicion,
      Costo: obj1.costo,
      PrecioMinorista: obj1.precioMinorista,
      ValoracionId: obj1.valoracionId,
      DescripcionValoracion: obj1.descripcionValoracion
    }
 
    return this.http.post<Books>(ROOT_URL + 'books/post', obj, { headers });
  }
  SearchSell(obj1: Filter) {
    const headers = new HttpHeaders().set('content-type', 'application/json');

    var obj = {
      FechaInicial: obj1.fechaInicial,
      FechaFin: obj1.fechaFin,
      Cliente: obj1.cliente
    }

    return this.http.post<Reporte[]>(ROOT_URL + 'sell/post', obj, { headers });
  }

  EditBook(obj1: Books) {
    const params = new HttpParams().set('ID', obj1.id);
    const headers = new HttpHeaders().set('content-type', 'application/json');

    var obj = {
      Id: obj1.id,
      Titulo: obj1.titulo,
      FechaPublicacion: obj1.fechaPublicacion,
      Edicion: obj1.edicion,
      Costo: obj1.costo,
      PrecioMinorista: obj1.precioMinorista,
      ValoracionId: obj1.valoracionId,
      DescripcionValoracion: obj1.descripcionValoracion
    }
    console.log(obj);
    return this.http.put<Books>(ROOT_URL + 'books/put', obj, { headers, params });
  }

  DeleteBook(obj: Books) {
    const params = new HttpParams().set('id', obj.id);
    const headers = new HttpHeaders().set('content-type', 'application/json');
  
    return this.http.delete<Books>(ROOT_URL + '/books/' + obj.id)  
  }
}


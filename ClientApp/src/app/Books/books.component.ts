import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html'
})
export class BooksComponent {
  public forecasts: BookCast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<BookCast[]>(baseUrl + 'api/books/getBooks').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }



}




interface BookCast {
  id: number;
  titulo: string;
  fechaPublicacion: Date;
  edicion: string;
  costo: number;
  precioMinorista: number;
  valoracionId: number;
  descripcionValoracion: string;
}

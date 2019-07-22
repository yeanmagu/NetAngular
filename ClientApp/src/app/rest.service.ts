

import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable  } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';


const endpoint = 'https://localhost:44367/api/book';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

export class RestService {

  constructor(private http: HttpClient) { }

  private extractData(res: Response) {
    let body = res;
    return body || {};
  }


  getProducts(): Observable<any> {
    return this.http.get(endpoint + 'getBooks').pipe(
      map(this.extractData));
  }

  getProduct(id): Observable<any> {
    return this.http.get(endpoint + 'book/' + id).pipe(
      map(this.extractData));
  }

  addProduct(product): Observable<any> {
    console.log(product);
    return this.http.post<any>(endpoint + 'book', JSON.stringify(product), httpOptions).pipe(
      tap((product) => console.log(`Libro Guardado / id=${product.id}`)),
      catchError(this.handleError<any>('addProduct'))
    );
  }

  updateProduct(id, product): Observable<any> {
    return this.http.put(endpoint + 'book/' + id, JSON.stringify(product), httpOptions).pipe(
      tap(_ => console.log(`updated book id=${id}`)),
      catchError(this.handleError<any>('updateProduct'))
    );
  }

  deleteProduct(id): Observable<any> {
    return this.http.delete<any>(endpoint + 'products/' + id, httpOptions).pipe(
      tap(_ => console.log(`deleted product id=${id}`)),
      catchError(this.handleError<any>('deleteProduct'))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
  
}

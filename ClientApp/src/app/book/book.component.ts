import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { Books } from '../../models/books';
import { DataserviceService } from '../dataservice.service';
import { BookAddComponent } from '../book-add/book-add.component';
import { BookEditComponent } from '../book-edit/book-edit.component';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css'],
  providers: [DataserviceService]
})


export class BookComponent implements OnInit {
  filterBook = '';
  booklist: Books[];
  dataavailbale: Boolean = false;
  tempbook: Books

  constructor(private dataservice: DataserviceService, private route: Router) { }
  ngOnInit() {
    this.LoadData();
  }

  LoadData() {
    this.dataservice.getBooks().subscribe((tempdate) => {
      this.booklist = tempdate;
      console.log(this.booklist);
      if (this.booklist.length > 0) {
        this.dataavailbale = true;
      }
      else {
        this.dataavailbale = false;
      }
    }
    )
      , err => {
        console.log(err);
      }
  }
  deleteconfirmation(id: string) {

    if (confirm("Are you sure you want to delete this ?")) {
      this.tempbook = new Books();
      this.tempbook.id = id;
      this.dataservice.DeleteBook(this.tempbook).subscribe(res => {
        console.log(res);
        alert("Deleted successfully !!!");
        this.LoadData();
      })
    }
  }
  @ViewChild('empadd') addcomponent: BookAddComponent
  @ViewChild('regForm') editcomponent: BookEditComponent
  loadAddnew() {
    this.addcomponent.objBook.titulo = ""
    this.addcomponent.objBook.fechaPublicacion = null
    this.addcomponent.objBook.edicion = ""
    this.addcomponent.objBook.id = ""
    this.addcomponent.objBook.valoracionId = 0
  }
  loadnewForm(id: string, titulo: string, fechaPublicacion: string, edicion: string, valoracionId: number, costo: number, precio: number, descripcion) {
    

    this.editcomponent.objBook.titulo = titulo
    this.editcomponent.objBook.fechaPublicacion = fechaPublicacion.slice(0,10)
    this.editcomponent.objBook.edicion = edicion
    this.editcomponent.objBook.id = id
    this.editcomponent.objBook.valoracionId = valoracionId
    this.editcomponent.objBook.costo = costo
    this.editcomponent.objBook.precioMinorista = precio
    this.editcomponent.objBook.descripcionValoracion = descripcion
  }
  RefreshData() {
    this.LoadData();
  }  

}

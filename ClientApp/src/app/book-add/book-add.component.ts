import { Component, OnInit, Input, Output, ElementRef, ViewChild } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';
import { enableProdMode } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Books } from '../../models/books';
import { Element } from '@angular/compiler';
import { DataserviceService } from '../dataservice.service';
import { NgForm } from '@angular/forms';

enableProdMode();
@Component({
  selector: 'app-book-add',
  templateUrl: './book-add.component.html',
  styleUrls: ['./book-add.component.css']
})
export class BookAddComponent implements OnInit {

  
  @Input() clearData: boolean = false;
  @Output() nameEvent = new EventEmitter();
  objtempbook: Books;
  @Input() objBook: Books = new Books();
  @ViewChild('closeBtn') cb: ElementRef;

  constructor(private dataservice: DataserviceService, private route: Router) {

  }


  ngOnInit() {
  }

  Register(regForm: NgForm) {
    this.objtempbook = new Books();
    this.objtempbook.titulo = regForm.value.titulo;
    this.objtempbook.fechaPublicacion = regForm.value.fechaPublicacion;
    this.objtempbook.costo = regForm.value.costo;
    this.objtempbook.edicion = regForm.value.edicion;
    this.objtempbook.precioMinorista = regForm.value.precio;
    this.objtempbook.valoracionId = regForm.value.valoracionId;
    this.objtempbook.descripcionValoracion = regForm.value.descripcion;
    console.log(this.objtempbook);
    this.dataservice.AddBook(this.objtempbook).subscribe(res => {
      console.log(res);
      alert("Libro Guardado con Exito!");
      this.TakeHome();
    }
    )
  }

  TakeHome() {
    this.nameEvent.emit("ccc");
    this.cb.nativeElement.click();
    this.route.navigateByUrl('book');
  }
}

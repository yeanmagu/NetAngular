import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Filter } from '../../models/filters';
import { NgForm } from '@angular/forms';
import { DataserviceService } from '../dataservice.service';
import { Router } from '@angular/router';
import { Reporte } from '../../models/Reporte';

@Component({
  selector: 'app-search-sells',
  templateUrl: './search-sells.component.html',
  styleUrls: ['./search-sells.component.css'],
  providers: [DataserviceService]
})
export class SearchSellsComponent implements OnInit {

  constructor(private dataservice: DataserviceService, private route: Router) { }

  @Input() objFilter: Filter = new Filter();
  objtempbook: Filter;
  //@ViewChild('regForm') editcomponent: SearchSellsComponent
  dataavailbale: Boolean = false;
  ngOnInit() {
  }
  list:Reporte[];
  Register(regForm: NgForm) {
    this.objtempbook = new Filter();
    this.objtempbook.fechaInicial = regForm.value.fechaInicial;
    this.objtempbook.fechaFin = regForm.value.fechaFin;
    this.objtempbook.cliente = regForm.value.cliente;
    
    this.dataservice.SearchSell(this.objtempbook).subscribe(result => {
      console.log(result);
      this.list = result;
      if (this.list.length > 0) {
        this.dataavailbale = true;
      }
      else {
        this.dataavailbale = false;
      }
    }
    )
  }
}

import { Component, OnInit, EventEmitter, Output, ViewChild, ElementRef, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Books } from '../../models/books';
import { DataserviceService } from '../dataservice.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.css']
})
export class BookEditComponent implements OnInit {

  constructor(private dataservice: DataserviceService, private route: Router) { }
  @Output() nameEvent = new EventEmitter<string>();
  @ViewChild('closeBtn') cb: ElementRef;
  ngOnInit() {
  }

  @Input() reset: boolean = false;
  @ViewChild('regForm') myForm: NgForm;
  @Input() isReset: boolean = false;
  objtempbook: Books;
  @Input() objBook: Books = new Books();

  EditEmployee(regForm: NgForm)
  {
    try {
      this.dataservice.EditBook(this.objBook).subscribe(res => {
        alert("Employee updated successfully");
        this.nameEvent.emit("ccc");
        this.cb.nativeElement.click();
      });
    } catch (e) {
      console.log(e);
    }
    
  }

}

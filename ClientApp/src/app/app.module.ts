import { BrowserModule } from '@angular/platform-browser';
//import { DataTablesModule } from 'angular-datatables';
import { NgModule, ErrorHandler } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BooksComponent } from './books/books.component';
import { BookAddComponent } from './book-add/book-add.component';
import { BookDetailComponent } from './book-detail/book-detail.component';
import { BookEditComponent } from './book-edit/book-edit.component';
import { BookComponent } from './book/book.component';
import { FilterPipe } from './pipes/filter.pipe';
import { SearchSellsComponent } from './search-sells/search-sells.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    BooksComponent,
    BookAddComponent,
    BookDetailComponent,
    BookEditComponent,
    BookComponent,
    FilterPipe,
    SearchSellsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'books', component: BooksComponent },
      { path: 'book', component: BookComponent },
      
      {
        path: 'book-add',
        component: BookAddComponent
      },
      {
        path: 'search',
        component: SearchSellsComponent
      },
      {
        path: 'book-edit/:id',
        component: BookEditComponent
      }
      
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

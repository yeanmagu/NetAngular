import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchSellsComponent } from './search-sells.component';

describe('SearchSellsComponent', () => {
  let component: SearchSellsComponent;
  let fixture: ComponentFixture<SearchSellsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchSellsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchSellsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

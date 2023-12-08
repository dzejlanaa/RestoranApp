import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule} from "@angular/forms"
import { AppComponent } from './app.component';

import { HttpClientModule} from "@angular/common/http";
import { RestoranComponent } from './recepti/restoran.component';
import { RouterModule } from '@angular/router';
import { EditReceptComponent } from './recepti/edit-recept/edit-recept.component';
import { EditJeloComponent } from './recepti/edit-jelo/edit-jelo.component';


@NgModule({
  declarations: [
    AppComponent,
    RestoranComponent,
    EditReceptComponent,
    EditJeloComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      {path: 'recepti', component: RestoranComponent},
      {path: 'edit-recept/:id', component: EditReceptComponent},
      {path: 'edit-jelo/:id', component: EditJeloComponent},
      
    ]),
    FormsModule,
    HttpClientModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

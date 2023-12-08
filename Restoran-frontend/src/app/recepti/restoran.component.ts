import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";




declare function porukaSuccess(a: string): any;

@Component({
  selector: 'app-recepti',
  templateUrl: './restoran.component.html',
  styleUrls: ['./restoran.component.css']
})
export class RestoranComponent implements OnInit {

  title:string = 'Restorani';
  naziv:string = '';
  receptPodaci: any;
  jeloPodaci:any;
  randomPodaci:any;
  odabraniRecept: any=null;
  odabraniStudent: any = null;

  odabranoJelo: any=null;

  opstine: any = [];

 dobavljanje:any = [];
 

  constructor(private httpKlijent: HttpClient) {
  }
  








  testirajWebApi() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Restoran/GetAll").subscribe(x=>{
      this.receptPodaci = x;
    });
  }
  testirajWebApi2() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Jelo/GetAll").subscribe(x=>{
      this.jeloPodaci = x;
    });
  }

  
  testirajWebApi3() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Jelo/Get").subscribe(x=>{
      this.randomPodaci = x;
      this.dobavljanje = this.randomPodaci;
      //console.log(this.dobavljanje);
      
    });
  }
  

 getRestoranPodaci() {
    if (this.receptPodaci == null)
      return [];
    return this.receptPodaci;
  }

  getJeloPodaci() {
    if (this.jeloPodaci == null)
      return [];
    return this.jeloPodaci;
  }

  
  getRandomPodaci() {
    if (this.randomPodaci == null)
      return [];
    return this.randomPodaci;
  }
  
 /*HTML za random

 <button id ="btn1" class="position-absolute top-2 start-50 translate-middle btn btn-light btn-primary rounded-pill" (click)="testirajWebApi3()">
  Ucitaj random jelo
</button>

<table class="table table-warning">
  <tr>
    
    <th>Naziv jela lalalal</th>
    <th>Naziv restorana lalalal</th>
    
    
  </tr>
  <tbody>
  <tr *ngFor="let z of getRandomPodaci()">
   
    <td>{{z.naziv}}</td>
    
    <td>{{z.id}}</td>
    
  </tr>
  </tbody>
</table>
*/
  
  

  ngOnInit(): void {
    //this.loadRandom();
  }



dodajRestoran(){
  this.odabraniRecept = {
    prikazi: true,
    id: 0,
    Naziv: "",
    Adresa: "",
    Telefon: "",
    Tip: "",
    
    name: "Dodaj restoran"
  }
}

urediRecept(student: any){
  this.odabraniRecept = student;
  this.odabraniRecept.name = "Edit student";
  this.odabraniRecept.prikazi = true;
}

dodajJelo(){
  this.odabranoJelo = {
    prikazi: true,
    id: 0,
    Naziv: "",
    Cijena: "",
    restoran_id: 0,
    
    
    name: "Dodaj jelo"
  }
}


urediJelo(student: any){
  this.odabranoJelo = student;
  this.odabranoJelo.name = "Edit student";
  this.odabranoJelo.prikazi = true;
}


/*
loadRandom(){
  return this.httpKlijent.get(MojConfig.adresa_servera + "/Jelo/Get")
    .subscribe((res:any) => {
      this.opstine = res;
    })
}
*/

  }

  





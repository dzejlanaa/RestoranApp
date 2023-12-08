import {Component, Input, OnInit} from '@angular/core';
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";

declare function porukaSuccess(s:string):any;


@Component({
  selector: 'app-edit-jelo',
  templateUrl: './edit-jelo.component.html',
  styleUrls: ['./edit-jelo.component.css']
})
export class EditJeloComponent implements OnInit {

  opstine: any = [];
  @Input()
  urediJelo: any;

  
  constructor(private httpKlijent: HttpClient , private router: ActivatedRoute) {
  }
  ngOnInit(): void {
    this.loadOpstine();
  }
  loadOpstine(){
    return this.httpKlijent.get(MojConfig.adresa_servera + "/Restoran/GetByAll")
      .subscribe((res:any) => {
        this.opstine = res;
      })
  }
  
  spasiPromjene1() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Jelo/Update/" + this.urediJelo.id, this.urediJelo).subscribe((povratnaVrijednost:any) =>{
      porukaSuccess("uredu..." + povratnaVrijednost.naziv);
      this.urediJelo.prikazi = false;
    });
  }

}

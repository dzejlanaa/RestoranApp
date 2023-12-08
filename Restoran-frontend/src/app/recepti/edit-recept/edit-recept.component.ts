import {Component, Input, OnInit} from '@angular/core';
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-edit-recept',
  templateUrl: './edit-recept.component.html',
  styleUrls: ['./edit-recept.component.css']
})
export class EditReceptComponent implements OnInit {

  @Input()
  urediRecept: any;
  urediStudent: any;

  constructor(private httpKlijent: HttpClient , private router: ActivatedRoute) {
  }
  ngOnInit(): void {
  }

    
  spasiPromjene() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Restoran/Update/" + this.urediRecept.id, this.urediRecept).subscribe((povratnaVrijednost:any) =>{
      porukaSuccess("uredu..." + povratnaVrijednost.naziv);
      this.urediRecept.prikazi = false;
    });
  }
  
}

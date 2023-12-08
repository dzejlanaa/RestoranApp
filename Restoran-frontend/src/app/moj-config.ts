import { Observable } from 'rxjs';

import {HttpClient, HttpHeaders} from "@angular/common/http";



export class MojConfig{

  

  

  static adresa_servera = "https://localhost:7025";
  static http_opcije= {
      headers: new HttpHeaders({"Content-Type":"application/json"})
  };

  



  
}



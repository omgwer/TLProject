import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";


export class TodoService {
  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }

  // GetAll() : Observable<TaskDto[]>{
  //   return this.
  // }
}

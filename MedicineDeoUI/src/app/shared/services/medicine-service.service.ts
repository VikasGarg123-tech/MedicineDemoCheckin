import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpRequest, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError, observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Response } from 'selenium-webdriver/http';

@Injectable({
  providedIn: 'root'
})
export class MedicineService {
  baseUrl: string;
  constructor(private http: HttpClient) {
    this.baseUrl = 'http://localhost:59750/api/';
  }

  get(url: string): Observable<any> {
    return this.http.get(this.baseUrl + url).pipe(map((response: Response) => { return <any>response; },
      catchError((error: Response) => { return Observable.throw(error || 'Server-error') })));
  }

  post(url: string, model: any): Observable<any> {
    return this.http.post(this.baseUrl + url, model).pipe(map((response: Response) => { return <any>response; },
      catchError((error: Response) => { return Observable.throw(error || 'Server-error') })));
  }

  put(url: string, model: any): Observable<any> {
    return this.http.put(this.baseUrl + url, model).pipe(map((response: Response) => { return <any>response; },
      catchError((error: Response) => { return Observable.throw(error || 'Server-error') })));
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }

  postMessage(url, subject, body, recipients: string[]) {
    return this.http.post(url, { subject, body, recipients });
  }

}

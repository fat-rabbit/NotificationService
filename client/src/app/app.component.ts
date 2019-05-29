import { Component } from '@angular/core';
import { HttpService } from './http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private http: HttpService) { }

  private url = '';
  private subject = '';
  private body = ''
  private recipient = '';


  private recipients = [];
  private messageId = null;

  private onAddRecipient(recipient: string) {
    this.recipients.push(recipient);
    this.recipient = '';
  }

  private onSubmit(e) {
    this.http.postMessage(this.url, this.subject, this.body, this.recipients)
      .subscribe(res => this.messageId = res);
  }

}

import {EventEmitter, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class DataService {

  baseUrl = 'http://localhost:51615/api/email/'
  emailSelected = new EventEmitter<any>();
  emailDeleted = new EventEmitter<any>();
  user;

  constructor(private http: HttpClient) {

    //Logged user
    this.user = {
      userId: 1,
      firstName: "Radu",
      lastName: "Radu",
      color: "red"
    }
  }

  sendEmail(email: any) {
    console.log(email.receiverEmail)
    console.log(email.subject)
    console.log(email.message)
    console.log(email)
    return this.http.post(this.baseUrl + 'sendEmail', email);
  }

  replayToMail(email: any) {
    return this.http.post(this.baseUrl + 'replayToMail', email);
  }

  deleteMail(conversationId : any){
    return this.http.delete(this.baseUrl + 'deleteMail/' + conversationId)
  }

  getConversationsForUser(userId: any): Observable<any> {
    return this.http.get<any>(this.baseUrl + 'getEmailsForUser/' + userId)
  }

  readEmail(emailId : any){
    console.log(emailId)
    return this.http.post(this.baseUrl + 'readEmail', emailId);
  }

}

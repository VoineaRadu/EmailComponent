import {Component, OnInit} from '@angular/core';
import {NgForm} from "@angular/forms";
import {DataService} from "../../../_services/data.service";

@Component({
  selector: 'app-new-mail',
  templateUrl: './new-mail.component.html',
  styleUrls: ['./new-mail.component.css'],
  host: {
    class: 'router'
  }
})
export class NewMailComponent implements OnInit {

  email: any = {}

  constructor(private dataService: DataService) {
  }

  ngOnInit(): void {
  }

  sendEmail(form: NgForm) {
    this.email.senderId = this.dataService.user.userId;


    this.dataService.sendEmail(this.email).subscribe(value => {

      },
      error => {
        console.log(error)
      })

    form.reset()
  }
}

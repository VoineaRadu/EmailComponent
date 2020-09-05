import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {faArrowRight} from '@fortawesome/free-solid-svg-icons/faArrowRight';
import {faArrowLeft} from '@fortawesome/free-solid-svg-icons/faArrowLeft';
import {faTrash} from '@fortawesome/free-solid-svg-icons/faTrash';
import {NgForm} from "@angular/forms";
import {DataService} from "../../../_services/data.service";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-email-preview',
  templateUrl: './email-preview.component.html',
  styleUrls: ['./email-preview.component.css'],
  host: {
    class: 'router'
  }
})

export class EmailPreviewComponent implements OnInit {

  faArrowRight = faArrowRight;
  faArrowLeft = faArrowLeft;
  faTrash = faTrash;
  emailMessage: any;
  selectedEmail: any;
  @ViewChild('emailForm') form: ElementRef

  constructor(private dataService: DataService, private router: Router) {

    this.selectedEmail = this.router.getCurrentNavigation().extras.state
    if (this.selectedEmail !== undefined && !this.selectedEmail.IsReaded) {
      this.selectedEmail.IsReaded = true
    }
  }

  ngOnInit(): void {
    this.dataService.emailSelected.subscribe((email: any) => {
      this.selectedEmail = email;
      if (!this.selectedEmail.IsReaded) {
        this.selectedEmail.IsReaded = true
      }
    })
  }

  replayMail(form: NgForm) {
    let email = {
      subject: this.selectedEmail.Subject,
      message: this.emailMessage,
      senderId: this.dataService.user.userId,
      receiverEmail: this.selectedEmail.Email,
      ConversationId: this.selectedEmail.ConversationId
    }

    this.dataService.replayToMail(email).subscribe(value => {

      },
      error => {
        console.log(error)
      })

    form.reset()
  }

  deleteMail() {
    this.dataService.deleteMail(this.selectedEmail.ConversationId).subscribe(value => {
        this.dataService.emailDeleted.emit(this.selectedEmail)
        this.selectedEmail = null;
      },
      error => {
        console.log(error)
      })
  }
}

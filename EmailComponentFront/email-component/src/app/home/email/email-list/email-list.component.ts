import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {DataService} from "../../../_services/data.service";
import {faPlusCircle} from '@fortawesome/free-solid-svg-icons/faPlusCircle';
import {Router} from "@angular/router";

@Component({
  selector: 'app-email-list',
  templateUrl: './email-list.component.html',
  styleUrls: ['./email-list.component.css']
})
export class EmailListComponent implements OnInit {

  faPlusCircle = faPlusCircle
  emailConversations: any

  constructor(private dataService: DataService, private router: Router) { }

  ngOnInit(): void {
    this.dataService.getConversationsForUser(this.dataService.user.userId).subscribe((emailConversations : any) => {
      this.emailConversations = emailConversations;
    }, error => {
      console.log(error);
    })

    this.dataService.emailDeleted.subscribe((email: any) => {
      this.emailConversations = this.emailConversations.filter(obj => obj !== email);
    })
  }

  createNewMail(){
    this.router.navigate(['/compose-new'])
  }
}

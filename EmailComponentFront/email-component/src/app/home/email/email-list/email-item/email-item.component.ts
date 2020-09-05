import {Component, Input, OnInit} from '@angular/core';
import {DataService} from "../../../../_services/data.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-email-item',
  templateUrl: './email-item.component.html',
  styleUrls: ['./email-item.component.css']
})
export class EmailItemComponent implements OnInit {

  @Input() email: any;

  constructor(private dataService: DataService,private router: Router) {
  }

  ngOnInit(): void {
  }

  onSelected() {
    if (!this.email.IsReaded) {
      this.dataService.readEmail(this.email.EmailId).subscribe(value => {
        this.email.isReaded = true

      }, error => {
        console.log(error)
      })
    }

    this.dataService.emailSelected.emit(this.email)
    this.router.navigateByUrl('/inbox', { state: this.email });
  }
}

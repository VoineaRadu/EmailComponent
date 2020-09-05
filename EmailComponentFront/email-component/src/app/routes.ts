import {Routes} from "@angular/router";
import {AppComponent} from "./app.component";
import {HomeComponent} from "./home/home.component";
import {NewMailComponent} from "./home/email/new-mail/new-mail.component";
import {EmailComponent} from "./home/email/email.component";
import {EmailPreviewComponent} from "./home/email/email-preview/email-preview.component";

export const appRoutes: Routes = [
  {path: 'inbox', component: EmailPreviewComponent},
  {path: 'compose-new',component: NewMailComponent},
  {path: '**', redirectTo: 'inbox', pathMatch: 'full'},
]

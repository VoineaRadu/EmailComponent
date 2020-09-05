import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppComponent} from './app.component';
import {MenuComponent} from './home/menu/menu.component';
import {EmailComponent} from './home/email/email.component';
import {EmailListComponent} from './home/email/email-list/email-list.component';
import {EmailPreviewComponent} from './home/email/email-preview/email-preview.component';
import {NoopAnimationsModule} from '@angular/platform-browser/animations';
import {MatCardModule} from '@angular/material/card';
import {HttpClientModule} from "@angular/common/http";
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import {FormsModule} from "@angular/forms";
import {EmailItemComponent} from "./home/email/email-list/email-item/email-item.component";
import {RouterModule} from "@angular/router";
import {appRoutes} from "./routes";
import { HomeComponent } from './home/home.component';
import {DataService} from "./_services/data.service";
import {NewMailComponent} from "./home/email/new-mail/new-mail.component";

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    EmailComponent,
    EmailListComponent,
    EmailPreviewComponent,
    EmailItemComponent,
    HomeComponent,
    NewMailComponent
  ],
  imports: [
    BrowserModule,
    NoopAnimationsModule,
    MatCardModule,
    HttpClientModule,
    FontAwesomeModule,
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    DataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {

}

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { PreviewComponent } from './preview/preview.component';
import { EditComponent } from './edit/edit.component';
import { EventsService } from 'src/services/events.service';
import { HttpClientModule } from '@angular/common/http';
import { DatePipe } from '@angular/common'

@NgModule({
  declarations: [
    AppComponent,
    PreviewComponent,
    EditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    EventsService,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

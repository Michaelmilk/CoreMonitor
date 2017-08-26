import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent }  from './app.component';
import { PaneComponent } from './app.component.pane';

@NgModule({
  imports:      [ BrowserModule ],
  declarations: [ AppComponent, PaneComponent],
  bootstrap:    [ AppComponent, PaneComponent]
})
export class StartUpModule { }

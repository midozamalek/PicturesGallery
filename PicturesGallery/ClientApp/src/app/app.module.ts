import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { GalleryListComponent } from './gallery-list/gallery-list.Component';
import { GalleryService } from './gallery-list/gallery.Service';
import { LoginComponent } from './login/login.Component';
import { AuthenticationService } from './authentication-service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    GalleryListComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: GalleryListComponent, pathMatch: 'full' },      
      { path: 'gallery-list', component: GalleryListComponent },
      { path: 'login', component: LoginComponent },
    ])
  ],
  providers: [GalleryService, AuthenticationService],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';

import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';

import {AppRoutingModule} from './app-routing.module'
import { NotifierModule, NotifierOptions } from "angular-notifier";

import { AdminAreaComponent } from './admin-area/admin-area.component';
import { UserAreaComponent } from './user-area/user-area.component';
import { ManagerAreaComponent } from './manager-area/manager-area.component';
//Manager
import{AddNewsComponent} from './manager-area/addNews/addNews.component'
import{NewsItemComponent} from './manager-area/news-item/news-item.component'
//User
import{NewsListComponent}from './user-area/news-list/news-list.component'
import{UserNewsItemComponent} from './user-area/news-list/UserNewsItem/UserNewsItem.component'
import{UserItemNewsComponent} from './user-area/User-itemNews/User-itemNews.component'
import {NewsDescriptionComponent} from './user-area/User-itemNews/newsDescription/newsDescription.component'
import {NewsCommentsComponent} from './user-area/User-itemNews/newsComments/newsComments.component'

import{UserProfilComponent} from './user-area/userProfil/userProfil.component'
import {UserHeaderComponent} from './user-area/userHeader/userHeader.component'

import{EditUserProfileComponent} from './user-area/editUserProfile/editUserProfile.component'

import { NgZorroAntdModule } from './ng-zorro.module';


import { from } from 'rxjs';
const configNotifier: NotifierOptions = {
  position: {
    horizontal: {
      position: 'right'
    },
    vertical: {
      position: 'top'
    }
  }
}
@NgModule({
  declarations: [					
    AppComponent,
    NavMenuComponent,
    HomeComponent,
      SignInComponent,
      SignUpComponent,
      AdminAreaComponent,
      UserAreaComponent,
      ManagerAreaComponent,
      AddNewsComponent,
      NewsItemComponent,
      NewsListComponent,
      UserNewsItemComponent,
      UserItemNewsComponent,
      NewsDescriptionComponent,
      NewsCommentsComponent,
      UserProfilComponent,
      UserHeaderComponent,
      EditUserProfileComponent
   ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    NotifierModule.withConfig(configNotifier),
    NgZorroAntdModule
  ],
  bootstrap:  
  [AppComponent]
})
export class AppModule { }

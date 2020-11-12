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
import { NZ_ICONS } from 'ng-zorro-antd/icon'
import { NZ_I18N, en_US } from 'ng-zorro-antd/i18n';
import * as AllIcons from '@ant-design/icons-angular/icons';
import { IconDefinition } from '@ant-design/icons-angular';

const antDesignIcons = AllIcons as {
  [key: string]: IconDefinition;
};
const icons: IconDefinition[] = Object.keys(antDesignIcons).map(key => antDesignIcons[key])

import { from } from 'rxjs';
import { IconsProviderModule } from './icons-provider.module';
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

import{UserInfoComponent} from './admin-area/userInfo/userInfo.component'
import{AdminProfileComponent} from './admin-area/adminProfile/adminProfile.component'

import {ManagerNewsListComponent} from './manager-area/managerNews-list/managerNews-list.component'
import{ManagerProfileComponent} from './manager-area/managerProfile/managerProfile.component'
import {ManagerNewsItemComponent} from './manager-area/managerNews-list/managerNews-item/managerNews-item.component'
import { Page404Component } from './page404/page404.component';
import{CommentItemComponent} from './user-area/User-itemNews/newsComments/comment-item/comment-item.component'

import{ManagerItemComponent} from './manager-area/managerNews-list/managerNews-item/manager-item/manager-item.component'

import{ManagerHeaderComponent} from './manager-area/manager-header/manager-header.component'

import{SearchNewsListComponent} from './manager-area/searchNews-list/searchNews-list.component'
import{UserSearchListComponent} from './user-area/userSearch-list/userSearch-list.component'

import{EditManagerProfileComponent} from './manager-area/editManagerProfile/editManagerProfile.component'
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
      NewsListComponent,
      UserNewsItemComponent,
      UserItemNewsComponent,
      NewsDescriptionComponent,
      NewsCommentsComponent,
      UserProfilComponent,
      UserHeaderComponent,
      EditUserProfileComponent,
      UserInfoComponent,
      AdminProfileComponent,
      ManagerProfileComponent,
      ManagerNewsListComponent,
      ManagerNewsItemComponent,
      CommentItemComponent,
      ManagerItemComponent,
      ManagerHeaderComponent,
      SearchNewsListComponent,
      UserSearchListComponent,
      EditManagerProfileComponent,
      Page404Component
   ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    NotifierModule.withConfig(configNotifier),
    NgZorroAntdModule,
    IconsProviderModule
  ],
  providers: [
    { provide: NZ_ICONS, useValue: icons }  
],
  bootstrap:  
  [AppComponent]
})
export class AppModule { }

import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { AdminAreaComponent } from './admin-area/admin-area.component';
import { HomeComponent } from './home/home.component';
import { ManagerAreaComponent } from './manager-area/manager-area.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { UserAreaComponent } from './user-area/user-area.component';
import { AddNewsComponent } from './manager-area/addNews/addNews.component'

import { NewsListComponent } from './user-area/news-list/news-list.component'
import { UserItemNewsComponent } from './user-area/User-itemNews/User-itemNews.component'
import { NewsDescriptionComponent } from './user-area/User-itemNews/newsDescription/newsDescription.component';
import { NewsCommentsComponent } from './user-area/User-itemNews/newsComments/newsComments.component';
import{EditUserProfileComponent} from './user-area/editUserProfile/editUserProfile.component'

const routes: Routes = [
    { path: "", pathMatch: "full", component: HomeComponent },
    { path: "sign-in", pathMatch: "full", component: SignInComponent },
    { path: "sign-up", pathMatch: "full", component: SignUpComponent },
    {
        path: "user-panel", component: UserAreaComponent,
        children: [{ path: "", component: NewsListComponent },
        { path: "edit", component: EditUserProfileComponent },
        { path: ":title", component: UserItemNewsComponent }
        ]
    },

    { path: "admin-panel", pathMatch: "full", component: AdminAreaComponent },
    { path: "manager-panel", pathMatch: "full", component: ManagerAreaComponent },
    { path: "add-news", pathMatch: "full", component: AddNewsComponent }
]


@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
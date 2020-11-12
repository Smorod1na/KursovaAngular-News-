import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminAreaComponent } from './admin-area/admin-area.component';
import { AdminProfileComponent } from './admin-area/adminProfile/adminProfile.component';
import { UserInfoComponent } from './admin-area/userInfo/userInfo.component';
import { HomeComponent } from './home/home.component';
import { AddNewsComponent } from './manager-area/addNews/addNews.component';
import { ManagerAreaComponent } from './manager-area/manager-area.component';
import { ManagerNewsListComponent } from './manager-area/managerNews-list/managerNews-list.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { EditUserProfileComponent } from './user-area/editUserProfile/editUserProfile.component';
import { NewsListComponent } from './user-area/news-list/news-list.component';
import { UserAreaComponent } from './user-area/user-area.component';
import { UserItemNewsComponent } from './user-area/User-itemNews/User-itemNews.component';
import { ManagerItemComponent } from './manager-area/managerNews-list/managerNews-item/manager-item/manager-item.component'
import { SearchNewsListComponent } from './manager-area/searchNews-list/searchNews-list.component';
import { UserSearchListComponent } from './user-area/userSearch-list/userSearch-list.component';
import { EditManagerProfileComponent } from './manager-area/editManagerProfile/editManagerProfile.component'
import { NotLoginGuard } from './guards/notLogin.guard';
import { UserGuard } from './guards/user.guard';
import { ManagerGuard } from './guards/manager.guard';
import { AdminGuard } from './guards/admin.guard';
import { Page404Component } from './page404/page404.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: HomeComponent },
  { path: 'sign-up', canActivate: [NotLoginGuard], pathMatch: 'full', component: SignUpComponent },
  { path: 'sign-in', canActivate: [NotLoginGuard], pathMatch: 'full', component: SignInComponent },
  {
    path: 'user-panel',
    canActivate: [UserGuard],
    component: UserAreaComponent,
    children: [
      { path: "", pathMatch: "full", component: NewsListComponent },
   
      { path: "search/:text", pathMatch: "full", component: UserSearchListComponent },
      { path: "edit", pathMatch: "full", component: EditUserProfileComponent },
      { path: ":title", pathMatch: "full", component: UserItemNewsComponent },
    ]
  },
  {
    path: 'manager-panel',
    canActivate: [ManagerGuard],
    component: ManagerAreaComponent,
    children: [
      { path: "", pathMatch: "full", component: ManagerNewsListComponent },
      { path: "edit", pathMatch: "full", component: EditManagerProfileComponent },
      { path: "search/:text", pathMatch: "full", component: SearchNewsListComponent },
      { path: "add-news", pathMatch: 'full', component: AddNewsComponent },
      { path: ":title", pathMatch: "full", component: ManagerItemComponent }
    ]

  },

  {
    path: 'admin-panel',
    canActivate: [AdminGuard],
    component: AdminAreaComponent,
    children: [
      { path: "", pathMatch: "full", component: AdminProfileComponent },
      { path: ":fullname", pathMatch: "full", component: UserInfoComponent },
    ]
  },
  {path:"**",component:Page404Component}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

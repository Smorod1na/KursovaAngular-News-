import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { NotifierService } from 'angular-notifier';
import { AuthService } from '../Services/auth.service';

@Injectable({
    providedIn: 'root'
})
export class AdminGuard implements CanActivate {

    constructor(private authService: AuthService,
        private router: Router,
        private notifier: NotifierService
    ) { }

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        return this.check(state.url);
    }

    check(url: string): boolean {

        if (this.authService.isAdmin())
            return true;

        else {
            this.router.navigate(['/']);
            this.notifier.notify('error', 'you don`t have access')
            return false;
        }
    }
}
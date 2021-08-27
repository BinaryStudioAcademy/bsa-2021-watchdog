import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApprovedGuard } from '@core/guards/approved.guard';
import { AuthGuard } from '@core/guards/auth.guard';
import { UnauthorizedGuard } from '@core/guards/unauthorized.guard';
import { NotFoundComponent } from '@shared/components/not-found/not-found.component';

const routes: Routes = [
    {
        path: 'landing',
        canActivate: [UnauthorizedGuard],
        loadChildren: () => import('./modules/landing/landing.module')
            .then(m => m.LandingModule),
    },
    {
        path: 'home',
        canActivate: [AuthGuard],
        loadChildren: () => import('./modules/home/home.module')
            .then(m => m.HomeModule)
    },
    {
        path: 'signin',
        canActivate: [UnauthorizedGuard],
        loadChildren: () => import('./modules/authorization/authorization.module')
            .then(m => m.AuthorizationModule)
    },
    {
        path: 'signup',
        canActivate: [UnauthorizedGuard],
        loadChildren: () => import('./modules/registration/registration.module')
            .then(m => m.RegistrationModule)
    },
    {
        path: 'user',
        canActivate: [AuthGuard],
        loadChildren: () => import('./modules/user/user.module')
            .then(m => m.UserModule)
    },
    { path: '',
        redirectTo: 'landing',
        pathMatch: 'full'
    },
    { path: '**',
        component: NotFoundComponent,
        pathMatch: 'full'
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

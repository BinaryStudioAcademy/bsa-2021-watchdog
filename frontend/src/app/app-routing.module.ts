import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@core/guards/auth.guard';

const routes: Routes = [
    {
        path: '',
        loadChildren: () => import('./modules/landing/landing.module')
            .then(m => m.LandingModule),
    },
    {
        path: 'home',
        //canActivate: [AuthGuard],
        loadChildren: () => import('./modules/home/home.module')
            .then(m => m.HomeModule)
    },
    {
        path: 'signin',
        loadChildren: () => import('./modules/authorization/authorization.module')
            .then(m => m.AuthorizationModule)
    },
    {
        path: 'signon',
        loadChildren: () => import('./modules/registration/registration.module')
            .then(m => m.RegistrationModule)
    },
    {
        path: 'user',
        loadChildren: () => import('./modules/user/user.module')
            .then(m => m.UserModule)
    },
    { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

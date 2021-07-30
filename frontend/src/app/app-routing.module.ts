import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '',
        loadChildren: () => import('./modules/landing/landing.module')
            .then(m => m.LandingModule),
    },
    {
        path: 'home',
        loadChildren: () => import('./modules/home/home.module')
            .then(m => m.HomeModule),
    },
    {
        path:'auth',
        loadChildren:()=> import('./modules/authorization/authorization.module')
            .then(m=>m.AuthorizationModule)
    },
    { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

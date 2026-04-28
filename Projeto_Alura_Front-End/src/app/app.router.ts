import { Routes } from "@angular/router";
import { AtualizarComponent } from "./pages/atualizar/atualizar";
import { CadastroComponent } from "./pages/cadastro/cadastro";
import { HomeComponent } from "./pages/home/home";
import { LoginComponent } from "./pages/login/login";


export const routes : Routes = [
    {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'cadastro',
        component: CadastroComponent
    },
    {
        path: 'atualizar',
        component: AtualizarComponent
    },
    {
        path: '**',
        redirectTo: 'login'
    }
];
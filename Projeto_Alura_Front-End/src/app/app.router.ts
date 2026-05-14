import { Routes } from "@angular/router";
import { AtualizarComponent } from "./pages/atualizar/atualizar";
import { CadastroComponent } from "./pages/cadastro/cadastro";
import { HomeComponent } from "./pages/home/home";
import { LoginComponent } from "./pages/login/login";
import { CriarCursosComponent } from "./pages/criar-cursos/criar-cursos";
import { FinalizarInscricaoComponent } from "./pages/finalizar-inscricao/finalizar-inscricao";


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
        path:'criar-cursos',
        component: CriarCursosComponent
    },
    {
        path: 'atualizar/:id',
        component: AtualizarComponent
    },
    {
        path: 'finalizar-inscricao/:id',
        component: FinalizarInscricaoComponent
    },
    {
        path: '**',
        redirectTo: 'login'
    }
];
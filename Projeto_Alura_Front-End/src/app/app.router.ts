import { Routes } from "@angular/router";
import { AtualizarComponent } from "./pages/atualizar/atualizar";
import { CadastroComponent } from "./pages/cadastro/cadastro";
import { HomeComponent } from "./pages/home/home";
import { LoginComponent } from "./pages/login/login";
import { CriarCursosComponent } from "./pages/criar-cursos/criar-cursos";
import { FinalizarInscricaoComponent } from "./pages/finalizar-inscricao/finalizar-inscricao";
import { authGuard } from "./guards/auth-guard";


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
        component: HomeComponent,
        canActivate: [authGuard]
    },
    {
        path: 'cadastro',
        component: CadastroComponent,
        canActivate: [authGuard]
    },
    {
        path:'criar-cursos',
        component: CriarCursosComponent,
        canActivate: [authGuard]        
    },
    {
        path: 'atualizar/:id',
        component: AtualizarComponent,
        canActivate: [authGuard]
    },
    {
        path: 'finalizar-inscricao/:id',
        component: FinalizarInscricaoComponent,
        canActivate: [authGuard]
    },
    {
        path: '**',
        redirectTo: 'login'
    }
];
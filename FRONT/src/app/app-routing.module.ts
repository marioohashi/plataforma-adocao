import { EventoAtualizarComponent } from './pages/evento/evento-atualizar/evento-atualizar.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventoListarComponent } from './pages/evento/evento-listar/evento-listar.component';
import { EventoCadastrarComponent } from './pages/evento/evento-cadastrar/evento-cadastrar.component';
import { AnimalListarComponent } from './pages/animal/animal-listar/animal-listar.component';
import { AnimalCadastrarComponent } from './pages/animal/animal-cadastrar/animal-cadastrar.component';
import { OngListarComponent } from './pages/ong/ong-listar/ong-listar.component';
import { OngCadastrarComponent } from './pages/ong/ong-cadastrar/ong-cadastrar.component';
import { PessoaListarComponent } from './pages/pessoa/pessoa-listar/pessoa-listar.component';
import { PessoaCadastrarComponent } from './pages/pessoa/pessoa-cadastrar/pessoa-cadastrar.component';
import { OngAtualizarComponent } from './pages/ong/ong-atualizar/ong-atualizar.component';
import { AnimalAtualizarComponent } from './pages/animal/animal-atualizar/animal-atualizar.component';
import { PessoaAtualizarComponent } from './pages/pessoa/pessoa-atualizar/pessoa-atualizar.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'pages/pessoa/listar',
    pathMatch: 'full'
  },
  {
    path: 'pages/evento/listar',
    component: EventoListarComponent
  },
  {
    path: 'pages/evento/cadastrar',
    component: EventoCadastrarComponent
  },
  {
    path: 'pages/evento/atualizar',
    component: EventoAtualizarComponent
  },
  {
    path: 'pages/animal/listar',
    component: AnimalListarComponent
  },
  {
    path: 'pages/animal/cadastrar',
    component: AnimalCadastrarComponent
  },
  {
    path: 'pages/animal/atualizar',
    component: AnimalAtualizarComponent
  },
  {
    path: 'pages/ong/listar',
    component: OngListarComponent
  },
  {
    path: 'pages/ong/cadastrar',
    component: OngCadastrarComponent
  },
  {
    path: 'pages/ong/atualizar',
    component: OngAtualizarComponent
  },
  {
    path: 'pages/pessoa/listar',
    component: PessoaListarComponent
  },
  {
    path: 'pages/pessoa/cadastrar',
    component: PessoaCadastrarComponent
  },
  {
    path: 'pages/pessoa/atualizar',
    component: PessoaAtualizarComponent
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

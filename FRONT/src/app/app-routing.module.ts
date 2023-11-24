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
    component: EventoListarComponent,
        data: { title: 'Eventos' }

  },
  {
    path: 'pages/evento/cadastrar',
    component: EventoCadastrarComponent,
        data: { title: 'Cadastrar Evento' }

  },
  {
    path: 'pages/evento/atualizar/:id',
    component: EventoAtualizarComponent,
        data: { title: 'Atualizar Evento' }

  },
  {
    path: 'pages/animal/listar',
    component: AnimalListarComponent,
        data: { title: 'Animais para adoção' }

  },
  {
    path: 'pages/animal/cadastrar',
    component: AnimalCadastrarComponent,
        data: { title: 'Cadastrar Animais' }

  },
  {
    path: 'pages/animal/atualizar/:id',
    component: AnimalAtualizarComponent,
        data: { title: 'Atualizar Animais' }

  },
  {
    path: 'pages/ong/listar',
    component: OngListarComponent,
        data: { title: 'ONGs' }

  },
  {
    path: 'pages/ong/cadastrar',
    component: OngCadastrarComponent,
        data: { title: 'Cadastrar ONG' }

  },
  {
    path: 'pages/ong/atualizar/:id',
    component: OngAtualizarComponent,
        data: { title: 'Atualizar ONG' }

  },
  {
    path: 'pages/pessoa/listar',
    component: PessoaListarComponent,
        data: { title: 'Pessoas' }

  },
  {
    path: 'pages/pessoa/cadastrar',
    component: PessoaCadastrarComponent,
        data: { title: 'Cadastrar Pessoa' }

  },
  {
    path: 'pages/pessoa/atualizar/:id',
    component: PessoaAtualizarComponent,
        data: { title: 'Pessoas' }

  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventoListarComponent } from './pages/evento/evento-listar/evento-listar.component';
import { EventoCadastrarComponent } from './pages/evento/evento-cadastrar/evento-cadastrar.component';

const routes: Routes = [
  {
    path : "",
    component : EventoListarComponent
  },
  {
    path : "pages/evento/listar",
    component : EventoListarComponent
  },
  {
    path : "pages/evento/cadastrar",
    component : EventoCadastrarComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

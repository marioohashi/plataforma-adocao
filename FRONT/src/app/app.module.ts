import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AnimalListarComponent } from './pages/animal/animal-listar/animal-listar.component';
import { AnimalCadastrarComponent } from './pages/animal/animal-cadastrar/animal-cadastrar.component';
import { OngListarComponent } from './pages/ong/ong-listar/ong-listar.component';
import { OngCadastrarComponent } from './pages/ong/ong-cadastrar/ong-cadastrar.component';
import { PessoaCadastrarComponent } from './pages/pessoa/pessoa-cadastrar/pessoa-cadastrar.component';
import { PessoaListarComponent } from './pages/pessoa/pessoa-listar/pessoa-listar.component';
import { EventoCadastrarComponent } from './pages/evento/evento-cadastrar/evento-cadastrar.component';
import { EventoListarComponent } from './pages/evento/evento-listar/evento-listar.component';

@NgModule({
  declarations: [
    AppComponent,
    AnimalListarComponent,
    AnimalCadastrarComponent,
    OngListarComponent,
    OngCadastrarComponent,
    PessoaCadastrarComponent,
    PessoaListarComponent,
    EventoCadastrarComponent,
    EventoListarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

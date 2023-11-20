import { MatToolbarModule } from "@angular/material/toolbar";
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";

// Importações do Angular Material
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from "@angular/material/input";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatMenuModule } from "@angular/material/menu";
import { MatDividerModule } from "@angular/material/divider";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatListModule } from "@angular/material/list";
import { MatIconModule } from "@angular/material/icon";
import { MatCardModule } from "@angular/material/card";

// Outras importações do seu projeto
import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app-routing.module";

import { AnimalListarComponent } from "./pages/animal/animal-listar/animal-listar.component";
import { AnimalCadastrarComponent } from "./pages/animal/animal-cadastrar/animal-cadastrar.component";
import { OngListarComponent } from "./pages/ong/ong-listar/ong-listar.component";
import { OngCadastrarComponent } from "./pages/ong/ong-cadastrar/ong-cadastrar.component";
import { PessoaCadastrarComponent } from "./pages/pessoa/pessoa-cadastrar/pessoa-cadastrar.component";
import { PessoaListarComponent } from "./pages/pessoa/pessoa-listar/pessoa-listar.component";
import { EventoCadastrarComponent } from "./pages/evento/evento-cadastrar/evento-cadastrar.component";
import { EventoListarComponent } from "./pages/evento/evento-listar/evento-listar.component";

import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { OngAtualizarComponent } from "./pages/ong/ong-atualizar/ong-atualizar.component";
import { AnimalAtualizarComponent } from "./pages/animal/animal-atualizar/animal-atualizar.component";
import { PessoaAtualizarComponent } from "./pages/pessoa/pessoa-atualizar/pessoa-atualizar.component";
import { EventoAtualizarComponent } from "./pages/evento/evento-atualizar/evento-atualizar.component";
import { LoginComponent } from './login/login.component';

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
    EventoListarComponent,
    OngAtualizarComponent,
    AnimalAtualizarComponent,
    PessoaAtualizarComponent,
    EventoAtualizarComponent,
    LoginComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatMenuModule,
    MatDividerModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    MatToolbarModule,
    MatCardModule,
    MatInputModule,
    AppRoutingModule,
    FormsModule,
    MatSnackBarModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

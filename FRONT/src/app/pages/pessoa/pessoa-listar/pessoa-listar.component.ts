import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Pessoa } from "src/app/models/pessoa.model";
import { Router } from "@angular/router";
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';



@Component({
  selector: "app-pessoa-listar",
  templateUrl: "./pessoa-listar.component.html", // Referenciando o novo arquivo HTML
  styleUrls: ["./pessoa-listar.component.css"],
})
export class PessoaListarComponent implements OnInit {
  colunasTabela: string[] = [
    "pessoaId",
    "nome",
    "endereco",
    "numeroTelefone",
    "email",
    "animalId",
    "criadoEm",
    "deletar",
    "alterar",
  ];
  pessoas: Pessoa[] = [];

  constructor(private client: HttpClient,     private router: Router
    ) {}

  ngOnInit(): void {
    this.client
      .get<Pessoa[]>("https://localhost:7195/api/pessoa/listar")
      .subscribe({
        next: (pessoas) => {
          console.table(pessoas);
          this.pessoas = pessoas;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  deletar(pessoaId: number) {
    this.client
      .delete<Pessoa[]>(
        `https://localhost:7195/api/pessoa/deletar/${pessoaId}`
      )
      .subscribe({
        next: (pessoas) => {
          this.pessoas = pessoas;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }
  atualizar(pessoaId: number) {
    this.router.navigate(['/pages/pessoa/atualizar', pessoaId]);
  }  
}
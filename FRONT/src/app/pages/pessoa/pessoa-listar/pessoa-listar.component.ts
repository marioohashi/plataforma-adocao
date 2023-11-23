import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Pessoa } from "src/app/models/pessoa.model";
import { Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { MatMenuModule } from "@angular/material/menu";
import { MatButtonModule } from "@angular/material/button";
import { MatDividerModule } from "@angular/material/divider";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatListModule } from "@angular/material/list";
import { MatIconModule } from "@angular/material/icon";

@Component({
  selector: "app-pessoa-listar",
  templateUrl: "./pessoa-listar.component.html",
  styleUrls: ["./pessoa-listar.component.css", "../../../app.component.css"],
})
export class PessoaListarComponent implements OnInit {
  pessoas: Pessoa[] = [];

  constructor(
    private client: HttpClient,
    private router: Router,
    private snackBar: MatSnackBar
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

  deletar(pessoaId: number): void {
    if (confirm("Tem certeza que deseja deletar essa pessoa?")) {
      this.client
        .delete<Pessoa[]>(
          `https://localhost:7195/api/pessoa/delete/${pessoaId}`
        )
        .subscribe({
          // Requisição com sucesso
          next: () => {
            // Remove o evento da lista local
            this.pessoas = this.pessoas.filter(
              (pessoa) => pessoa.pessoaId !== pessoaId
            );

            this.snackBar.open("Evento deletado com sucesso!", "Deletado(a)", {
              duration: 1500,
              horizontalPosition: "right",
              verticalPosition: "top",
            });
          },
          // Tratamento de erro
          error: (erro) => {
            console.log(erro);
            this.snackBar.open("Erro ao deletar pessoa.", "Tente novamente", {
              duration: 1500,
              horizontalPosition: "right",
              verticalPosition: "top",
            });
          },
        });
    }
  }
  atualizar(pessoaId: number) {
    this.router.navigate(["pages/pessoa/atualizar", pessoaId]);
  }
}

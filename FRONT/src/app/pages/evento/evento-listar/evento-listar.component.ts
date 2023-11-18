import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Evento } from "src/app/models/evento.model";
import { Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";

@Component({
  selector: "app-evento-listar",
  templateUrl: "./evento-listar.component.html",
  styleUrls: ["./evento-listar.component.css"],
})
export class EventoListarComponent implements OnInit {
  colunasTabela: string[] = [
    "eventoId",
    "nome",
    "descricao",
    "ong",
    "dataEvento",
    "criadoEm",
    "deletar",
    "alterar",
  ];
  eventos: Evento[] = [];

  constructor(
    private client: HttpClient,
    private snackBar: MatSnackBar,
    private router: Router
  ) {
    // Um problema de CORS ao fazer uma requisição para a nossa API
  }

  ngOnInit(): void {
    this.client
      .get<Evento[]>("https://localhost:7195/api/evento/listar")
      .subscribe({
        next: (eventos) => {
          console.table(eventos);
          this.eventos = eventos;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  deletar(eventoId: number): void {
    if (confirm("Tem certeza que deseja deletar esse evento?")) {
      this.client
        .delete(`https://localhost:7195/api/evento/delete/${eventoId}`)
        .subscribe({
          // Requisição com sucesso
          next: () => {
            // Remove o evento da lista local
            this.eventos = this.eventos.filter(
              (evento) => evento.eventoId !== eventoId
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
            this.snackBar.open(
              "Erro ao deletar esse evento.",
              "Tente novamente",
              {
                duration: 1500,
                horizontalPosition: "right",
                verticalPosition: "top",
              }
            );
          },
        });
    }
  }

  atualizar(eventoId: number) {
    this.router.navigate(["/pages/evento/atualizar", eventoId]);
  }
}

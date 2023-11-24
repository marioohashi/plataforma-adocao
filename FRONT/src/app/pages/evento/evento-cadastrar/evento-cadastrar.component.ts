import { Component } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from "@angular/router";
import { ONG } from "src/app/models/ong.model";

@Component({
  selector: "app-evento-cadastrar",
  templateUrl: "./evento-cadastrar.component.html",
  styleUrls: ["./evento-cadastrar.component.css"],
})
export class EventoCadastrarComponent {
  nome: string = "";
  descricao: string = "";
  ongId: number = 0;
  ongs: ONG[] = [];
  dataEvento: string = "";

  constructor(
    private client: HttpClient,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.client
    .get<ONG[]>("https://localhost:7195/api/ong/listar")
    .subscribe({
      next: (ongs) => {
        console.table(ongs);
        this.ongs = ongs;
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }

  cadastrar(): void {
    const dataAtual = new Date().toISOString().split("T")[0];
    if (this.dataEvento < dataAtual) {
      this.snackBar.open(
        "A data do evento não pode ser anterior à data atual.",
        "Erro",
        {
          duration: 3000,
          horizontalPosition: "right",
          verticalPosition: "top",
        }
      );
      return;
    }

    let evento = {
      nome: this.nome,
      descricao: this.descricao,
      ongId: this.ongId,
      dataEvento: this.dataEvento,
      criadoEm: new Date(),
    };

    this.client
      .post("https://localhost:7195/api/evento/cadastrar", evento)
      .subscribe({
        next: () => {
          this.snackBar.open("Evento cadastrado com sucesso!", "E-commerce", {
            duration: 1500,
            horizontalPosition: "right",
            verticalPosition: "top",
          });
          this.router.navigate(["pages/evento/listar"]);
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }
}

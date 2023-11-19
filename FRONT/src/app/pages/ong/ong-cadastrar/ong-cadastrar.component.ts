// ong-cadastrar.component.ts
import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from "@angular/router";
import { ONG } from "src/app/models/ong.model";

@Component({
  selector: "app-ong-cadastrar",
  templateUrl: "./ong-cadastrar.component.html",
  styleUrls: ["./ong-cadastrar.component.css"],
})
export class OngCadastrarComponent implements OnInit {
  nome: string = "";
  missao: string = "";
  historico: string = "";
  informacoesContato: string = "";

  constructor(
    private client: HttpClient,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {}

  cadastrar(): void {
    let ong: ONG = {
      ongId: 0, // Coloque o valor adequado para ongId
      nome: this.nome,
      missao: this.missao,
      historico: this.historico,
      informacoesContato: this.informacoesContato,
      criadoEm: new Date(), // Coloque o valor adequado para criadoEm
    };

    this.client
      .post<ONG>("https://localhost:7195/api/ong/cadastrar", ong)
      .subscribe({
        next: (ong) => {
          this.snackBar.open("ONG cadastrada com sucesso!", "E-commerce", {
            duration: 1500,
            horizontalPosition: "right",
            verticalPosition: "top",
          });
          this.router.navigate(["pages/ong/listar"]);
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }
}

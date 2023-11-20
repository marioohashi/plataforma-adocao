import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { Evento } from "src/app/models/evento.model";
import { Animal } from "src/app/models/animal.model";
import { ONG } from "src/app/models/ong.model";


@Component({
  selector: "app-ong-atualizar",
  templateUrl: "./ong-atualizar.component.html",
  styleUrls: ["./ong-atualizar.component.css"],
})
export class OngAtualizarComponent implements OnInit {
  ongId: number = 0;
  ong: ONG = {} as ONG;
  nome?: string = "";
  missao?: string;
  historico?: string;
  informacoesContato?: string;
  criadoEm?: Date;
  
  constructor(
    private client: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.ongId = +params['id'];
      this.carregarDadosOng();
    });
  }

  carregarDadosOng(): void {
    this.client
      .get<ONG>(`https://localhost:7195/api/ong/buscarid/${this.ongId}`)
      .subscribe({
        next: (ong) => {
          this.ong = ong;
          this.nome = ong.nome || '';  // Utilizando operador lógico OU para evitar valores nulos ou indefinidos
          this.missao = ong.missao || '';
          this.historico = ong.historico || '';
          this.informacoesContato = ong.informacoesContato || '';
          this.criadoEm = ong.criadoEm || '';
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  atualizar(): void {
    let ongAtualizada: ONG = {
      ongId: this.ongId,
      nome: this.nome,
      missao: this.missao,
      historico: this.historico,
      informacoesContato: this.informacoesContato,
      criadoEm: this.ong.criadoEm || new Date(), // Usando criadoEm da ong existente ou criando uma nova data
    };

    this.client
      .put<ONG>(
        `https://localhost:7195/api/ong/atualizar/${this.ongId}`,
        ongAtualizada
      )
      .subscribe({
        next: (ong) => {
          this.snackBar.open("Ong atualizada com sucesso!", "E-commerce", {
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

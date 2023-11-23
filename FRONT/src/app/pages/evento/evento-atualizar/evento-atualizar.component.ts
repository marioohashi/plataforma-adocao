import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { ONG } from "src/app/models/ong.model";
import { Evento } from "src/app/models/evento.model";

@Component({
  selector: "app-evento-atualizar",
  templateUrl: "./evento-atualizar.component.html",
  styleUrls: ["./evento-atualizar.component.css"],
})
export class EventoAtualizarComponent implements OnInit {
  eventoId: number = 0;
  evento: Evento = {} as Evento;
  nome: string = "";
  descricao?: string = "";
  dataEvento?: Date | null;
  criadoEm?: Date;
  ongId: number = 0;
  ongs: ONG[] = [];

  
  constructor(
    private client: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.eventoId = +params['id'];
      this.carregarDadosOng();
    });
  }

  carregarDadosOng(): void {
    this.client
      .get<Evento>(`https://localhost:7195/api/evento/buscarid/${this.eventoId}`)
      .subscribe({
        next: (evento) => {
          this.evento = evento;
          this.nome = evento.nome || '';  // Utilizando operador lógico OU para evitar valores nulos ou indefinidos
          this.descricao = evento.descricao || '';
          this.criadoEm = evento.criadoEm || '';
          this.dataEvento = evento.dataEvento;
          this.ongId = evento.ongId || 0;          
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  atualizar(): void {
    let eventoAtualizada: Evento = {
      eventoId: this.eventoId,
      nome: this.nome,
      descricao: this.descricao,
      dataEvento: this.dataEvento,
      ongId: this.ongId,
      criadoEm: this.evento.criadoEm || new Date(),
    };

    this.client
      .put<Evento>(
        `https://localhost:7195/api/evento/atualizar/${this.eventoId}`,
        eventoAtualizada
      )
      .subscribe({
        next: (evento) => {
          this.snackBar.open("Ong atualizada com sucesso!", "E-commerce", {
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

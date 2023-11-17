import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Evento } from "src/app/models/evento.model";

@Component({
  selector: "app-evento-listar",
  template: `
    <table>
      <thead>
        <tr>
          <th>ID</th>
          <th>Nome</th>
          <th>Descrição</th>
          <th>ONG</th>
          <th>Data do Evento</th>
          <th>Criado Em</th>
          <th>Deletar</th>
          <th>Alterar</th>
        </tr>
      </thead>
      <tbody>
        <tr *ngFor="let evento of eventos">
          <td>{{ evento.eventoId }}</td>
          <td>{{ evento.nome }}</td>
          <td>{{ evento.descricao }}</td>
          <td>{{ evento.ong?.nome }}</td>
          <td>{{ evento.dataEvento | date: 'dd/MM/yyyy' }}</td>
          <td>{{ evento.criadoEm | date: 'dd/MM/yyyy HH:mm:ss' }}</td>
          <td>
            <button (click)="deletar(evento.eventoId)">Deletar</button>
          </td>
          <td>
            <!-- Adicione aqui o código para a ação de alterar -->
          </td>
        </tr>
      </tbody>
    </table>
  `,
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

  constructor(private client: HttpClient) {
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

  deletar(eventoId: number) {
    this.client
      .delete<Evento[]>(
        `https://localhost:7195/api/evento/deletar/${eventoId}`
      )
      .subscribe({
        next: (eventos) => {
          this.eventos = eventos;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }
}
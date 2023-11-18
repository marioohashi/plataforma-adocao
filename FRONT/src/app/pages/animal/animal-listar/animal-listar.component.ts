// animal-listar.component.ts
import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Animal } from "src/app/models/animal.model";

@Component({
  selector: "app-animal-listar",
  templateUrl: "./animal-listar.component.html",
  styleUrls: ["./animal-listar.component.css"],
})
export class AnimalListarComponent implements OnInit {
  animais: Animal[] = [];

  constructor(private client: HttpClient) {}

  ngOnInit(): void {
    this.client
      .get<Animal[]>("https://localhost:7195/api/animal/listar")
      .subscribe({
        next: (animais) => {
          console.table(animais);
          this.animais = animais;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  deletar(animalId: number) {
    this.client
      .delete<Animal[]>(`https://localhost:7195/api/animal/deletar/${animalId}`)
      .subscribe({
        next: (animais) => {
          this.animais = animais;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }
  atualizar(pessoaId: number) {
    console.log("atualizar");
  }
}

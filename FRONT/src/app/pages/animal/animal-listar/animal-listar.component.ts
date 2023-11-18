// animal-listar.component.ts
import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Animal } from "src/app/models/animal.model";
import { Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";

@Component({
  selector: "app-animal-listar",
  templateUrl: "./animal-listar.component.html",
  styleUrls: ["./animal-listar.component.css"],
})
export class AnimalListarComponent implements OnInit {
  animais: Animal[] = [];

  constructor(
    private client: HttpClient,
    private snackBar: MatSnackBar,
    private router: Router
  ) {}

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

  deletar(animalId: number): void {
    if (confirm("Tem certeza que deseja deletar esse animal?")) {
      this.client
        .delete(`https://localhost:7195/api/animal/delete/${animalId}`)
        .subscribe({
          next: () => {
            this.animais = this.animais.filter(
              (animal) => animal.animalId !== animalId
            );
            this.snackBar.open("Animal deletado com sucesso!", "Deletado(a)", {
              duration: 1500,
              horizontalPosition: "right",
              verticalPosition: "top",
            });
          },
          error: (erro) => {
            console.log(erro);
            this.snackBar.open(
              "Erro ao deletar esse animal.",
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

  atualizar(animalId: number) {
    console.log("atualizar");
  }
}

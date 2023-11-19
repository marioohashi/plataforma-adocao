// animal-cadastrar.component.ts
import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from "@angular/router";
import { Animal } from "src/app/models/animal.model";
import { ONG } from "src/app/models/ong.model";

@Component({
  selector: "app-animal-cadastrar",
  templateUrl: "./animal-cadastrar.component.html",
  styleUrls: ["./animal-cadastrar.component.css"],
})
export class AnimalCadastrarComponent {
  nome: string = "";
  idade: string = "";
  especie: string = "";
  raca: string = "";
  porte: string = "";
  comportamento: string = "";
  descricao: string = "";
  foto: string = "";
  video: string = "";
  ongId: number = 0;
  ong: ONG | undefined;
  ongs: ONG[] = []; // Você pode inicializar como undefined ou preenchê-lo conforme necessário

  constructor(
    private client: HttpClient,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.client.get<ONG[]>("https://localhost:7195/api/ong/listar").subscribe({
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
    let animal: Animal = {
      animalId: 0, // Coloque o valor adequado para animalId
      nome: this.nome,
      idade: this.idade,
      especie: this.especie,
      raca: this.raca,
      porte: this.porte,
      comportamento: this.comportamento,
      descricao: this.descricao,
      foto: this.foto,
      video: this.video,
      ongId: this.ongId,
      ong: this.ong,
    };

    this.client
      .post<Animal>("https://localhost:7195/api/animal/cadastrar", animal)
      .subscribe({
        next: (animal) => {
          this.snackBar.open("Animal cadastrado com sucesso!", "E-commerce", {
            duration: 1500,
            horizontalPosition: "right",
            verticalPosition: "top",
          });
          this.router.navigate(["pages/animal/listar"]);
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }
}

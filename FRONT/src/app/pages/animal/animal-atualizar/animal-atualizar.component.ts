// animal-atualizar.component.ts
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Animal } from "src/app/models/animal.model";
import { ONG } from "src/app/models/ong.model";

@Component({
  selector: "app-animal-atualizar",
  templateUrl: "./animal-atualizar.component.html",
  styleUrls: ["./animal-atualizar.component.css"],
})
export class AnimalAtualizarComponent implements OnInit {
  animalId: number = 0;
  animal: Animal = {} as Animal;
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
  ongs: ONG[] = [];

  constructor(
    private client: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.animalId = +params['id'];
      this.loadAnimalDetails();
    });

    this.client
      .get<ONG[]>("https://localhost:7195/api/ong/listar")
      .subscribe({
        next: (ongs) => {
          this.ongs = ongs;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  loadAnimalDetails(): void {
    this.client
      .get<Animal>(`https://localhost:7195/api/animal/buscarid/${this.animalId}`)
      .subscribe({
        next: (animal) => {
          console.table(animal);
          this.animal = animal;
          this.nome = animal.nome || '';
          this.idade = animal.idade || '';
          this.especie = animal.especie || '';
          this.raca = animal.raca || '';
          this.porte = animal.porte || '';
          this.comportamento = animal.comportamento || '';
          this.descricao = animal.descricao || '';
          this.foto = animal.foto || '';
          this.video = animal.video || '';
          this.ongId = animal.ongId || 0;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  atualizar(): void {
    let animalAtualizado: Animal = {
      animalId: this.animalId,
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
      ong: this.animal.ong || {} as ONG,
    };

    this.client
      .put<Animal>(
        `https://localhost:7195/api/animal/atualizar/${this.animalId}`,
        animalAtualizado
      )
      .subscribe({
        next: (animal) => {
          this.snackBar.open("Animal atualizado com sucesso!", "E-commerce", {
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

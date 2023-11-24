import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from "@angular/router";
import { Animal } from "src/app/models/animal.model";
import { Pessoa } from "src/app/models/pessoa.model";

@Component({
  selector: "app-pessoa-cadastrar",
  templateUrl: "./pessoa-cadastrar.component.html",
  styleUrls: ["./pessoa-cadastrar.component.css"],
})
export class PessoaCadastrarComponent {
  nome: string = "";
  endereco: string = "";
  numeroTelefone: string = "";
  email: string = "";
  animalId: number = 0;
  animais: Animal[] = [];

  constructor(
    private client: HttpClient,
    private router: Router,
    private snackBar: MatSnackBar
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

  cadastrar(): void {
    let pessoa: Pessoa = {
      pessoaId: 0,
      nome: this.nome,
      endereco: this.endereco,
      numeroTelefone: this.numeroTelefone,
      email: this.email,
      animalId: this.animalId,
      criadoEm: new Date(),
    };

    this.client
      .post("https://localhost:7195/api/pessoa/cadastrar", pessoa)
      .subscribe({
        next: (pessoa) => {
          this.snackBar.open("Pessoa cadastrada com sucesso!", "E-commerce", {
            duration: 1500,
            horizontalPosition: "right",
            verticalPosition: "top",
          });
          this.router.navigate(["pages/pessoa/listar"]);
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }
}

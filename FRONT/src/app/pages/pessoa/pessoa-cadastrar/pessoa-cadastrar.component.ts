// pessoa-cadastrar.component.ts
import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Pessoa } from "src/app/models/pessoa.model";

@Component({
  selector: "app-pessoa-cadastrar",
  templateUrl: "./pessoa-cadastrar.component.html",
  styleUrls: ["./pessoa-cadastrar.component.css"],
})
export class PessoaCadastrarComponent {
  novaPessoa: Pessoa = {
    pessoaId: 0,
    nome: "",
    endereco: "",
    numeroTelefone: "",
    email: "",
    animalId: null,
    criadoEm: new Date(),
  };

  constructor(private client: HttpClient, private snackBar: MatSnackBar) {}

  cadastrarPessoa() {
    this.client
      .post<Pessoa>("https://localhost:7195/api/pessoa/cadastrar", this.novaPessoa)
      .subscribe({
        next: (pessoa) => {
          console.log("Pessoa cadastrada com sucesso:", pessoa);
          this.snackBar.open("Pessoa cadastrada com sucesso!", "E-commerce", {
            duration: 1500,
            horizontalPosition: "right",
            verticalPosition: "top",
          });
        },
        error: (erro) => {
          console.log("Erro ao cadastrar pessoa:", erro);
          this.snackBar.open("Erro ao cadastrar pessoa", "E-commerce", {
            duration: 1500,
            horizontalPosition: "right",
            verticalPosition: "top",
          });
        },
      });
  }
}

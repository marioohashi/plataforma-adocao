// pessoa-atualizar.component.ts

import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { Animal } from "src/app/models/animal.model";
import { Pessoa } from "src/app/models/pessoa.model";

@Component({
  selector: "app-pessoa-atualizar",
  templateUrl: "./pessoa-atualizar.component.html",
  styleUrls: ["./pessoa-atualizar.component.css"],
})
export class PessoaAtualizarComponent implements OnInit {
  pessoaId: number = 0;
  pessoa: Pessoa = {} as Pessoa;
  nome: string = "";
  endereco: string = "";
  numeroTelefone: string = "";
  email: string = "";
  foto: string = "";
  video: string = "";
  animalId: number = 0;
  animais: Animal[] = [];

  constructor(
    private client: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.pessoaId = +params['id'];
      this.carregarDadosPessoa();
    });

    this.client
      .get<Animal[]>("https://localhost:7195/api/animal/listar")
      .subscribe({
        next: (animais) => {
          this.animais = animais;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  carregarDadosPessoa(): void {
    this.client
      .get<Pessoa>(`https://localhost:7195/api/pessoa/buscarpessoa/${this.pessoaId}`)
      .subscribe({
        next: (pessoa) => {
          console.table(pessoa);
          this.pessoa = pessoa;
          this.nome = pessoa.nome || '';  // Utilizando operador lógico OU para evitar valores nulos ou indefinidos
          this.endereco = pessoa.endereco || '';
          this.numeroTelefone = pessoa.numeroTelefone || '';
          this.email = pessoa.email || '';
          this.animalId = pessoa.animalId || 0;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  atualizar(): void {
    let pessoaAtualizada: Pessoa = {
      pessoaId: this.pessoaId,
      nome: this.nome,
      endereco: this.endereco,
      numeroTelefone: this.numeroTelefone,
      email: this.email,
      animalId: this.animalId,
      criadoEm: this.pessoa.criadoEm || new Date(), // Usando criadoEm da pessoa existente ou criando uma nova data
    };

    this.client
      .put<Pessoa>(
        `https://localhost:7195/api/pessoa/atualizar/${this.pessoaId}`,
        pessoaAtualizada
      )
      .subscribe({
        next: (pessoa) => {
          this.snackBar.open("Pessoa atualizada com sucesso!", "E-commerce", {
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

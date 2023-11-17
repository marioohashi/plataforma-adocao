import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Animal } from 'src/app/models/animal.model';

@Component({
  selector: 'app-animal-listar',
  templateUrl: './animal-listar.component.html',
  styleUrls: ['./animal-listar.component.css']
})
export class AnimalListarComponent {

  animais: Animal[] = [];

  constructor(private client: HttpClient){ 
  }

  ngOnInit() : void{
    console.log("O componente foi carregado!");

    this.client.get<Animal[]>("https://localhost:7195/api/animal/listar")
      .subscribe({
        //Requisição com sucesso
        next: (animais) => {
          this.animais = animais;
          console.table(animais);
        }, 
        //Requisição com erro
        error: (erro) => {
          console.log(erro);
        }
      })
  }

}

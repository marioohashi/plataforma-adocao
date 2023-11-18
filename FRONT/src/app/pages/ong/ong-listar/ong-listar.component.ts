// ong-listar.component.ts
import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ONG } from "src/app/models/ong.model";

@Component({
  selector: "app-ong-listar",
  templateUrl: "./ong-listar.component.html",
  styleUrls: ["./ong-listar.component.css"],
})
export class OngListarComponent implements OnInit {
  ongs: ONG[] = [];

  constructor(private client: HttpClient) {}

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

  deletar(ongId: number) {
    console.log("ONG deletada");

    this.client
      .delete<ONG[]>(`https://localhost:7195/api/ong/deletar/${ongId}`)
      .subscribe({
        next: (ongs) => {
          this.ongs = ongs;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  atualizar(ongId: number) {
    // Implemente a navegação para a página de atualização ou lógica necessária
    // Exemplo de navegação para uma rota chamada '/ong/atualizar/:ongId'
    // Certifique-se de configurar suas rotas adequadamente
    // this.router.navigate(['/ong/atualizar', ongId]);
    console.log("ONG Atualizada");
  }
}

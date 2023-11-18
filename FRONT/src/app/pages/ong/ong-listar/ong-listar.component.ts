// ong-listar.component.ts
import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ONG } from "src/app/models/ong.model";
import { Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";

@Component({
  selector: "app-ong-listar",
  templateUrl: "./ong-listar.component.html",
  styleUrls: ["./ong-listar.component.css"],
})
export class OngListarComponent implements OnInit {
  ongs: ONG[] = [];

  constructor(
    private client: HttpClient,
    private snackBar: MatSnackBar,
    private router: Router
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

  deletar(ongId: number): void {
    if (confirm("Tem certeza que deseja deletar essa ONG?")) {
      this.client
        .delete(`https://localhost:7195/api/ong/delete/${ongId}`)
        .subscribe({
          next: () => {
            this.ongs = this.ongs.filter((ong) => ong.ongId !== ongId);
            this.snackBar.open("ONG deletada com sucesso!", "Deletado(a)", {
              duration: 1500,
              horizontalPosition: "right",
              verticalPosition: "top",
            });
          },
          error: (erro) => {
            console.log(erro);
            this.snackBar.open("Erro ao deletar essa ONG.", "Tente novamente", {
              duration: 1500,
              horizontalPosition: "right",
              verticalPosition: "top",
            });
          },
        });
    }
  }

  atualizar(ongId: number) {
    // Implemente a navegação para a página de atualização ou lógica necessária
    // Exemplo de navegação para uma rota chamada '/ong/atualizar/:ongId'
    // Certifique-se de configurar suas rotas adequadamente
    // this.router.navigate(['/ong/atualizar', ongId]);
    console.log("ONG Atualizada");
  }
}

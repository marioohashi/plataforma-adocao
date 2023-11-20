import { Component } from '@angular/core';

interface UserData {
  nome: string;
  email: string;
  password: string;
  endereco: string;
  numeroTelefone: string;
}

interface OngData {
  nome: string;
  email: string;
  password: string;
  numeroTelefone: string;
  missao: string;
  historico: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  registrationType: 'pessoa' | 'ong' = 'pessoa';
  user: UserData = {
    nome: '',
    email: '',
    password: '',
    endereco: '',
    numeroTelefone: ''
  };
  ong: OngData = {
    nome: '',
    email: '',
    password: '',
    numeroTelefone: '',
    missao: '',
    historico: ''
  };

  toggleMode(type: 'pessoa' | 'ong') {
    this.registrationType = type;
  }

  onSubmit() {
    if (this.registrationType === 'pessoa') {
      // Adicione aqui a lógica para registrar uma pessoa
      console.log('Registrando pessoa:', this.user);
    } else {
      // Adicione aqui a lógica para registrar uma ONG
      console.log('Registrando ONG:', this.ong);
    }
  }
}

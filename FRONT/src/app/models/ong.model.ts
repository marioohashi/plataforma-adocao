export interface ONG {
    ongId: number;
    nome?: string;
    email?: string;
    password?:string;  
    informacoesContato?: string;
    missao?: string;
    historico?: string;
    criadoEm: Date;
  }
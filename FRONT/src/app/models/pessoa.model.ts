export interface Pessoa {
  pessoaId: number;
  nome?: string;
  email?: string;
  password?:string;
  endereco?: string;
  numeroTelefone?: string;
  animalId?: number | null;
  criadoEm: Date;
}

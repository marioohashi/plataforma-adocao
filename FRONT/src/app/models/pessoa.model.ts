export interface Pessoa {
  pessoaId: number;
  nome?: string;
  endereco?: string;
  numeroTelefone?: string;
  email?: string;
  animalId?: number | null;
  criadoEm: Date;
}

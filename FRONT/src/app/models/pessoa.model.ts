import { Animal } from './animal.model';

export interface Pessoa {
  pessoaId: number;
  nome?: string;
  endereco?: string;
  numeroTelefone?: string;
  email?: string;
  animal?: Animal;
  animalId?: number | null;
  criadoEm: Date;
}

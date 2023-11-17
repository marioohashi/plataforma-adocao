import { ONG } from './ong.model';

export interface Animal {
    animalId: number;
    nome: string;
    idade?: string;
    especie?: string;
    raca?: string;
    porte?: string;
    comportamento?: string;
    descricao?: string;
    foto?: string;
    video?: string;
    ong?: ONG;
    ongId: number;
  }
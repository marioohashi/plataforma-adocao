import { ONG } from './ong.model';
export interface Evento {
    eventoId: number;
    nome?: string;
    descricao?: string;
    ong?: ONG;
    ongId: number;
    dataEvento?: Date | null;
    criadoEm: Date;
}
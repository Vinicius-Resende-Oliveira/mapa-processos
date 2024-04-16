export class Processo {
    id!: string;
    nome!: string;
    descricao!: string;
    idProcessoPai!: string;
    processoPai!: Processo;
    subsProcessosNavigation!: Processo[];
}
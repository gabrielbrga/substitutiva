﻿namespace braga.models;

public class Aluno

{
        public string AlunoId { get; set; } = Guid.NewGuid().ToString();  
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;

    }

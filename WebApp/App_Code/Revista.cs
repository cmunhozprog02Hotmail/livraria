using System;

// DTO - Data Tranfer Object
// POCCO - Poor Old CLR Object
// DDD - Presistence Ignorance


namespace Editora.Domain
{
    public class Revista
    {
        public int NUM_EDICAO {get; set;}
        public string CAPA {get; set;}
        public double NIVEL {get; set;}
    }
}
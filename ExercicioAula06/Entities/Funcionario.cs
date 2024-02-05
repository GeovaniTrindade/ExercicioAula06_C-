using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExercicioAula06.Entities
{
    public class Funcionario
    {
        private Guid _id;
        private string? _nome;
        private string? _cpf;
        private string? _matricula;


        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public string? Nome
        {
            get => _nome;
            set
            {
                
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O nome é obrigatório.");

                
                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{10,150}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Informe um nome válido de 8 a 100 caracteres.");

                _nome = value;
            }
        }

        public string? Cpf
        {
            get => _cpf;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O cpf é obrigatório.");

               
                var regex = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Informe um cpf no formato '999.999.999-99'.");

                _cpf = value;
            }
        }

        public string? Matricula
        {
            get => _matricula;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A matrícula é obrigatória.");


                var regex = new Regex(@"^\d{3}\.\d{3}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Informe uma matrícula no formato '999.999'.");

                _matricula = value;
            }
        }


    }
}

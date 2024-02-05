using Dapper;
using ExercicioAula06.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioAula06.Repositories
{
    public class FuncionarioRepository
    {
        private string _connectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BD_Exercicio_Aula_06;Integrated Security=True;";

        public void Add(Funcionario funcionario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO FUNCIONARIO(ID, NOME, CPF, MATRICULA)
                    VALUES(@ID, @NOME, @CPF, @MATRICULA)
                ";


                connection.Execute(query, new
                {
                    @ID = funcionario.Id,
                    @NOME = funcionario.Nome,
                    @CPF = funcionario.Cpf,
                    @MATRICULA = funcionario.Matricula
                });
            }

        }

        public void Update(Funcionario funcionario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"UPDATE FUNCIONARIO SET NOME=@NOME, CPF=@CPF, MATRICULA=@MATRICULA
                    WHERE ID=@ID
                ";

                connection.Execute(query, new
                {
                    @ID = funcionario.Id,
                    @NOME = funcionario.Nome,
                    @CPF = funcionario.Cpf,
                    @MATRICULA = funcionario.Matricula
                   
                });
            }

        }

        public void Delete(Funcionario funcionario) 
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"DELETE FROM FUNCIONARIO WHERE ID=@ID";

                connection.Execute(query, new
                {
                    @ID = funcionario.Id
                });
            }

        }

        public List<Funcionario> GetAll() 
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"SELECT * FROM FUNCIONARIO ORDER BY NOME";

                return connection.Query<Funcionario>(query).ToList();
            }

        }

        public Funcionario? GetById(Guid id) 
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"SELECT * FROM FUNCIONARIO WHERE ID=@ID";

                return connection.Query<Funcionario>(query, new
                {
                    @ID = id
                }).FirstOrDefault();
            }
        }
    }



}

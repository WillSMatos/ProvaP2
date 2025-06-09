using System;

namespace LojaVirtual.Models
{
    public class Cliente
    {
        public int Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public string CPF { get; }

        public Cliente(int id, string nome, string email, string cpf)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do cliente não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email do cliente não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("CPF do cliente não pode ser vazio.");

            Id = id;
            Nome = nome;
            Email = email;
            CPF = cpf;
        }
    }
}

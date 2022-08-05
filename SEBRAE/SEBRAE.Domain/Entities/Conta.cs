using SEBRAE.Domain.Validation;

namespace SEBRAE.Domain.Entities
{
    public sealed class Conta : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public Conta(string nome, string descricao)
        {
            ValidateDomain(nome, descricao);
        }

        public Conta(int id, string nome, string descricao)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(nome, descricao);
        }

        private void ValidateDomain(string nome, string descricao)
        {
            // validações para Nome
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome obrigatório.");

            DomainExceptionValidation.When(nome.Length < 3,
                "Nome deve conter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(nome.Length > 100,
                "Nome deve conter no máximo 100 caracteres.");
            
            // validações para Descrição
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descrição obrigatória.");

            DomainExceptionValidation.When(descricao.Length < 3,
                "Descrição deve conter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(descricao.Length > 200,
                "Descrição deve conter no máximo 200 caracteres.");

            Nome = nome;
            Descricao = descricao;
        }
    }
}

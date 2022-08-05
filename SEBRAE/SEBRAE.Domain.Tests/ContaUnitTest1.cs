using FluentAssertions;
using SEBRAE.Domain.Entities;

namespace SEBRAE.Domain.Tests
{
    public class ContaUnitTest1
    {
        [Fact]
        public void CreateConta_ComParametrosValidos_ResultObjectValidState()
        {
            Action action = () => new Conta(1, "Conta Um", "Conta Descrição um");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateConta_IdValorNegativo_DomainExceptionInvalidId()
        {
            Action action = () => new Conta(-1, "Conta Um", "Conta Descrição um");

            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Id inválido.");
        }

        [Fact]
        public void CreateConta_NomeMuitoCurto_DomainExceptionShortName()
        {
            Action action = () => new Conta(1, "Um", "Conta Descrição um");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Nome deve conter no mínimo 3 caracteres.");
        }

        [Fact]
        public void CreateConta_NomeMuitoLongo_DomainExceptionLongImageName()
        {
            Action action = () => new Conta(1, "Conta Ummmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm", "Conta Descrição um");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Nome deve conter no máximo 100 caracteres.");
        }

        [Fact]
        public void CreateConta_DescricaoMuitoCurta_DomainExceptionShortName()
        {
            Action action = () => new Conta(1, "Conta Um", "Um");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Descrição deve conter no mínimo 3 caracteres.");
        }

        [Fact]
        public void CreateConta_DescricaoMuitoLonga_DomainExceptionLongImageName()
        {
            Action action = () => new Conta(1, "Conta Um", "Conta Descrição ummmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Descrição deve conter no máximo 200 caracteres.");
        }
    }
}
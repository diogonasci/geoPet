using GeoPet.Domain.Validation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GeoPet.Domain.Entities;

    public sealed class PetOwner : Entity
    {
        public PetOwner(string name, string email, string password)
        {
            ValidateDomain(name, email, password);
        }

        // Construtor para o banco de dados
        // Por que não tem no Pet?
        public PetOwner(int id, string name, string email, string password)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(name, email, password);
        }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public string? ProfilePicture { get; private set; }
        public string? PhoneNumber { get; private set; }

        public string CEP { get; private set; } = null!; // Entender melhor quando utilizar private set

        
        private void ValidateDomain(string name, string email, string password)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Name must have at least 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
                "Invalid email. Email is required");

            DomainExceptionValidation.When(email.Length < 5,
                "Email must have at least 5 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(password),
                "Invalid password. Password is required");

            DomainExceptionValidation.When(password.Length < 6,
                "Password must have at least 6 characters");

            Name = name;
            Email = email;
            Password = password;
        }
        public Collection<Pet> Pets { get; set; } = null!; // Entender o que significa null! / Aqui eu deveria utilizar uma collection?
    }
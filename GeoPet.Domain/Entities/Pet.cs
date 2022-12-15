using GeoPet.Domain.Validation;
using System;

namespace GeoPet.Domain.Entities;
    public class Pet : Entity
    {
        public Pet(string name, string breed, string gender, double weight, int age)
        {
            ValidateDomain(name, breed, gender, weight, age);
        }
        public string Name { get; private set; }
        public string Breed { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public int Age { get; private set; }
        public string[] Position { get; private set; } = null!; // latitude, longitude and address

        private void ValidateDomain(string name, string breed, string gender, double weight, int age)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Name must have at least 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(breed),
                "Invalid breed. Breed is required");

            DomainExceptionValidation.When(breed.Length < 30,
                "Breed must have at least 30 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(gender),
                "Invalid breed. Breed is required");

            DomainExceptionValidation.When(weight <= 0 || weight >= 300, "Invalid weight");

            DomainExceptionValidation.When(age <= 0 || age >= 20, "Invalid age");


            Name = name;
            Breed = breed;
            Gender = gender;
            Weight = weight;
            Age = age;

        }
    }
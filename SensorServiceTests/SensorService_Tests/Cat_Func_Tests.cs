using FluentAssertions;
using Moq;
using NUnit.Framework;
using Sensor.Config;
using Sensor.Model;
using Sensor.Processor;
using Sensor.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SensorService_Tests
{
    public class CatFunc_Tests
    {
        private List<PetOwner> _petsAndOwners;
        private IApiService _apiService;

        [SetUp]
        public void Setup()
        {
            BuildPetData();
        }

      

        [Test]
        public void GivenAResponse_DataMustBefilteredForOwnersThatHavePetTypeCats()
        {
            var result = _petsAndOwners.FilterBy(PetType.Cat);
            result.Count().Should().Be(1);
        }


        [Test]
        public void GivenAResponse_DataMustBefilteredForOwnersThatHavePetTypeDogs()
        {
            var result = _petsAndOwners.FilterBy(PetType.Dog);
            result.Count().Should().Be(2);
        }


        [Test]
        public void GivenAResponse_DataMustBefilteredForOwnersThatHaveNoPets()
        {
            var result = _petsAndOwners.FilterBy(PetType.NoPets);
            result.Count().Should().Be(1);
        }

        private void BuildPetData()
        {
            _petsAndOwners = new List<PetOwner>();
            for (int i = 0; i < 3; i++)
            {
                Math.DivRem(i, 2, out int result);
                var genderType = result == 0 ? Gender.Male : Gender.Female;
                _petsAndOwners.Add(new PetOwner()
                {
                    Age = new Random().Next(5, 100),
                    Gender = genderType,
                    Name = Guid.NewGuid().ToString(),
                    Pets = new List<Pets>()
                });
            }

            var firstPetowner = _petsAndOwners.FirstOrDefault();
            firstPetowner.Pets = new List<Pets>()
            {
                AddPet("tom",PetType.Cat),
                AddPet("Hulk",PetType.Dog),
            };

            var lastPetowner = _petsAndOwners.LastOrDefault();
            lastPetowner.Pets = new List<Pets>()
            {
                AddPet("tom",PetType.Fish),
                AddPet("Hulk",PetType.Dog),
            };
        }

        private static Pets AddPet(string name, PetType petType)
        {
            return new Pets()
            {
                Name = name,
                Type = petType.ToString()
            };
        }
    }
}
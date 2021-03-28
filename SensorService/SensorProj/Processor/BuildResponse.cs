using Sensor.Model;
using System.Collections.Generic;
using System.Linq;

namespace Sensor.Processor
{
    public static class BuildResponse
    {

        public static List<PetOwner> FilterBy(this List<PetOwner> petOwner, PetType petType)
        {
            var petOwnersForGivenPetType = petType==PetType.NoPets?
                petOwner.Where(owner => owner.Pets==null || !owner.Pets.Any()).ToList():
                petOwner.Where(owner => owner.Pets != null && owner.Pets.Any(pet => pet.Type == petType.ToString())).ToList();
            return petOwnersForGivenPetType;
        }

    }
}

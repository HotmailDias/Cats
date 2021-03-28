using System.Collections.Generic;

namespace Sensor.Model
{
    public class PetOwner
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public List<Pets> Pets { get; set; }

    }
}

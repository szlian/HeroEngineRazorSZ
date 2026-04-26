using System.Collections.Generic;

namespace HeroEngine.Core.Models
{
    // Aquests DTO serveixen per serialitzar/deserialitzar herois a JSON.
    public class HeroDto
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";  // "CWarrior" o "CRogue"
        public int Level { get; set; }
        public int MaxHp { get; set; }
        public int? Armor { get; set; }
        public List<AbilityDto> Abilities { get; set; } = new();
    }

    public class AbilityDto
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string Rarity { get; set; } = "";
        public int Cost { get; set; }
    }
}
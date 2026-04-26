using HeroEngine.Core.Classes;
using HeroEngine.Core.Classes.Hability;
using HeroEngine.Core.Classes.Heroes;
using HeroEngine.Core.Classes.Interface;
using HeroEngine.Core.Models;
using System.Text.Json;

namespace HeroEngine.Core.Data
{
    /// <summary>
    /// Gestiona la persistència dels herois en un fitxer JSON.
    /// </summary>
    public class HeroRepository
    {
        private readonly string _filePath;

        public HeroRepository(string filePath) => _filePath = filePath;

        public List<AHeroes> LoadAll()
        {
            if (!File.Exists(_filePath))
                return new List<AHeroes>();

            string json = File.ReadAllText(_filePath);
            var dtos = JsonSerializer.Deserialize<List<HeroDto>>(json) ?? new();
            return dtos.Select(dto => ConvertToHero(dto)).ToList();
        }

        public void SaveAll(IEnumerable<AHeroes> heroes)
        {
            var dtos = heroes.Select(hero => ConvertToDto(hero)).ToList();
            string json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public void Add(AHeroes hero)
        {
            var heroes = LoadAll();
            heroes.Add(hero);
            SaveAll(heroes);
        }

        public bool Delete(string name)
        {
            var heroes = LoadAll();
            var hero = heroes.FirstOrDefault(h => h.Name == name);
            if (hero == null) return false;
            heroes.Remove(hero);
            SaveAll(heroes);
            return true;
        }

        private HeroDto ConvertToDto(AHeroes hero)
        {
            var dto = new HeroDto
            {
                Name = hero.Name,
                Type = hero.GetType().Name,
                Level = hero.Lvl,
                MaxHp = hero.Health
            };

            // Amb la propietat pública Abilities, accedim directament
            dto.Abilities = hero.Abilities.Select(a => new AbilityDto
            {
                Name = a.Name,
                Type = a.Type.ToString(),
                Rarity = a.Rarity.ToString(),
                Cost = a.Cost
            }).ToList();

            if (hero is CWarrior warrior)
                dto.Armor = warrior.Armor;

            return dto;
        }

        private AHeroes ConvertToHero(HeroDto dto)
        {
            AHeroes hero = dto.Type switch
            {
                "CWarrior" => new CWarrior(dto.Name, dto.MaxHp / dto.Level, dto.Level, dto.Armor ?? 0),
                "CRogue" => new CRogue(dto.Name, dto.MaxHp / dto.Level, dto.Level),
                _ => throw new Exception($"Tipus d'heroi desconegut: {dto.Type}")
            };

            // Afegim les habilitats
            foreach (var abDto in dto.Abilities)
            {
                IAbility? ability = abDto.Name switch
                {
                    "WarTaunt" => new WarTaunt(),
                    // aquí pots afegir nous tipus d'habilitat
                    _ => null
                };
                if (ability != null)
                    hero.AddAbility(ability);
            }

            return hero;
        }
    }
}
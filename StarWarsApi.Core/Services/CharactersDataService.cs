using StarWarsApi.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsApi.Core.Services
{
    public static class CharacterDataService
    {
        public static async Task<IEnumerable<Character>> GetCharacterDataAsync()
        {
            await Task.CompletedTask;
            return AllCharacters();
        }

        private static IEnumerable<Character> AllCharacters()
        {
            return new List<Character>()
            {
                Create( "https://swapi.co/api/people/27/", "Ackbar"),
                Create( "https://swapi.co/api/people/29/", "Arvel Crynyd"),
                Create( "https://swapi.co/api/people/11/", "Anakin Skywalker"),
                Create( "https://swapi.co/api/people/7/",  "Beru Whitesun lars"),
                Create( "https://swapi.co/api/people/9/",  "Biggs Darklighter"),
                Create( "https://swapi.co/api/people/22/", "Boba Fett"),
                Create( "https://swapi.co/api/people/24/", "Bossk"),
                Create( "https://swapi.co/api/people/2/",  "C-3PO"),
                Create( "https://swapi.co/api/people/13/", "Chewbacca"),
                Create( "https://swapi.co/api/people/4/",  "Darth Vader"),
                Create( "https://swapi.co/api/people/34/", "Finis Valorum"),
                Create( "https://swapi.co/api/people/15/", "Greedo"),
                Create( "https://swapi.co/api/people/14/", "Han Solo"),
                Create( "https://swapi.co/api/people/23/", "IG-88"),
                Create( "https://swapi.co/api/people/16/", "Jabba Desilijic Tiure"),
                Create( "https://swapi.co/api/people/36/", "Jar Jar Binks"),
                Create( "https://swapi.co/api/people/19/", "Jek Tono Porkins"),
                Create( "https://swapi.co/api/people/25/", "Lando Calrissian"),
                Create( "https://swapi.co/api/people/5/",  "Leia Organa"),
                Create( "https://swapi.co/api/people/26/", "Lobot"),
                Create( "https://swapi.co/api/people/1/",  "Luke Skywalker"),
                Create( "https://swapi.co/api/people/28/", "Mon Mothma"),
                Create( "https://swapi.co/api/people/31/", "Nien Nunb"),
                Create( "https://swapi.co/api/people/33/", "Nute Gunray"),
                Create( "https://swapi.co/api/people/6/",  "Owen Lars"),
                Create( "https://swapi.co/api/people/10/", "Obi-Wan Kenobi"),
                Create( "https://swapi.co/api/people/21/", "Palpatine"),
                Create( "https://swapi.co/api/people/42/", "Quarsh Panaka"),
                Create( "https://swapi.co/api/people/32/", "Qui-Gon Jinn"),
                Create( "https://swapi.co/api/people/3/",  "R2-D2"),
                Create( "https://swapi.co/api/people/8/",  "R5-D4"),
                Create( "https://swapi.co/api/people/39/", "Ric Olie"),
                Create( "https://swapi.co/api/people/37/", "Roos Tarpals"),
                Create( "https://swapi.co/api/people/38/", "Rugor Nass"),
                Create( "https://swapi.co/api/people/41/", "Sebulba"),
                Create( "https://swapi.co/api/people/40/", "Watto"),
                Create( "https://swapi.co/api/people/18/", "Wedge Antilles"),
                Create( "https://swapi.co/api/people/30/", "Wicket Systri Warrick"),
                Create( "https://swapi.co/api/people/12/", "Wilhuff Tarkin"),
                Create( "https://swapi.co/api/people/20/", "Yoda")
            };
        }

        private static Character Create(string url, string name) => new Character { URL = url, Name = name };
    }    
}
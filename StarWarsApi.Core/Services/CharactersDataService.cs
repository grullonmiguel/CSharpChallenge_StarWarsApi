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
                Create("Ackbar"                 , "https://swapi.co/api/people/27/"),
                Create("Adi Gallia"             , "https://swapi.co/api/people/55/"),
                Create("Arvel Crynyd"           , "https://swapi.co/api/people/29/"),
                Create("Anakin Skywalker"       , "https://swapi.co/api/people/11/"),
                Create("Ayla Secura"            , "https://swapi.co/api/people/46/"),
                Create("Bail Prestor Organa"    , "https://swapi.co/api/people/68/"),
                Create("Barriss Offee"          , "https://swapi.co/api/people/65/"),
                Create("BB8"                    , "https://swapi.co/api/people/87/"),
                Create("Ben Quadinaros"         , "https://swapi.co/api/people/50/"),
                Create("Beru Whitesun lars"     , "https://swapi.co/api/people/7/"),
                Create("Bib Fortuna"            , "https://swapi.co/api/people/45/"),
                Create("Biggs Darklighter"      , "https://swapi.co/api/people/9/"),
                Create("Boba Fett"              , "https://swapi.co/api/people/22/"),
                Create("Bossk"                  , "https://swapi.co/api/people/24/"),
                Create("Captain Phasma"         , "https://swapi.co/api/people/88/"),
                Create("C-3PO"                  , "https://swapi.co/api/people/2/"),
                Create("Cliegg Lars"            , "https://swapi.co/api/people/62/"),
                Create("Cordé"                  , "https://swapi.co/api/people/61/"),
                Create("Chewbacca"              , "https://swapi.co/api/people/13/"),
                Create("Darth Maul"             , "https://swapi.co/api/people/44/"),
                Create("Darth Vader"            , "https://swapi.co/api/people/4/"),
                Create("Dexter Jettster"        , "https://swapi.co/api/people/71/"),
                Create("Dormé"                  , "https://swapi.co/api/people/66/"),
                Create("Dooku"                  , "https://swapi.co/api/people/67/"),
                Create("Dud Bolt"               , "https://swapi.co/api/people/48/"),
                Create("Eeth Koth"              , "https://swapi.co/api/people/54/"),
                Create("Finis Valorum"          , "https://swapi.co/api/people/34/"),
                Create("Finn"                   , "https://swapi.co/api/people/84/"),
                Create("Gasgano"                , "https://swapi.co/api/people/49/"),
                Create("Greedo"                 , "https://swapi.co/api/people/15/"),
                Create("Gregar Typho"           , "https://swapi.co/api/people/60/"),
                Create("Grievous"               , "https://swapi.co/api/people/79/"),
                Create("Han Solo"               , "https://swapi.co/api/people/14/"),
                Create("IG-88"                  , "https://swapi.co/api/people/23/"),
                Create("Jabba Desilijic Tiure"  , "https://swapi.co/api/people/16/"),
                Create("Jango Fett"             , "https://swapi.co/api/people/69/"),
                Create("Jar Jar Binks"          , "https://swapi.co/api/people/36/"),
                Create("Jek Tono Porkins"       , "https://swapi.co/api/people/19/"),
                Create("Jocasta Nu"             , "https://swapi.co/api/people/74/"),
                Create("Ki-Adi-Mundi"           , "https://swapi.co/api/people/52/"),
                Create("Kit Fisto"              , "https://swapi.co/api/people/53/"),
                Create("Lama Su"                , "https://swapi.co/api/people/72/"),
                Create("Lando Calrissian"       , "https://swapi.co/api/people/25/"),
                Create("Leia Organa"            , "https://swapi.co/api/people/5/"),
                Create("Lobot"                  , "https://swapi.co/api/people/26/"),
                Create("Luke Skywalker"         , "https://swapi.co/api/people/1/"),
                Create("Luminara Unduli"        , "https://swapi.co/api/people/64/"),
                Create("Mace Windu"             , "https://swapi.co/api/people/51/"),
                Create("Mas Amedda"             , "https://swapi.co/api/people/59/"),
                Create("Mon Mothma"             , "https://swapi.co/api/people/28/"),
                Create("Nien Nunb"              , "https://swapi.co/api/people/31/"),
                Create("Nute Gunray"            , "https://swapi.co/api/people/33/"),
                Create("Owen Lars"              , "https://swapi.co/api/people/6/"),
                Create("Obi-Wan Kenobi"         , "https://swapi.co/api/people/10/"),
                Create("Padmé Amidala"          , "https://swapi.co/api/people/35/"),
                Create("Palpatine"              , "https://swapi.co/api/people/21/"),
                Create("Plo Koon"               , "https://swapi.co/api/people/58/"),
                Create("Poe Dameron"            , "https://swapi.co/api/people/86/"),
                Create("Poggle the Lesser"      , "https://swapi.co/api/people/63/"),
                Create("Quarsh Panaka"          , "https://swapi.co/api/people/42/"),
                Create("Qui-Gon Jinn"           , "https://swapi.co/api/people/32/"),
                Create("R2-D2"                  , "https://swapi.co/api/people/3/"),
                Create("R4-P17"                 , "https://swapi.co/api/people/75/"),
                Create("R5-D4"                  , "https://swapi.co/api/people/8/"),
                Create("Ratts Tyerell"          , "https://swapi.co/api/people/47/"),
                Create("Raymus Antilles"        , "https://swapi.co/api/people/81/"),
                Create("Rey"                    , "https://swapi.co/api/people/85/"),
                Create("Ric Olie"               , "https://swapi.co/api/people/39/"),
                Create("Roos Tarpals"           , "https://swapi.co/api/people/37/"),
                Create("Rugor Nass"             , "https://swapi.co/api/people/38/"),
                Create("Saesee Tiin"            , "https://swapi.co/api/people/56/"),
                Create("San Hill"               , "https://swapi.co/api/people/77/"),
                Create("Sebulba"                , "https://swapi.co/api/people/41/"),
                Create("Shaak Ti"               , "https://swapi.co/api/people/78/"),
                Create("Shmi Skywalker"         , "https://swapi.co/api/people/43/"),
                Create("Sly Moore"              , "https://swapi.co/api/people/82/"),
                Create("Tarfful"                , "https://swapi.co/api/people/80/"),
                Create("Taun We"                , "https://swapi.co/api/people/73/"),
                Create("Tion Medon"             , "https://swapi.co/api/people/83/"),
                Create("Wat Tambor"             , "https://swapi.co/api/people/76/"),
                Create("Watto"                  , "https://swapi.co/api/people/40/"),
                Create("Wedge Antilles"         , "https://swapi.co/api/people/18/"),
                Create("Wicket Systri Warrick"  , "https://swapi.co/api/people/30/"),
                Create("Wilhuff Tarkin"         , "https://swapi.co/api/people/12/"),
                Create("Yarael Poof"            , "https://swapi.co/api/people/57/"),
                Create("Yoda"                   , "https://swapi.co/api/people/20/"),
                Create("Zam Wesell"             , "https://swapi.co/api/people/70/")                
            };
        }

        private static Character Create(string name, string url) => new Character { Name = name , URL = url};
    }    
}
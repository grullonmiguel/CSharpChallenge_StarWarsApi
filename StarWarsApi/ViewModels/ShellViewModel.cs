using StarWarsApi.Core.Models;
using StarWarsApi.Core.Services;
using StarWarsApi.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StarWarsApi.ViewModels
{
    internal class ShellViewModel : ViewModelBase
    {
        #region Fields

        private int? characterId;
        private bool _isSearching;
        private Character _characterSelected;
        private ObservableCollection<Film> films;
        private ObservableCollection<Character> characters;
        private ObservableCollection<Starship> starships;
        private ObservableCollection<Vehicle> vehicles;

        private readonly ApiService _apiService;

        #endregion

        #region Properties

        /// <summary>
        /// Enabled when a numeric value greater than zero is entered
        /// </summary>
        public bool CanSearch => CharacterId != null && CharacterId > 0 && IsSearching != true;

        public int CharacterCount => Characters.Count;

        /// <summary>
        /// The ID to search in the SWAPI API
        /// https://swapi.co/api/people/1
        /// </summary>
        public int? CharacterId
        {
            get => characterId;
            set => Set(ref characterId, value);
        }

        /// <summary>
        /// Contains a list of characters
        /// </summary>
        public ObservableCollection<Character> Characters
        {
            get => characters;
            set => Set(ref characters, value);
        }

        /// <summary>
        /// Gets or sets the character selected
        /// </summary>
        public Character CharacterSelected
        {
            get => _characterSelected;
            set
            {
                Set(ref _characterSelected, value);

                GetStarshipsAsync();
                GetVehiclesAsync();
                GetHomeworldAsync();
                GetFilmsAsync();                
            }
        }

        private string homeWorld;

        public string HomeWorld
        {
            get => homeWorld;
            set => Set(ref homeWorld, value);
        }


        /// <summary>
        /// Set to True when API call is being made
        /// </summary>
        public bool IsSearching
        {
            get => _isSearching;
            set => Set(ref _isSearching, value);
        }


        public ObservableCollection<Film> Films
        {
            get => films;
            set => Set(ref films, value);
        }

        public ObservableCollection<Starship> Starships
        {
            get => starships;
            set => Set(ref starships, value);
        }

        public ObservableCollection<Vehicle> Vehicles
        {
            get => vehicles;
            set => Set(ref vehicles, value);
        }

        #endregion

        #region Commands
        public ICommand SearchCharacterCommand { get; }

        #endregion

        #region Constructor

        public ShellViewModel()
        {
            _apiService = new ApiService();
            Characters = new ObservableCollection<Character>();
            Films = new ObservableCollection<Film>();
            Starships = new ObservableCollection<Starship>();
            Vehicles = new ObservableCollection<Vehicle>();
            SearchCharacterCommand = new RelayCommand(async () => await GetCharacterAsync(), () => CanSearch);
        }

        #endregion

        #region Methods

        private void ResetSearch()
        {
            CharacterId = null;
            IsSearching = false;
        }

        private void ShowMessage(string message)
        {
            System.Windows.MessageBox.Show(message);
        }

        #endregion

        #region Api Search

        /// <summary>
        /// Execute API call to SWAPI and add
        /// Character to list if successful
        /// </summary>
        private async Task GetCharacterAsync()
        {
            try
            {
                if (Characters.Any(p => p.Id == CharacterId) || CharacterId == null || CharacterId <= 0)
                    return;

                IsSearching = true;

                var character = await _apiService.GetAsync<Character>($"https://swapi.co/api/people/{(int)CharacterId}");

                Characters.Add(character.Value);

                if (Characters.Count == 1)
                    CharacterSelected = Characters.First();

                OnPropertyChanged(nameof(CharacterCount));
            }
            catch (Exception e)
            {
                ShowMessage(e.Message.ToString());
            }
            finally
            {
                ResetSearch();
            }
        }

        private async Task GetFilmsAsync()
        {
            try
            {
                Films.Clear();

                foreach (var url in CharacterSelected.Films)
                {
                    var film = await _apiService.GetAsync<Film>(url);
                    Films.Add(film.Value);
                }
            }
            catch (Exception e)
            {
                ShowMessage(e.Message.ToString());
            }
        }

        private async Task GetHomeworldAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(CharacterSelected.Homeworld))
                    return;

                var world = await _apiService.GetAsync<Planet>(CharacterSelected.Homeworld);

                HomeWorld = world.Value.Name;
            }
            catch (Exception e)
            {
                ShowMessage(e.Message.ToString());
            }
        }

        private async Task GetStarshipsAsync()
        {
            try
            {
                Starships.Clear();
                foreach (var url in CharacterSelected.Starships)
                {
                    var starship = await _apiService.GetAsync<Starship>(url);
                    Starships.Add(starship.Value);
                }
            }
            catch (Exception e)
            {
                ShowMessage(e.Message.ToString());
            }
        }

        private async Task GetVehiclesAsync()
        {
            try
            {
                Vehicles.Clear();

                foreach (var url in CharacterSelected.Vehicles)
                {
                    var vehicle = await _apiService.GetAsync<Vehicle>(url);
                    Vehicles.Add(vehicle.Value);
                }
            }
            catch (Exception e)
            {
                ShowMessage(e.Message.ToString());
            }
        }

        #endregion
    }
}
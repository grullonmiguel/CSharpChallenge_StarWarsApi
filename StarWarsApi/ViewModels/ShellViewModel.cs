using StarWarsApi.Core.Models;
using StarWarsApi.Core.Services;
using StarWarsApi.Helpers;
using System;
using System.Collections.Generic;
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
        public List<Character> Characters { get; set; }

        /// <summary>
        /// Gets or sets the character selected
        /// </summary>
        public Character CharacterSelected
        {
            get => _characterSelected;
            set => Set(ref _characterSelected, value);
        }

        private Character _selectedItem;

        public Character SelectedItem
        {
            get => _selectedItem;
            set 
            { 
                Set(ref _selectedItem, value);
                GetCharacterinfo();
            }
        }


        private string homeWorld;
        private int myVar;

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
            Films = new ObservableCollection<Film>();
            Starships = new ObservableCollection<Starship>();
            Vehicles = new ObservableCollection<Vehicle>();
            SearchCharacterCommand = new RelayCommand(async () => await GetCharacterAsync(), () => CanSearch);
            LoadCharacterList();
        }

        public async void LoadCharacterList()
        {
            var list = await CharacterDataService.GetCharacterDataAsync();
            Characters = list.ToList();
            OnPropertyChanged(nameof(CharacterCount));
        }

        #endregion

        #region Methods

        private void ShowMessage(string message)
        {
            System.Windows.MessageBox.Show(message);
        }

        #endregion

        #region Api Search

        private async void GetCharacterinfo()
        {
            // Must get character information first
            await GetCharacterAsync();

            // No need to await methods below
            _ = GetFilmsAsync();
            _ = GetStarshipsAsync();
            _ = GetVehiclesAsync();
            _ = GetHomeworldAsync();
        }

        /// <summary>
        /// Execute API call to SWAPI and add
        /// Character to list if successful
        /// </summary>
        private async Task GetCharacterAsync()
        {
            try
            {
                IsSearching = true;
                
                var character = await _apiService.GetAsync<Character>(SelectedItem.URL);

                CharacterSelected = character.Value;
            }
            catch (Exception e)
            {
                ShowMessage(e.Message.ToString());
            }
            finally
            {
                IsSearching = false;
            }
        }

        private async Task GetFilmsAsync()
        {
            try
            {
                IsSearching = true;

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
            finally
            {
                IsSearching = false;
            }
        }

        private async Task GetHomeworldAsync()
        {
            try
            {
                IsSearching = true;

                if (string.IsNullOrEmpty(CharacterSelected.Homeworld))
                    return;

                var world = await _apiService.GetAsync<Planet>(CharacterSelected.Homeworld);

                HomeWorld = world.Value.Name;
            }
            catch (Exception e)
            {
                ShowMessage(e.Message.ToString());
            }
            finally
            {
                IsSearching = false;
            }
        }

        private async Task GetStarshipsAsync()
        {
            try
            {
                IsSearching = true;

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
            finally
            {
                IsSearching = false;
            }
        }

        private async Task GetVehiclesAsync()
        {
            try
            {
                IsSearching = true;

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
            finally
            {
                IsSearching = false;
            }
        }

        #endregion
    }
}
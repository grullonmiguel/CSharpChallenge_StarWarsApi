using StarWarsApi.Core.Models;
using StarWarsApi.Core.Services;
using StarWarsApi.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApi.ViewModels
{
    internal class ShellViewModel : ViewModelBase
    {
        #region Fields

        private bool _isSearching;
        private bool _isEnabled;
        private Character _characterSelected;
        private Character _selectedItem;

        private readonly ApiService _apiService = new ApiService();

        #endregion

        #region Properties
        
        public int CharacterCount => Characters.Count;

        public List<Character> Characters { get; set; }

        public Character CharacterSelected
        {
            get => _characterSelected;
            set => Set(ref _characterSelected, value);
        }

        public Character SelectedItem
        {
            get => _selectedItem;
            set 
            {
                Set(ref _selectedItem, value);
                IsEnabled = value != null;

                // When row is deselected value is null
                if (value == null)
                    return;

                GetCharacterinfo();
            }
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => Set(ref _isEnabled, value);
        }

        /// <summary>
        /// Set to True when calling API
        /// </summary>
        public bool IsSearching
        {
            get => _isSearching;
            set => Set(ref _isSearching, value);
        }

        public ObservableCollection<Film> Films { get; private set; } = new ObservableCollection<Film>();

        public ObservableCollection<Starship> Starships { get; private set; } = new ObservableCollection<Starship>();

        public ObservableCollection<Vehicle> Vehicles { get; private set; } = new ObservableCollection<Vehicle>();

        public bool HasFilms => Films.Count > 0;
        public bool HasStarships => Starships.Count > 0;
        public bool HasVehicles => Vehicles.Count > 0;

        #endregion

        #region Constructor

        public ShellViewModel()
        {
            Task.Factory.StartNew(async () =>
            {
                var list = await CharacterDataService.GetCharacterDataAsync();
                Characters = list.ToList();
                OnPropertyChanged(nameof(CharacterCount));
            });
        }

        #endregion

        #region Methods

        private void ClearLists()
        {
            Films.Clear();
            Starships.Clear();
            Vehicles.Clear();
        }

        private void ShowMessage(string message)
        {
            System.Windows.MessageBox.Show(message);
        }

        #endregion

        #region Api Search

        private async void GetCharacterinfo()
        {
            // Allow previous search to finish
            if (IsSearching) 
                return;
                    
            try
            {
                IsSearching = true;

                ClearLists();
              
                await GetCharacterAsync();

                var vehicles  = GetVehiclesAsync();
                var starships = GetStarshipsAsync();
                var films     = GetFilmsAsync();

                await Task.WhenAll(vehicles, starships, films);

                IsSearching = false;
            }
            catch (Exception e)
            {
                ShowMessage(e.Message.ToString()); 
                IsSearching = false;
            }
        }

        private async Task GetCharacterAsync()
        {
            var character = await _apiService.GetAsync<Character>(SelectedItem.URL);
            character.Value.World = await GetHomeworldAsync(character.Value.Homeworld);
            CharacterSelected = character.Value;
        }

        private async Task GetFilmsAsync()
        {
            foreach (var url in CharacterSelected.Films)
            {
                var film = await _apiService.GetAsync<Film>(url);
                Films.Add(film.Value);
            }
            OnPropertyChanged(nameof(HasFilms));
        }

        private async Task<string> GetHomeworldAsync(string homeworld)
        {
            if (string.IsNullOrEmpty(homeworld))
                return string.Empty;

            var world = await _apiService.GetAsync<Planet>(homeworld);
            return world.Value.Name;            
        }

        private async Task GetStarshipsAsync()
        {
            foreach (var url in CharacterSelected.Starships)
            {
                var starship = await _apiService.GetAsync<Starship>(url);
                Starships.Add(starship.Value);
            }
            OnPropertyChanged(nameof(HasStarships));
        }

        private async Task GetVehiclesAsync()
        {
            foreach (var url in CharacterSelected.Vehicles)
            {
                var vehicle = await _apiService.GetAsync<Vehicle>(url);
                Vehicles.Add(vehicle.Value);
            }
            OnPropertyChanged(nameof(HasVehicles));
        }

        #endregion
    }
}
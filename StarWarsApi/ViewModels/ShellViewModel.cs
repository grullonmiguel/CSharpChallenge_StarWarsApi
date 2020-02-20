using StarWarsApi.Core.Models;
using StarWarsApi.Core.Services;
using StarWarsApi.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace StarWarsApi.ViewModels
{
    internal class ShellViewModel : ViewModelBase
    {
        #region Fields

        private bool _isSearching;
        private bool _isEnabled;
        private string homeWorld;
        private string _characterImage;
        private Character _characterSelected;
        private Character _selectedItem;

        private readonly ApiService _apiService = new ApiService();
        private readonly string _imagePath = "/StarWarsApi;component/Assets/";

        #endregion

        #region Properties

        public bool CanSearch => IsSearching != true;

        public int CharacterCount => Characters.Count;

        public List<Character> Characters { get; set; }

        public Character CharacterSelected
        {
            get => _characterSelected;
            set
            {
                Set(ref _characterSelected, value);
                UpdateCharacterImage();
            }
        }

        public string CharacterImage
        {
            get => _characterImage;
            set => Set(ref _characterImage, value);
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

        public string HomeWorld
        {
            get => homeWorld;
            set => Set(ref homeWorld, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => Set(ref _isEnabled, value);
        }

        /// <summary>
        /// Set to True when API calling API
        /// </summary>
        public bool IsSearching
        {
            get => _isSearching;
            set => Set(ref _isSearching, value);
        }

        public ObservableCollection<Film> Films { get; private set; } = new ObservableCollection<Film>();

        public ObservableCollection<Starship> Starships { get; private set; } = new ObservableCollection<Starship>();

        public ObservableCollection<Vehicle> Vehicles { get; private set; } = new ObservableCollection<Vehicle>();

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
            HomeWorld = string.Empty;
        }

        private void ShowMessage(string message)
        {
            System.Windows.MessageBox.Show(message);
        }

        private void UpdateCharacterImage()
        {
            // Note:
            // Images are stored in the Assets directory
            // The image 'Build Action' is set to 'Resource'
            // The image is renamed to the character name with no spaces
            // The UI will only display the images that exist

            // Get the name from selected character and remove the empty space
            var image = CharacterSelected.Name.Replace(" ", string.Empty) + ".png";

            // Set the image using the path and image name
            CharacterImage = $"{_imagePath}{image}";
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
                await GetHomeworldAsync();
                await GetVehiclesAsync();
                await GetStarshipsAsync();
                await GetFilmsAsync();
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

        private async Task GetCharacterAsync()
        {
            var character = await _apiService.GetAsync<Character>(SelectedItem.URL);
            CharacterSelected = character.Value;
        }

        private async Task GetFilmsAsync()
        {
            foreach (var url in CharacterSelected.Films)
            {
                var film = await _apiService.GetAsync<Film>(url);
                Films.Add(film.Value);
            }
        }

        private async Task GetHomeworldAsync()
        {
            if (string.IsNullOrEmpty(CharacterSelected.Homeworld))
                return;

            var world = await _apiService.GetAsync<Planet>(CharacterSelected.Homeworld);
            HomeWorld = world.Value.Name;
        }

        private async Task GetStarshipsAsync()
        {
            foreach (var url in CharacterSelected.Starships)
            {
                var starship = await _apiService.GetAsync<Starship>(url);
                Starships.Add(starship.Value);
            }
        }

        private async Task GetVehiclesAsync()
        {
            foreach (var url in CharacterSelected.Vehicles)
            {
                var vehicle = await _apiService.GetAsync<Vehicle>(url);
                Vehicles.Add(vehicle.Value);
            }
        }

        #endregion
    }
}
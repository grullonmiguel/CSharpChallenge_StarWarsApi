using StarWarsApi.Helpers;
using StarWarsApi.Models;
using StarWarsApi.Services;
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
        private SwapiProcessor _swapiProcessor;
        private bool _isSearching;
        private ObservableCollection<Character> characters;
        private Character _selectedCharacter;
        private List<Starship> starships;
        private List<Vehicle> vehicles;

        #endregion

        #region Properties

        /// <summary>
        /// Enabled when a numeric value greater than zero is entered
        /// </summary>
        public bool CanSearch
        {
            get
            {
                if (CharacterId == null || CharacterId <= 0 || IsSearching == true)
                {
                    return false;
                }

                return true;
            }
        }

        public int CharacterCount
        {
            get => Characters.Count;
        }

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
        public Character SelectedCharacter
        {
            get => _selectedCharacter;
            set
            {
                Set(ref _selectedCharacter, value);
                Vehicles = SelectedCharacter?.VehicleList;
                Starships = SelectedCharacter?.StarshipList;
            }
        }

        /// <summary>
        /// Set to True when API call is being made
        /// </summary>
        public bool IsSearching
        {
            get => _isSearching;
            set => Set(ref _isSearching, value);
        }

        public List<Starship> Starships
        {
            get => starships;
            set => Set(ref starships, value);
        }

        public List<Vehicle> Vehicles
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
            _swapiProcessor = new SwapiProcessor();
            Characters = new ObservableCollection<Character>();
            SearchCharacterCommand = new RelayCommand(async () => await LoadCharacterAsync(), () => CanSearch);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Execute API call to SWAPI and add
        /// Character to list if successful
        /// </summary>
        private async Task LoadCharacterAsync()
        {
            try
            {
                if (ValidateCharacterId()) 
                    return;

                IsSearching = true;

                var character = await _swapiProcessor.GetCharacterAsync((int)CharacterId);

                Characters.Add(character);

                OnPropertyChanged(nameof(CharacterCount));
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
            }
            finally
            {
                CharacterId = null;
                IsSearching = false;
            }
        }

        private bool ValidateCharacterId()
        {
            return Characters.Any(p => p.Id == CharacterId) || CharacterId == null || CharacterId <= 0;
        }

        #endregion

    }
}
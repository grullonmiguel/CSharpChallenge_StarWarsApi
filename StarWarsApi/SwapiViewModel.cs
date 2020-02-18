using StarWarsApi.Common;
using StarWarsApi.Helpers;
using StarWarsApi.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StarWarsApi
{
    internal class SwapiViewModel : ViewModelBase
    {

        private SwapiProcessor _swapiProcessor;

        public SwapiViewModel()
        {
            _swapiProcessor = new SwapiProcessor();
            PeopleList = new ObservableCollection<People>();
        }

        /// <summary>
        /// The ID to search in the SWAPI API
        /// https://swapi.co/api/people/1
        /// </summary>
        private int? _swapiID;
        public int? SwapiID
        {
            get { return _swapiID; }
            set {_swapiID = value;OnPropertyChanged("SwapiID");}
        }

        /// <summary>
        /// The list of star wars characters returned from the API
        /// </summary>
        private ObservableCollection<People> _peopleList;
        public ObservableCollection<People> PeopleList
        {
            get { return _peopleList; }
            set { _peopleList = value; OnPropertyChanged("PeopleList"); }
        }

        private List<Vehicle> _vehicleList;
        public List<Vehicle> VehicleList
        {
            get { return _vehicleList; }
            set { _vehicleList = value; OnPropertyChanged("VehicleList"); }
        }

        private List<Starship> _starshipList;
        public List<Starship> StarshipList
        {
            get { return _starshipList; }
            set { _starshipList = value; OnPropertyChanged("StarshipList"); }
        }

        /// <summary>
        /// Gets or sets the User selected
        /// </summary>
        private People _selectedCharacter;
        public People SelectedCharacter
        {
            get { return _selectedCharacter; }
            set
            {
                _selectedCharacter = value;
                OnPropertyChanged("SelectedCharacter");
                VehicleList = SelectedCharacter?.VehicleList;
                StarshipList = SelectedCharacter?.StarshipList;
            }
        }

        /// <summary>
        /// Set to True when API call is being made
        /// </summary>
        private bool _isSearching;
        public bool IsSearching
        {
            get { return _isSearching; }
            set { _isSearching = value; OnPropertyChanged("IsSearching"); }
        }

        /// <summary>
        /// Display Total Character Count
        /// </summary>
        private int _peopleCount;
        public int PeopleCount
        {
            get { return _peopleCount; }
            set { _peopleCount = value; OnPropertyChanged("PeopleCount"); }
        }


        /// <summary>
        /// Command to initiate a character search
        /// </summary>
        public ICommand SearchCommand
        {
            get { return new BaseCommandModel(param => GetCharacter(), param => CanSearch); }
        }

        /// <summary>
        /// Enabled when a numeric value greater than zero is entered
        /// </summary>
        public bool CanSearch
        {
            get
            {
               if (SwapiID == null || SwapiID <= 0 || IsSearching == true)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Execute API call to SWAPI and add
        /// Character to list if successful
        /// </summary>
        private async void GetCharacter() => await LoadCharacterAsync();

        private async Task LoadCharacterAsync()
        {
            if (PeopleList.Any(p => p.Id == (int)SwapiID) || SwapiID == null || SwapiID <= 0)
                return;

            try
            {
                IsSearching = true;

                var character = await _swapiProcessor.GetCharacterAsync((int)SwapiID);

                PeopleList.Add(character);
                PeopleCount = PeopleList.Count;
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message.ToString());
            }
            finally
            {
                SwapiID = null;
                IsSearching = false;
            }
        }

    }
}
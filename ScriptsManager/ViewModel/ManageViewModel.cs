using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ScriptsManager.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ScriptsManager.ViewModel
{
    public class ManageViewModel : ViewModelBase
    {
        public ICommand AddCardCommand { get; private set; }
        public ObservableCollection<ScriptCard> ScriptCardCollection { get; private set; } = new ObservableCollection<ScriptCard>();

        public ManageViewModel()
        {
            AddCardCommand = new RelayCommand(AddCard);
        }

        private void AddCard()
        {
            const int numberOfScriptCardToAdd = 1;

            ScriptCardCollection.Add(new ScriptCard()
            {
                Id = ScriptCardCollection.Count + numberOfScriptCardToAdd,
                ScriptName = "Script name",
                FilePath = "FileTestPath",
                LastRunDate = DateTime.Now,
                EditScriptCardCommand = new RelayCommand<int>(rc => EditScriptCard(rc)),
                DeleteScriptCardCommand = new RelayCommand<int>(rc => DeleteScriptCard(rc))
            });
        }

        private void DeleteScriptCard(int id)
        {
            ScriptCard scriptCardToDelete = GetScriptCardById(id);
            ScriptCardCollection.Remove(scriptCardToDelete);
        }

        private void EditScriptCard(int id)
        {
            throw new NotImplementedException();
        }

        private ScriptCard GetScriptCardById(int id)
        {
            return ScriptCardCollection.First(x => x.Id == id);
        }
    }
}

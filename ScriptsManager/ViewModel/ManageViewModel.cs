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
        public ICommand AddCommand { get; private set; }
        public ObservableCollection<ScriptCard> ScriptCardCollection { get; private set; } = new ObservableCollection<ScriptCard>();

        public ManageViewModel()
        {
            AddCommand = new RelayCommand(Add);
        }

        private void Add()
        {
            const int numberOfScriptCardToAdd = 1;

            ScriptCardCollection.Add(new ScriptCard()
            {
                Id = ScriptCardCollection.Count + numberOfScriptCardToAdd,
                ScriptName = "Script name",
                FilePath = "FileTestPath",
                LastRunDate = DateTime.Now,
                EditCommand = new RelayCommand<int>(rc => Edit(rc)),
                DeleteCommand = new RelayCommand<int>(rc => Delete(rc))
            });
        }

        private void Delete(int id)
        {
            ScriptCard scriptCardToDelete = GetScriptCardById(id);
            ScriptCardCollection.Remove(scriptCardToDelete);
        }

        private void Edit(int id)
        {
            throw new NotImplementedException();
        }

        private ScriptCard GetScriptCardById(int id)
        {
            return ScriptCardCollection.First(x => x.Id == id);
        }
    }
}

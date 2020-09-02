using System.Windows.Input;

namespace ScriptsManager.Models
{
    public class ScriptCard : Script
    {
        public ICommand ChangePathToScriptCommand { get; set; }
        public ICommand DeleteScriptCardCommand { get; set; }
        public ICommand RunScriptCommand { get; set; }
    }
}

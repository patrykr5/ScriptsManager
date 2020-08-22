using System;
using System.Windows.Input;

namespace ScriptsManager.Models
{
    public class ScriptCard
    {
        public int Id { get; set; }
        public string ScriptName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreateDate { get; set; }
        public ICommand ChangePathToScriptCommand { get; set; }
        public ICommand DeleteScriptCardCommand { get; set; }
        public ICommand RunScriptCommand { get; set; }
    }
}

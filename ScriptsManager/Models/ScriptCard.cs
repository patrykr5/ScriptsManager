using System;
using System.Windows.Input;

namespace ScriptsManager.Models
{
    public class ScriptCard
    {
        public int Id { get; set; }
        public string ScriptName { get; set; }
        public string FilePath { get; set; }
        public DateTime LastRunDate { get; set; }
        public ICommand EditScriptCardCommand { get; set; }
        public ICommand DeleteScriptCardCommand { get; set; }
    }
}

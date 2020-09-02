using System;

namespace ScriptsManager.Models
{
    public class Script
    {
        public int Id { get; set; }
        public string ScriptName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

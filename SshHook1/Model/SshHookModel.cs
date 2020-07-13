using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SshHook1.Model
{
    public class SshHookModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Ip { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Login { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Pass { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Command { get; set; }
        public string Seconds { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class ListFileModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Package { get; set; }
        public string Url { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public int Download { get; set; }
        public int Status { get; set; }
        public int? Id_Approved { get; set; }
        public int? UserId_Created { get; set; }
        public string Icon { get; set; }
        public string Screenshot { get; set; }
        public Guid? Subject { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Ver { get; set; }
        public string FileDescription { get; set; }
    }

    public class FileDesc
    {
        public int Id { get; set; }
        public string Url { get; set; }
    }
}

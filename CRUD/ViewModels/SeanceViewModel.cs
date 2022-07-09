using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Models;

namespace CRUD.ViewModels
{
    public class SeanceViewModel : ViewModelBase
    {

        public string MovieName { get; set; }
        public string StartTime { get; set; }
        public string HallNumber { get; set; }

        public SeanceViewModel(string movieName, string startTime, string hallNumber)
        {
            MovieName = movieName;
            StartTime = startTime;
            HallNumber = hallNumber;
        }
    }
}

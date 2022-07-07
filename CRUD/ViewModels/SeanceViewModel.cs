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
        private readonly Seance seance;

        public string SeanceID => seance.id_movie.ToString();

        public SeanceViewModel(Seance _seance)
        {
            seance = _seance;
        }
    }
}

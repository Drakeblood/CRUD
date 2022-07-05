using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models
{
    struct Worker
    {
        public long id;
        public string login;
        public string password;
    }

    class Workers
    {
        public List<Worker> workers;

        public Workers()
        {
            workers = new List<Worker>();
        }
    }
}

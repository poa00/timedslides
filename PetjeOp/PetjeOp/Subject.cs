﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetjeOp
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Subject(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM_character_creator.Content.Vampire
{
    class BaneCompulsion
    {
        private string baneDescription;
        private string compulsionDescription;

        public BaneCompulsion(string baneDescription, string compulsionDescription)
        {
            this.baneDescription = baneDescription;
            this.compulsionDescription = compulsionDescription;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IASHandyMan.CrossCutting.EmailModel
{
    public class ConfirmationEmail
    {
        public string Email { get; set; }
        public string CallBack { get; set; }
        public string Name { get; set; }
    }
}

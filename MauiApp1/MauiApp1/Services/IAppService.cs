﻿using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public interface IAppService
    {
        public Task<string> Login(LoginModel loginModel);
        public Task<List<ListFileModel>> GetFilePublished();
    }
}
